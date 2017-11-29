using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;

namespace Note2018
{
    public class NoteRepository
    {
        public enum RequestItems
        {
            AllItems,
            AllVisible,
            FavoriteItems,
            RecycleBinItems
        }


        static object locker = new object();

        SQLiteConnection database;
        public NoteRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Note>();
        }

        public IEnumerable<Note> GetItems(RequestItems request)
        {
            switch (request)
            {
                case RequestItems.AllItems: return (from i in database.Table<Note>() select i).ToList();
                case RequestItems.AllVisible: return (from i in database.Table<Note>() where i.InRecycleBin == false select i).ToList();
                case RequestItems.FavoriteItems: return (from i in database.Table<Note>() where ((i.IsFavorite != 0) && (i.InRecycleBin == false)) select i).ToList();
                case RequestItems.RecycleBinItems: return (from i in database.Table<Note>() where i.InRecycleBin == true select i).ToList();
                default: return null;
            }
        }

        public Note GetItem(int id)
        {
            return database.Get<Note>(id);
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Note>(id);
            }
        }

        public int SaveItem(Note item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Note2018
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string FolderName { get; set; }
        public string Headler { get; set; }
        public string NoteText { get; set; }
        public bool IsFavorite { get; set; }
    }
}
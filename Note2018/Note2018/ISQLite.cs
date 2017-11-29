using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Note2018;

namespace Note2018
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}

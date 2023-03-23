using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public static class ConnectionHelper
    {
        public static string ConnectionString
        {
            get
            {
                string db = Path.Combine(Path.GetFullPath(@"..\..\"), "BooksDb.mdf");
                return $@"Data Source=(localdb)\mssqllocaldb;AttachDbFilename={db};Initial Catalog=BooksDb;Trusted_Connection=True";
            }
        }
    }
}

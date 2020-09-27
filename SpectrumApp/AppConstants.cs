using System;
using System.IO;

namespace SpectrumApp
{
    public static class AppConstants
    {
        public const string RxNumberLetterNoSpecial5to12 = "^(?=.*[0-9])(?=.*[a-zA-Z])(?!.*[!*@#$%^&+=]).{5,12}$";
        public const string RxOneDuplicateOrMore = "(.+)\\1+";


        public const string DatabaseFilename = "SpectrumSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}

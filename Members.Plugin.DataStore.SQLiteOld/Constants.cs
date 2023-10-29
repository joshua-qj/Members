using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Plugin.DataStore.SQLite {
    public class Constants {
        public const string DatabaseFileName = "MembersSQLite.db3";
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}

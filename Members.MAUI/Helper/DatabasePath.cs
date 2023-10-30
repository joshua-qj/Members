namespace Members.MAUI.Helper {
    public  class DatabasePath {
        public static string GetDatabasePath() {
            var databasePath = "";
            const string DatabaseFileName = "MembersSQLite.db3";
            if (DeviceInfo.Platform == DevicePlatform.Android) {
                databasePath= Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
            }
            if (DeviceInfo.Platform == DevicePlatform.iOS) {
                SQLitePCL.Batteries_V2.Init();
                databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseFileName); ;
            }
            return databasePath;
            /*
                     if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
        }
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            SQLitePCL.Batteries_V2.Init();
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
        }

             */

        }
    }
}

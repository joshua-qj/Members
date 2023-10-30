namespace Members.MAUI.Helper {
    public  class DatabasePath {
        public static string GetDatabasePath() {
            const string DatabaseFileName = "MembersSQLite.db3";
            string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
            return DatabasePath;


        }
    }
}

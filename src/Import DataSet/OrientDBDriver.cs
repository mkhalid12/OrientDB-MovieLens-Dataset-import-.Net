using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add reference to Orient Library
using Orient.Client;


namespace Import_DataSet
{
    public static class  OrientDBDriver
    {
        // Enter your orientdb credential here

        static string _hostName = "127.0.0.1"; // Localhost IP
        static int _port = 2424;
        static string _username = "admin";
        static string _pass = "admin";

        static string _rootUserName = "root";
        static string _rootPass = "admin";

        private static OServer _server;
        public static int DatabasePoolSize { get { return 10; } }
        public static string DatabaseName { get; private set; }
        public static ODatabaseType DatabaseType { get; private set; }
        public static string DatabaseAlias { get; private set; }

        static  OrientDBDriver()
        {
            _server = new OServer(_hostName, _port, _rootUserName, _rootPass);
            DatabaseName = "MoviesRatings";
            DatabaseType = ODatabaseType.Graph;
            DatabaseAlias = "OrientDB";
        }

        public static void CreateDatabase()
        {
            DropTestDatabase();
            _server.CreateDatabase(DatabaseName, DatabaseType, OStorageType.PLocal);
          
        }

        public static void DropTestDatabase()
        {
            if (_server.DatabaseExist(DatabaseName,OStorageType.PLocal))
            {
                _server.DropDatabase(DatabaseName, OStorageType.PLocal);
            }
        }

        public static void CreatePool()
        {
            OClient.CreateDatabasePool(
                _hostName,
                _port,
                DatabaseName,
                DatabaseType,
                _username,
                _pass,
                DatabasePoolSize,
                DatabaseAlias
            );
        }

        public static void DropTestPool()
        {
            OClient.DropDatabasePool(DatabaseAlias);
        }

        public static OServer GetServer()
        {
            return _server;
        }

        
    }

  
}

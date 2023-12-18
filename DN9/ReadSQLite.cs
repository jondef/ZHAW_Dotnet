using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace DN9 {
    public class SQLiteReader {
        public string DbConnectionString { set; get; }
        public string TableName { set; get; }

        private IDbConnection conn = null;

        public SQLiteReader(string connection, string table) {
            DbConnectionString = connection;
            TableName = table;
        }

        // use Connection String to open DB connection
        // return open connection
        public IDbConnection DbConnection {
            get {
                if (conn == null) {
                    conn = new SqliteConnection(DbConnectionString);
                    conn.Open();
                }
                return conn;
            }
        }

        public IEnumerable<object[]> ReadDbRow(IDbConnection conn) {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {TableName}";
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                object[] row = new object[reader.FieldCount];
                reader.GetValues(row);
                yield return row;
            }
        }
        public void WriteDbRow(object[] row) {
            foreach (object o in row) {
                Console.Write(o + ",");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args) {
            string connectionString = @"data source=c:\tmp\app2020.db;";
            SQLiteReader reader = new SQLiteReader(connectionString, "Appointments");
            IDbConnection conn = reader.DbConnection;
            foreach (object[] o in reader.ReadDbRow(conn)) {
                reader.WriteDbRow(o);
            }
            conn.Close();
            Console.ReadKey();
        }
    }
}
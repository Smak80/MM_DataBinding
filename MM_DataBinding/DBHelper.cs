using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MM_DataBinding
{
    public class DBHelper
    {
        private static MySqlConnection? conn = null;
        private DBHelper(
            String host,
            int port,
            String user,
            String password,
            String database
        )
        {
            var connStr = $"Server={host};port={port};database={database};User Id={user};password={password}";
            conn = new MySqlConnection(connStr);
            conn?.Open();
        }

        private static DBHelper instance = null;
        public static DBHelper GetInstance(
            String host = "localhost",
            int port = 0,
            String user = "root",
            String password = "",
            String database = ""
            )
        {
            if (instance == null)
            {
                instance = new DBHelper(host, port, user, password, database);
            }
            return instance;
        }

        public BindingList<Group> GetGroups()
        {
            BindingList<Group> groups = new BindingList<Group>();
            var queryStr = "SELECT * FROM StudentGroup";
            var cmd = conn?.CreateCommand();
            cmd.CommandText = queryStr;
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        groups.Add(new Group
                        {
                            Num = reader.GetString(nameof(Group.Num)),
                            Year = reader.GetInt32(nameof(Group.Year)),
                            Spec = reader.GetString(nameof(Group.Spec)),
                            Department = reader.GetString(nameof(Group.Department)),
                            Level = reader.GetString(nameof(Group.Level))
                        });
                    }
                }
            }
            return groups;
        }

        public void InsertNew(Group newGr)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `StudentGroup` (Num, Year, Spec, Department, Level) " +
                              "Values (@num, @year, @spec, @department, @level);";
            cmd.Parameters.Add(new MySqlParameter("@num", newGr.Num));
            cmd.Parameters.Add(new MySqlParameter("@year", newGr.Year));
            cmd.Parameters.Add(new MySqlParameter("@spec", newGr.Spec));
            cmd.Parameters.Add(new MySqlParameter("@department", newGr.Department));
            cmd.Parameters.Add(new MySqlParameter("@level", newGr.Level));
            cmd.ExecuteNonQuery();
        }
    }
}

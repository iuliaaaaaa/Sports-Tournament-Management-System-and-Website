using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthesisAssignment.DataAccess
{
    public class TournamentSystem
    {
        public static void SignUpUser(string username, int tournamentid)
        {
            MySqlConnection conn = new MySqlConnection($"SERVER=studmysql01;UID=dbi475741;DATABASE=dbi475741;PASSWORD=1234;");
            try
            {
                using (conn)
                {
                    if (username != string.Empty && tournamentid != null)
                    {
                        string sql = "INSERT username,tournamentId INTO signedplayers WHERE username=@username,tournamentId=@tournamentId;";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@tournamentId", tournamentid);
                        conn.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                    }
                }
            }
            finally
            {
                conn.Close();
            }


         }
    }
}

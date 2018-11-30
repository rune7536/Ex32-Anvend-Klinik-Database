using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ex32AnvendKlinikdatabase
{
    class Program
    {
        private static string conntectionString =
           "Server = ealSQL1.eal.local; Database = Ex31Klinik; User Id = A_STUDENT29; Password = A_OPENDB29;";

        static void Main(string[] args)
        {
            Program prog = new Ex32AnvendKlinikdatabase.Program();
            prog.Run();
        }
        private void Run()
        {
            using (SqlConnection con = new SqlConnection(conntectionString))
            {
                try
                {
                    con.Open();

                    /*SqlCommand cmd1 = new SqlCommand("IndsætAdresse", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@Gade", "Borgesvej"));
                    cmd1.Parameters.Add(new SqlParameter("@HusNr", "32"));
                    cmd1.Parameters.Add(new SqlParameter("@PostNr", "5000"));
                    
                    cmd1.ExecuteNonQuery();*/

                    
                    SqlCommand cmd2 = new SqlCommand("VisAftalerForPatient", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("PatientId", 1));

                    SqlDataReader reader = cmd2.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string id = reader["Id"].ToString();
                            string læge = reader["Læge"].ToString();
                            string klinikAdresse = reader["KlinikAdresse"].ToString();
                            string patient = reader["Patient"].ToString();
                            string pårørende = reader["Pårørende"].ToString();
                            string dato = reader["Dato"].ToString();
                            string tidspunkt = reader["Tidspunkt"].ToString();
                            Console.WriteLine(id + " " + læge + " " + klinikAdresse + " " + patient + " " + pårørende + " " + dato + " " + tidspunkt);
                        }
                    }

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Woopsi" + e.Message);
                }
            }
        }
        
    }
}


using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BaseDatos
{
    public class LogDAO
    {
        private SqlConnection sqlConnection;

        public LogDAO()
        {
            sqlConnection = new SqlConnection("Server=.;Database=bomberos2-db;Trusted_Connection=True;");
        }
        public void Guardar(string info)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO dbo.log (entradan, alumno) VALUES (@info, 'Debora Recalde')", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@info", info);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }

        public string Leer()
        {
            try
            {

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT entrada FROM dbo.log", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                if (sqlDataReader.Read())
                {
                    sb.AppendLine(sqlDataReader.GetString(0));
                }
                return sb.ToString();
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
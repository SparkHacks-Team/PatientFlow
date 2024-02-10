using Dapper;
using PatientAPI.Model;
using System.Data;
using System.Data.SqlClient;

namespace PatientAPI.Repository
{
    public class PatientRepository
    {
        public void AddPatient(Patient pat)
        {
            //call Add Employee Stored procedure
            var objBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration conManager = objBuilder.Build();
            string connectionString = conManager.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String storedProcedureName = "InsertPatient";
                var parms1 = new DynamicParameters();
                parms1.Add("FirstName", pat.FirstName);
                parms1.Add("LastName", pat.LastName);
                parms1.Add("Gender", pat.Gender);
                parms1.Add("Age", pat.Age);
                connection.ExecuteScalar(storedProcedureName, parms1, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}

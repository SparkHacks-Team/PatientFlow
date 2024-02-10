using MedicationAPI.Model;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace MedicationAPI.Repository
{
    public class MedicationRepository
    {
        internal Medication GetMedication(int id)
        {
            var objBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration conManager = objBuilder.Build();
            string connectionString = conManager.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String storedProcedureName = "GetMedication";
                var parms1 = new DynamicParameters();
                parms1.Add("Medication_ID", id);
                Medication med = connection.QueryFirstOrDefault<Medication>(storedProcedureName, parms1, commandType: CommandType.StoredProcedure);
                return med;
            }
        }

        internal IEnumerable<Medication> GetMedications()
        {
            var objBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration conManager = objBuilder.Build();
            string connectionString = conManager.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String storedProcedureName = "GetAllMedication";
                IEnumerable<Medication> medications = connection.Query<Medication>(storedProcedureName, commandType: CommandType.StoredProcedure);
                return medications;
            }
        }
    }
}

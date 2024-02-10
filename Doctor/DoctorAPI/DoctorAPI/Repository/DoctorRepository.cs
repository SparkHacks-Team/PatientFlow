using DoctorAPI.Model;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace DoctorAPI.Repository
{
    public class DoctorRepository
    {
        internal void AddDoctor(Doctor doc)
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
                String storedProcedureName = "InsertDoctor";
                var parms1 = new DynamicParameters();
                parms1.Add("Doctor_ID", doc.Doctor_ID);
                parms1.Add("FirstName", doc.FirstName);
                parms1.Add("LastName", doc.LastName);
                parms1.Add("Speciality", doc.Speciality);
                connection.ExecuteScalar(storedProcedureName, parms1, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        internal Doctor GetDoctor(int id)
        {
            var objBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration conManager = objBuilder.Build();
            string connectionString = conManager.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String storedProcedureName = "GetDoctor";
                var parms1 = new DynamicParameters();
                parms1.Add("Doctor_ID", id);
                Doctor doc = connection.QueryFirstOrDefault<Doctor>(storedProcedureName, parms1, commandType: CommandType.StoredProcedure);
                return doc;
            }
        }

        internal IEnumerable<Doctor> GetDoctors()
        {
            var objBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration conManager = objBuilder.Build();
            string connectionString = conManager.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String storedProcedureName = "GetAllDoctor";
                IEnumerable<Doctor> employees = connection.Query<Doctor>(storedProcedureName, commandType: CommandType.StoredProcedure);
                return employees;
            }
        }

        internal void UpdateDoctor(Doctor doc)
        {
            var objBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration conManager = objBuilder.Build();
            string connectionString = conManager.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String storedProcedureName = "UpdateDoctor";
                var parms1 = new DynamicParameters();
                parms1.Add("Doctor_ID", doc.Doctor_ID);
                parms1.Add("FirstName", doc.FirstName);
                parms1.Add("LastName", doc.LastName);
                parms1.Add("Speciality", doc.Speciality);
                connection.ExecuteScalar(storedProcedureName, parms1, commandType: System.Data.CommandType.StoredProcedure);


            }
        }
    }
}

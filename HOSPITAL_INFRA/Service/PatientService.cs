using HOSPITAL_CORE.Interface;
using HOSPITAL_CORE.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_INFRA.Service
{
    public class PatientService : IPatient
    {

        string ConnectionString = "Server=ITH-PF391CWP;Database=HospitalDB__;Trusted_Connection=True;MultipleActiveResultSets=true";

        public async Task<bool> CreatePatient(CreatePatientModel data)
        {
            try
            {
                using (var sqlcn = new SqlConnection(ConnectionString))
                {
                    await sqlcn.OpenAsync();

                    string query = "";

                    if (data.PatientID == null) query = "INSERT INTO Patient " +
                        "([IdDocumentType], [DocumentNumber],[FirstName],[LastName],[BirthDate],[IdGender] " +
                        ",[Address],[ContactNumber],[Active]) " +
                        "VALUES (@IdDocumentType, @DocumentNumber, @FirstName, @LastName, @BirthDate, " +
                        "@IdGender, @Address, @ContactNumber, @Active)";
                    else query = "UPDATE Patient " +
                            "SET [IdDocumentType] = @IdDocumentType, [DocumentNumber] = @DocumentNumber, " +
                            "[FirstName] = @FirstName, [LastName] = @LastName, [BirthDate] = @BirthDate, " +
                            "[IdGender] = @IdGender ,[Address] = @Address,[ContactNumber] = @ContactNumber, " +
                            "[Active] = @Active " +
                            "WHERE PatientID = @PatientID";

                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    cmd.CommandType = CommandType.Text;
                    if (data.PatientID != null) cmd.Parameters.Add(new SqlParameter("@PatientID", data.PatientID));
                    cmd.Parameters.Add(new SqlParameter("@IdDocumentType", data.IdDocumentType));
                    cmd.Parameters.Add(new SqlParameter("@DocumentNumber", data.DocumentNumber));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", data.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", data.LastName));
                    cmd.Parameters.Add(new SqlParameter("@BirthDate", data.BirthDate));
                    cmd.Parameters.Add(new SqlParameter("@IdGender", data.IdGender));
                    cmd.Parameters.Add(new SqlParameter("@Address", data.Address));
                    cmd.Parameters.Add(new SqlParameter("@ContactNumber", data.ContactNumber));
                    cmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                    await cmd.ExecuteNonQueryAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<object> DetailPatients()
        {
            try
            {
                using (var sqlcn = new SqlConnection(ConnectionString))
                {
                    await sqlcn.OpenAsync();

                    string query = "SELECT * FROM Patient AS PA " +
                        "INNER JOIN Gender AS GE ON GE.IdGender = PA.IdGender " +
                        "INNER JOIN Document AS DC ON DC.IdDocumentType = PA.IdGender";

                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DetailPatientModel> list = new List<DetailPatientModel>();

                    object data = "";

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            DetailPatientModel db = new DetailPatientModel();
                            db.PatientID = Convert.ToInt32(reader["PatientID"]);
                            db.IdDocumentType = Convert.ToInt32(reader["IdDocumentType"]);
                            db.DocumentType = reader["DocumentType"].ToString();
                            db.DocumentNumber = reader["DocumentNumber"].ToString();
                            db.FirstName = reader["FirstName"].ToString();
                            db.LastName = reader["LastName"].ToString();
                            db.BirthDate = reader["BirthDate"].ToString();
                            db.IdGender = Convert.ToInt32(reader["IdGender"]);
                            db.Gender = reader["GenderName"].ToString();
                            db.Address = reader["Address"].ToString();
                            db.ContactNumber = reader["ContactNumber"].ToString();
                            db.Active = Convert.ToBoolean(reader["Active"]);
                            list.Add(db);
                        }
                        data = list;
                    }
                    return data;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> ConsultPatient(int PatientID)
        {
            try
            {
                using (var sqlcn = new SqlConnection(ConnectionString))
                {
                    await sqlcn.OpenAsync();

                    string query = "SELECT * " +
                        "FROM [dbo].[Patient] " +
                        "WHERE PatientID = @PatientID";

                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@PatientID", PatientID));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DetailPatientModel> list = new List<DetailPatientModel>();

                    object data = "";

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            DetailPatientModel db = new DetailPatientModel();
                            db.PatientID = Convert.ToInt32(reader["PatientID"]);
                            db.IdDocumentType = Convert.ToInt32(reader["IdDocumentType"]);
                            db.DocumentNumber = reader["DocumentNumber"].ToString();
                            db.FirstName = reader["FirstName"].ToString();
                            db.LastName = reader["LastName"].ToString();
                            db.BirthDate = reader["BirthDate"].ToString();
                            db.IdGender = Convert.ToInt32(reader["IdGender"]);
                            db.Address = reader["Address"].ToString();
                            db.ContactNumber = reader["ContactNumber"].ToString();
                            db.Active = Convert.ToBoolean(reader["Active"]);
                            list.Add(db);
                        }
                        data = list;
                    }
                    return data;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePatient(int PatientID)
        {
            try
            {
                using (var sqlcn = new SqlConnection(ConnectionString))
                {
                    await sqlcn.OpenAsync();

                    string query = "DELETE [dbo].[Patient] " +
                        "WHERE PatientID = @PatientID";

                    SqlCommand cmd = new SqlCommand(query, sqlcn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@PatientID", PatientID));
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DetailPatientModel> list = new List<DetailPatientModel>();

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using Crud_Operation.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Operation.RepositoryLayer
{
    public class CRudOperationRL : ICrudOperationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        public CRudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]);

        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "successful";
            try
            {
                string SqlQuery = "Insert Into CrudOperationTable(UserName,Age) values(@UserName,@Age)";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery,_sqlConnection))

                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;//if we pass store procedure in write storeprocedure instead of text
                    sqlCommand.CommandTimeout = 180;   
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status<=0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went Wrong";
                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            response.IsSucess = true;
            response.Message = "Sucessful";

            try
            {
                string SqlQuery = "Delete from CrudOperationTable where Id=@Id";
                using(SqlCommand sqlCommand=new SqlCommand(SqlQuery,_sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status<=0)
                    {
                        response.IsSucess = false;
                        response.Message = "Something Went Wrong"; 
                    }
                }
            }catch(Exception ex)
            {
                response.IsSucess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse() ;
            response.IsSuccess = true;
            response.Message = "successful";
            try
            {
                string SqlQuery = "Select Username,Age from CrudOpertionTable;";
                using (SqlCommand sqlCommand=new SqlCommand(SqlQuery,_sqlConnection))
                { 
                    sqlCommand.CommandType= System.Data.CommandType.Text;
                     sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readRecordData = new List<ReadRecordData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.UserName = sqlDataReader["UserName"] != DBNull.Value ? sqlDataReader["UserName"].ToString() : string.Empty;
                                dbData.Age = sqlDataReader["Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["Age"]):0;
                                response.readRecordData.Add(dbData);


                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse();

            response.IsSuccess = true;
            response.Message = "successful";
            try
            {
                string SqlQuery = "Update CrudOperationTable Set Username=@UserName,Age=@Age where Id=@Id";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                    }



                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

    }
}

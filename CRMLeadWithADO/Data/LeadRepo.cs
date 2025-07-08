using System.Collections.Generic;
using System.Data;
using CRMLeadWithADO.Models;
using Microsoft.Data.SqlClient;

namespace CRMLeadWithADO.Data
{
    public class LeadRepo
    {
        private SqlConnection _connection;

        public LeadRepo()
        {
            string ConStr = "Data Source=;Initial Catalog=;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            _connection = new SqlConnection(ConStr);
        }


        // Read the data
        public List<LeadsEntity> GetAllLeads() 
        { 
            List<LeadsEntity> list = new List<LeadsEntity>();

            SqlCommand sqlCommand = new SqlCommand("dummyGetAllLeads", _connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new LeadsEntity
                {
                    Id = Convert.ToInt32(dr["id"]),
                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                    Name = dr["Name"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    LeadSource = dr["LeadSource"].ToString(),
                    LeadStatus = dr["LeadStatus"].ToString(),
                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"]),


                });
            }
            return list;
        }

        // creating the data 
        public bool AddLead(LeadsEntity leads)
        {
            SqlCommand sqlCommand = new SqlCommand("dummyCreateLeads", _connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", leads.Id);
            sqlCommand.Parameters.AddWithValue("@LeadDate", leads.LeadDate);
            sqlCommand.Parameters.AddWithValue("@Name", leads.Name);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", leads.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@Mobile", leads.Mobile);
            sqlCommand.Parameters.AddWithValue("@LeadSource", leads.LeadSource);
            sqlCommand.Parameters.AddWithValue("@LeadStatus", leads.LeadStatus);
            sqlCommand.Parameters.AddWithValue("@NextFollowUpDate", leads.NextFollowUpDate);

            _connection.Open();

            int i = sqlCommand.ExecuteNonQuery();
            _connection.Close();

            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;            
            }
        }

        // updating the data using id
        public LeadsEntity GetLeadById(int Id)
        {
            LeadsEntity list = new LeadsEntity();

            SqlCommand sqlCommand = new SqlCommand("dummyGetLeads", _connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param;

            sqlCommand.Parameters.Add(new SqlParameter("@Id", Id));

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                list = new LeadsEntity
                {
                    Id = Convert.ToInt32(dr["id"]),
                    LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                    Name = dr["Name"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    LeadSource = dr["LeadSource"].ToString(),
                    LeadStatus = dr["LeadStatus"].ToString(),
                    NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"]),
                };
            }
            return list;
        }

        public bool EditLeadDetails(int Id, LeadsEntity leads)
        {
            SqlCommand sqlCommand = new SqlCommand("dummyUpdateLeads", _connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", Id);
            sqlCommand.Parameters.AddWithValue("@LeadDate", leads.LeadDate);
            sqlCommand.Parameters.AddWithValue("@Name", leads.Name);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", leads.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@Mobile", leads.Mobile);
            sqlCommand.Parameters.AddWithValue("@LeadSource", leads.LeadSource);
            sqlCommand.Parameters.AddWithValue("@LeadStatus", leads.LeadStatus);
            sqlCommand.Parameters.AddWithValue("@NextFollowUpDate", leads.NextFollowUpDate);

            _connection.Open();

            int i = sqlCommand.ExecuteNonQuery();
            _connection.Close();

            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       

        // Deleting Data
        public bool DeleteLeadDetails(int Id)
        {
            SqlCommand sqlCommand = new SqlCommand("dummyDeleteLeads", _connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", Id);
          
            _connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            _connection.Close();

            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}

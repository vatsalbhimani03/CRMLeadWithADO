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
            string ConStr = "Data Source=;Initial Catalog=Einstein;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            _connection = new SqlConnection(ConStr);
        }

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

    }
}

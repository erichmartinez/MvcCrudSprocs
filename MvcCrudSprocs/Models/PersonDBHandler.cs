using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MvcCrudSprocs.Models
{
    public class PersonDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["PeopleDBConn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddPerson(PersonModel pmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewPerson", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", pmodel.Name);
            cmd.Parameters.AddWithValue("@Address", pmodel.Address);
            cmd.Parameters.AddWithValue("@Phone", pmodel.Phone);
            cmd.Parameters.AddWithValue("@Email", pmodel.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<PersonModel> GetPersonDetails()
        {
            connection();
            List<PersonModel> personlist = new List<PersonModel>();

            SqlCommand cmd = new SqlCommand("GetPersonDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                personlist.Add(
                    new PersonModel
                    {
                        ID = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Address = Convert.ToString(dr["Address"]),
                        Phone = Convert.ToInt32(dr["Phone"]),
                        Email = Convert.ToString(dr["Email"])
                    });
            }
            return personlist;
        }

        public bool UpdateDetails(PersonModel pmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdatePersonDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", pmodel.ID);
            cmd.Parameters.AddWithValue("@Name", pmodel.Name);
            cmd.Parameters.AddWithValue("@Address", pmodel.Address);
            cmd.Parameters.AddWithValue("@Phone", pmodel.Phone);
            cmd.Parameters.AddWithValue("@Email", pmodel.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeletePerson(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeletePerson", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
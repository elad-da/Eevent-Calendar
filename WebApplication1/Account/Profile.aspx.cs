using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace WebApplication1.Account
{
    public partial class Profile : System.Web.UI.Page
    {

        //Private method for Binding The Data
        private void BindData()
        { 
            DataTable dt = new DataTable();
            String str = User.Identity.Name;//Name of the currnt user logged in
            SqlConnection conn = new SqlConnection((ConfigurationManager.ConnectionStrings["ConnectionStringEvent"].ConnectionString));
            conn.Open();
            
            //Select the right culomns of the specific user
            SqlDataAdapter adp = new SqlDataAdapter("SELECT EventType,EventDate FROM EventTable WHERE EventUser = '" + str + "' ",conn);
            adp.Fill(dt);

            //Binding Data
            if(dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            conn.Close();
        }
       
        //Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData(); //Bind Data when page load
        }

        //Row Deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection conn = new SqlConnection((ConfigurationManager.ConnectionStrings["ConnectionStringEvent"].ConnectionString));
            conn.Open();
            String str = User.Identity.Name; //Name of the currnt user logged in
            int i = e.RowIndex; //Row Index
            SqlCommand com = new SqlCommand("SELECT * FROM EventTable WHERE EventUser = '" + str + "' ", conn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            String eid = dt.Rows[i].ItemArray[0].ToString(); // Getting the Event Id
            
            //Delte Query
            string sqlDelete = "Delete from EventTable where EventId = @eid";
            SqlCommand cmd = new SqlCommand(sqlDelete,conn);
            
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.ExecuteNonQuery();
            Response.Redirect("Profile.aspx");// Refresh
            conn.Close();
        }

        //Row Editing
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.PageIndex = e.NewEditIndex; //Update Rows
            BindData();
        }

        //Row Updating
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection conn = new SqlConnection((ConfigurationManager.ConnectionStrings["ConnectionStringEvent"].ConnectionString));
            conn.Open();
            String str = User.Identity.Name; //Name of the currnt user logged in
            int i = e.RowIndex; // Row Index
            SqlCommand com = new SqlCommand("SELECT * FROM EventTable WHERE EventUser = '" + str + "' ", conn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            String eid = dt.Rows[i].ItemArray[0].ToString();
            

            GridViewRow row = GridView1.Rows[e.RowIndex];
            //Update Query
            string query = "UPDATE EventTable SET EventType= '" + ((TextBox)(row.Cells[1].Controls[0])).Text + "', EventDate= '" + ((TextBox)(row.Cells[2].Controls[0])).Text + "' WHERE EventId = '" + eid + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            GridView1.EditIndex = -1; //Update Rows
            BindData();
        }

        //Row Cancel Editing
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1; //Update Rows
            BindData();
        }
    }
}
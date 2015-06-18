using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Web;

namespace WebApplication1.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];   
        }
        
        //Create New User
        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            
            //SqlConnection conn = new SqlConnection((ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            //conn.Open();

            //String insertQuery = "insert into Users (FirstName, LastName, BirthDay) values (@first, @last, @birth)";
            //SqlCommand comm = new SqlCommand(insertQuery, conn);
            //comm.Parameters.AddWithValue("@first", FirstName.Text);
            //comm.Parameters.AddWithValue("@last", LastName.Text);
            //comm.Parameters.AddWithValue("@birth", TextBoxDate.Text);

            //comm.ExecuteNonQuery();

            //Response.Redirect("Profile.aspx");
            //conn.Close();

            Response.Redirect("Profile.aspx");//Redirect to profile page after register
        }

    }
}
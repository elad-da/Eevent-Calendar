using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Web;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Data;
using System.Net.Mail;
using System.Net;


namespace WebApplication1.Account
{
    public partial class ManageEvent : System.Web.UI.Page
    {
        //Sending Email
        private void sendEmail(String email, String type , String date)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("mymailid@gmail.com");
            msg.To.Add(email);
            msg.Subject = "New Event";
            msg.Body = "You have new Event: " + type + " On the " + date;//Body message

            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("Eladzada1988@gmail.com", "elad7717");//From
                client.Host = "smtp.gmail.com";//Server
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }
        }


        //Return User ID
        private String getId()
        {
            SqlConnection conn = new SqlConnection((ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            conn.Open();
            String str = User.Identity.Name; //Name of the currnt user logged in
            SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE UserName = '" + str + "' ", conn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            String eid = dt.Rows[0].ItemArray[1].ToString(); // Getting the Event Id
            conn.Close();

            return eid;
        }

        //for sending email
        private String getEmail()
        {
            string email;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand com = new SqlCommand("SELECT * from Memberships WHERE UserId = '" + getId() + "' ", conn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "Memberships");

            email = ds.Tables["Memberships"].Rows[0]["Email"].ToString(); //Getting the Email address
            conn.Close();
            return email;
        }

        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //Submit Button
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            //Case: If event choosen from the drop down list
            if (!(DropDownList.SelectedItem.Text == "Other...") && TextBoxOther.Text =="")
            {
                lableOtherChose.Visible = false;
                sendEmail(getEmail(), DropDownList.SelectedItem.Text, TextBoxDate.Text);//Sending Email for new event
                insertData(DropDownList.SelectedItem.Text); //Insert data to DB
                
            }
                
            //Case: Try to insert new event not from the list and didnt choose other.
            if (!(DropDownList.SelectedItem.Text == "Other...") && !(TextBoxOther.Text == ""))
            {
                lableOtherChose.Text = "You can fill this field only if option other is chosen in the list.";
                lableOtherChose.Visible = true;
            }
                
            //Case: if other event choosen
            if ((DropDownList.SelectedItem.Text == "Other..."))
            {
                lableOtherChose.Visible = false;
                if(TextBoxOther.Text == "")
                {
                    lableOtherChose.Text = "Please fill other event.";
                    lableOtherChose.Visible = true;
                }
                else
                {
                    sendEmail(getEmail(), TextBoxOther.Text, TextBoxDate.Text);//Sending Email for new event
                    insertData(TextBoxOther.Text);//insert data to the DB     
                }   
            }

        }

        //Private method to insert new event
        private void insertData(String type)
        {
            String str = User.Identity.Name;//Name of the currnet user logged in.
            conn = new SqlConnection((ConfigurationManager.ConnectionStrings["ConnectionStringEvent"].ConnectionString));
            conn.Open();

            String insertQuery = "insert into EventTable (EventId, EventType, EventDate, EventUser) values (@id, @type, @date, @user)";
            SqlCommand comm = new SqlCommand(insertQuery, conn);
            //insert by values
            comm.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());//ID - guid
            comm.Parameters.AddWithValue("@type", type);
            comm.Parameters.AddWithValue("@date", TextBoxDate.Text);
            comm.Parameters.AddWithValue("@user", str);

            comm.ExecuteNonQuery();//Execute

            Response.Redirect("Profile.aspx");
            conn.Close();
        }
    }
}
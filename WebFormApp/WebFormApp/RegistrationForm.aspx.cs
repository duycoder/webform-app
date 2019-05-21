using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigControls();
            if (!IsPostBack)
            {
                this.calWorking.Visible = false;
            }
        }

        void ConfigControls()
        {
            //this.btnRegister.Click += btnRegister_Click;
            this.txtName.TextChanged += txtName_TextChanged;
            this.rdbFemale.CheckedChanged += rdb_CheckedChanged;
            this.txtName.Focus();
            this.btnShowCalWorking.Click += btnShowCalWorking_Click;
            this.calWorking.SelectionChanged += calWorking_SelectionChanged;
        }

        void calWorking_SelectionChanged(object sender, EventArgs e)
        {
            txtCalWorking.Text = calWorking.SelectedDate.ToString("dd/MM/yyyy");
            calWorking.Visible = false;
        }

        void btnShowCalWorking_Click (object sender, EventArgs e)
        {
            this.calWorking.Visible = !this.calWorking.Visible;
        }

        void txtName_TextChanged(object sender, EventArgs e)
        {
            Response.Write("FUCKER");
        }

        void btnRegister_Click(object sender, EventArgs e)
        {
            ////Response.Write("Hello My Name is Duy");

            //if (rdbFemale.Checked)
            //{
            //    Response.Write("You're female");
            //}
            //else
            //{
            //    //Response.Write(
            //}
        }

        void rdb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            Response.Write("YOU CHOOSE "+btn.Text);
        }
    }
}
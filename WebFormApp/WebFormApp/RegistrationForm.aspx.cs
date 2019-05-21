using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["TaskManager"].ConnectionString;

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                this.calWorking.Visible = false;
            }
            this.ConfigControls();
        }

        void LoadData()
        {
            //dropdownlist data
            ListItemCollection data = new ListItemCollection()
            {
                new ListItem(){Value = "1", Text = "Hà Nội"},
                new ListItem(){Value = "2", Text = "Sài Gòn"},
                new ListItem(){Value = "3", Text = "Cần Thơ"},
                new ListItem(){Value = "4", Text = "Đà Nẵng"}
            };
            //ddlCountries.DataSource = data;
            //ddlCountries.DataTextField = "Text";
            //ddlCountries.DataValueField = "Value";
            //ddlCountries.DataBind();



            //using(SqlConnection conn = new SqlConnection(connStr))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM City", conn);
            //    ddlCountries.DataSource = cmd.ExecuteReader();
            //    ddlCountries.DataValueField = "Id";
            //    ddlCountries.DataTextField = "Name";
            //    ddlCountries.DataBind();
            //}

            //DataSet ds = new DataSet();
            //ds.ReadXml(Server.MapPath("/Resources/Data/City.xml"));
            //ddlCities.DataSource = ds;
            //ddlCities.DataValueField = "Id";
            //ddlCities.DataTextField = "Name";
            //ddlCities.DataBind();

            //ListItem li = new ListItem("--- Chọn ---", "-1");
            //ddlCities.Items.Insert(0, li);


            //get countries
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("spGetCountries", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);

                ddlCountries.DataSource = ds;
                ddlCountries.DataValueField = "Id";
                ddlCountries.DataTextField = "Name";
                ddlCountries.DataBind();

                ListItem li = new ListItem("--- Chọn ---", "-1");
                ddlCountries.Items.Insert(0, li);
            }
        }

        void ConfigControls()
        {
            this.rdbMale.CheckedChanged += rdb_CheckedChange;
            this.ckbCSharp.CheckedChanged += ckb_CheckedChange;
            this.ckbCSharp.Focus();
            this.ckbJavaScript.Checked = true;
            this.hlPersonal.Focus();


            this.btnSubmit.Command += btnSubmit_Command;
            this.btnSubmit.Click += new EventHandler(btnSubmit_Click);
            this.btnSubmit.CommandName = "submit";
            this.btnSubmit.CommandArgument = int.MaxValue.ToString();

            this.ddlCities.Enabled = false;

            this.ddlCountries.AutoPostBack = true;
            this.ddlCountries.SelectedIndexChanged += ddlCountries_SelectedIndexChanged;

            this.cbSelectAll.CheckedChanged += cbSelectAll_CheckedChanged;
            this.cbSelectAll.AutoPostBack = true;

            this.cbRealTimeFC.SelectedIndexChanged += cbRealTimeFC_SelectedIndexChanged;
            this.cbRealTimeFC.AutoPostBack = true;
            //this.btnRegister.Click += btnRegister_Click;
            //this.txtName.TextChanged += txtName_TextChanged;
            //this.rdbFemale.CheckedChanged += rdb_CheckedChanged;
            this.txtName.Focus();
            this.btnShowCalWorking.Click += btnShowCalWorking_Click;
            this.calWorking.SelectionChanged += calWorking_SelectionChanged;
        }

        void calWorking_SelectionChanged(object sender, EventArgs e)
        {
            txtCalWorking.Text = calWorking.SelectedDate.ToString("dd/MM/yyyy");
            calWorking.Visible = false;
        }

        void btnShowCalWorking_Click(object sender, EventArgs e)
        {
            this.calWorking.Visible = !this.calWorking.Visible;
        }

        void cbRealTimeFC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList comp = (CheckBoxList)sender;
            ListItem temp = null;
            foreach (ListItem item in comp.Items)
            {
                temp = new ListItem(item.Text, item.Value);
                if (item.Selected)
                {
                    if (!lbRealTimeFC.Items.Contains(temp))
                    {
                        lbRealTimeFC.Items.Add(temp);
                    }
                }
                else
                {
                    if (lbRealTimeFC.Items.Contains(temp))
                    {
                        lbRealTimeFC.Items.Remove(temp);
                    }
                }
                temp = null;
            }
        }

        void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            var currentCheckbox = (CheckBox)sender;
            foreach (ListItem item in cblClub.Items)
            {
                item.Selected = currentCheckbox.Checked;
            }
        }

        void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = (sender as DropDownList).SelectedValue;
            if (selectedValue == "-1")
            {
                this.ddlCities.Items.Clear();
                this.ddlCities.Enabled = false;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spGetCitiesByCountryId", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add(new SqlParameter("@countryId", selectedValue));

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    ddlCities.DataSource = ds;
                    ddlCities.DataValueField = "Id";
                    ddlCities.DataTextField = "Name";
                    ddlCities.DataBind();

                    ListItem li = new ListItem("--- Chọn ---", "-1");
                    ddlCities.Items.Insert(0, li);
                    ddlCities.Enabled = true;
                }
            }
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Write("btnSubmit_Click <br/>");
            Response.Write($"The City is <b>{ddlCountries.SelectedItem.Text}</b><br/>");

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (ListItem item in cblClub.Items)
            {

                if (item.Selected)
                {
                    sb.Append("<li>" + item.Text + "</li>");
                }
            }
            sb.Append("</ul>");
            Response.Write($"{sb.ToString()}<br/>");

            if (lbRapper.SelectionMode == ListSelectionMode.Single)
            {
                Response.Write($"ListBox Selected Item is: <b>{lbRapper.SelectedItem?.Text ?? string.Empty}</b><br/>");
            }
            else
            {
                sb.Clear();
                sb.Append("<ul>");
                foreach (ListItem item in lbRapper.Items)
                {
                    if (item.Selected)
                    {
                        sb.Append("<li>" + item.Text + "</li>");
                    }
                }
                sb.Append("</ul>");
                Response.Write($"{sb.ToString()}<br/>");
            }

            Response.Write($"Radio selected is <b>{rblBestNbaPlayer.SelectedItem?.Text}</b> <br/>");
            rblBestNbaPlayer.SelectedIndex = -1;

            /*
             * Config file 
             */
            int fileSize = fuAvatar.PostedFile.ContentLength;
            if (fileSize > 2097152)
            {
                return;
            }
            /*
             * Lưu file
             */
            string directoryPath = Server.MapPath("~/Resources/Images/Uploaded");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (fuAvatar.HasFile)
            {
                fuAvatar.SaveAs($"{directoryPath}/{fuAvatar.FileName}");
            }
        }

        void rdb_CheckedChange(object sender, EventArgs e)
        {
            Response.Write("YOU'RE CHECKED <br/>");
        }

        void ckb_CheckedChange(object sender, EventArgs e)
        {
            Response.Write("YOU'RE SELECTED <br/>");
        }

        void btnSubmit_Command(object sender, CommandEventArgs e)
        {
            Response.Write("YOU 'RE COMMANDED <br/>");
            Response.Write($"The Argument is <b>{e.CommandArgument}</b> <br/>");
            Response.Write($"The Name  is <b>{e.CommandName}</b> <br/>");
        }
    }
}
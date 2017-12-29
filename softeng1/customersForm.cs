﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace softeng1
{
    public partial class customersForm : Form
    {
        MySqlConnection conn;
        public customersForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
        }
        public static homeForm fromCustomer { get; set; }

        private void customersForm_Load(object sender, EventArgs e)
        {
            editBtn.Enabled = false;
            loadCustomerData();
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            fromCustomer.Show();
        }
        private void customersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromCustomer.Show();
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            fromCustomer.Show();
            this.Hide();
        }

        private void customersForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromCustomer.Show();
        }

        public void loadCustomerData()
        {
            String query = "SELECT * FROM PERSON, CUSTOMER WHERE PERSON.PERSON_TYPE = 'CUSTOMER' AND CUSTOMER_PERSON_ID = PERSON_ID";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            custData.DataSource = dt;
            custData.Columns["customer_id"].Visible = false;
            custData.Columns["person_id"].Visible = false;
            custData.Columns["person_type"].Visible = false;
            custData.Columns["customer_person_id"].Visible = false;
            custData.Columns["gender"].Visible = false;
            custData.Columns["firstname"].HeaderText = "Firstname";
            custData.Columns["lastname"].HeaderText = "Lastname";
            custData.Columns["contact_num"].HeaderText = "Contact Number";
            custData.Columns["address"].HeaderText = "Address";
            custData.Columns["email"].HeaderText = "Email";
        }

        private int selected_cust_id;
        private int selected_person_id;
        private void custData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            if (e.RowIndex > -1)
            {
                selected_cust_id = int.Parse(custData.Rows[e.RowIndex].Cells["customer_id"].Value.ToString());
                selected_person_id = int.Parse(custData.Rows[e.RowIndex].Cells["person_id"].Value.ToString());
                fnameTxt.Text = custData.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                lnameTxt.Text = custData.Rows[e.RowIndex].Cells["lastname"].Value.ToString();          
                emailTxt.Text = custData.Rows[e.RowIndex].Cells["email"].Value.ToString();
                addressTxt.Text = custData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                cnumTxt.Text = custData.Rows[e.RowIndex].Cells["contact_num"].Value.ToString();
                int gen = int.Parse(custData.Rows[e.RowIndex].Cells["gender"].Value.ToString());
                if (gen == 1)
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (fnameTxt.Text == "" || lnameTxt.Text == "" || emailTxt.Text == "" || cnumTxt.Text == "" || addressTxt.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Employee Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int gen = 0;

                if (rbMale.Checked == true)
                {
                    gen = 1;
                }
                else if (rbFemale.Checked == true)
                {
                    gen = 0;
                }
                string query = "INSERT INTO PERSON(FIRSTNAME, LASTNAME, CONTACT_NUM, EMAIL, ADDRESS, GENDER, PERSON_TYPE)" +
                    "VALUES ('" + fnameTxt.Text + "','" + lnameTxt.Text + "','" + cnumTxt.Text + "','" + emailTxt.Text + "','" + addressTxt.Text + "','" + gen + "','Customer')";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                loadCustomerData();

                fnameTxt.Text = "";
                lnameTxt.Text = "";
                emailTxt.Text = "";
                cnumTxt.Text = "";
                addressTxt.Text = "";
                rbMale.Checked = true;
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            fnameTxt.Text = "";
            lnameTxt.Text = "";
            emailTxt.Text = "";
            cnumTxt.Text = "";
            addressTxt.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            int gen = 0;

            if (rbMale.Checked == true)
            {
                gen = 1;
            }
            else if (rbFemale.Checked == true)
            {
                gen = 0;
            }
            String query = "Update PERSON, CUSTOMER SET PERSON.FIRSTNAME = '" + fnameTxt.Text + "', PERSON.LASTNAME = '" + lnameTxt.Text + "', PERSON.GENDER = '" + gen +  "', PERSON.CONTACT_NUM = '" + cnumTxt.Text + "', PERSON.EMAIL = '" + emailTxt.Text + "', PERSON.ADDRESS ='" + addressTxt.Text + "' WHERE CUSTOMER_ID = '" + selected_cust_id + "' AND PERSON_ID = '" + selected_person_id + "'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            loadCustomerData();
        }
    }
}

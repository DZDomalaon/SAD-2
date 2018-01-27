using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace softeng1
{
    public partial class orderForm : Form
    {
        MySqlConnection conn;
        public orderForm()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=glaciers; uid = root; pwd = root");
            InitializeComponent();
        }
        public static int customer_id, rowIndex, product_id, inv_id, availableStock, quan;
        public static String prod, price, ln, fn;
        public static double tot, p, q;

        public static homeForm fromOrder { get; set; }
        private void backBtn_Click(object sender, EventArgs e)
        {
            fromOrder.Show();
            this.Hide();
        }

        private void orderForm_Load(object sender, EventArgs e)
        {
            usernameLbl.Text = loginForm.name;
            dateLbl.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");

            buyPanel.Visible = false;
            stockLbl.Visible = false;
            loadCustomer();
            loadProduct();
        }
     

        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }
        
        //AutoComplete for customer
        public void loadCustomer()
        {
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();

            conn.Open();

            String query = "SELECT firstname, lastname FROM person, customer where (lastname like '%" + custnameTxt.Text + "%' or firstname like '%" + custnameTxt.Text + "%') and person_type = 'customer' and person_id = customer_person_id ";
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    namesCollection.Add(drd["firstname"].ToString() + " " + drd["lastname"].ToString());
            }

            drd.Close();
            conn.Close();

            custnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            custnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            custnameTxt.AutoCompleteCustomSource = namesCollection;
        }
        
        //AutoComplete for product
        public void loadProduct()
        {
            AutoCompleteStringCollection productsCollection = new AutoCompleteStringCollection();

            conn.Open();

            String query = "SELECT PRODUCT_NAME FROM PRODUCT";
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                    productsCollection.Add(drd["PRODUCT_NAME"].ToString());
            }

            drd.Close();
            conn.Close();

            productnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            productnameTxt.AutoCompleteCustomSource = productsCollection;
        }

        public static int quant;
        private void pquant_TextChanged(object sender, EventArgs e)
        {
            if (pquant.Text != "")
            {
                quant = int.Parse(pquant.Text);
                p = double.Parse(ppriceTxt.Text);
                q = quant;
                tot = q * p;
                ptotal.Text = tot.ToString("#,0.00");
            }
            else if (pquant.Text == "")
            {
                ptotal.Text = "";
            }
        }
        //Search for product
        private void dgsearchprod_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
                stockLbl.Visible = true;
                stockLbl.Text = "The available stock is only " + quan;
            
        }
        //Search for customer
        

        private void orderForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            buyPanel.Visible = true;
            buyPanel.Enabled = true;
            BuydateLbl.Text = DateTime.Now.Date.ToString("MM-dd-yyyy");
        }


        //pass all data from Datagridview to textboxes
        private void orderDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex; 
            DataGridViewRow row = orderDG.Rows[rowIndex];

            productnameTxt.Text = row.Cells[0].Value.ToString();
            ppriceTxt.Text = row.Cells[1].Value.ToString();            
            ptotal.Text = row.Cells[2].Value.ToString();
            pquant.Text = row.Cells[3].Value.ToString();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int maxOrderId = 0;
            int OrderIncrement = 0;
            int maxPaymentId = 0;
            int PaymentInc = 0;
            int prod_id = 0;

            conn.Open();
            //Get max id from sale_order
            MySqlCommand query = new MySqlCommand("SELECT MAX(order_id) FROM SALES_ORDER", conn);
            maxOrderId = Convert.ToInt16(query.ExecuteScalar());
            OrderIncrement = maxOrderId + 1;            

            //Get max id fron payment
            MySqlCommand query2 = new MySqlCommand("SELECT MAX(payment_id) FROM payment", conn);
            maxPaymentId = Convert.ToInt16(query2.ExecuteScalar());
            PaymentInc = maxPaymentId;
            conn.Close();

            //Insert data to sales_order
            double total = double.Parse(totalpriceTxt.Text.ToString());
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                conn.Open();
                //Get all product id
                MySqlCommand getProduct_id = new MySqlCommand("SELECT PRODUCT_ID FROM PRODUCT WHERE (PRODUCT_NAME LIKE'%" + row.Cells[0].Value + "%' AND PRICE LIKE '%" + row.Cells[1].Value + "%')", conn);
                prod_id = Convert.ToInt32(getProduct_id.ExecuteScalar());

                using (conn)
                {
                    if (paymentCmb.Text == "Cash")
                    {
                        if(int.Parse(cashTxt.Text.ToString()) >= total)
                        {                            
                            //insert payment amount
                            String insertToPayment = "INSERT INTO PAYMENT(AMOUNT) VALUES('" + cashTxt.Text + "')";
                            MySqlCommand comm = new MySqlCommand(insertToPayment, conn);
                            comm.ExecuteNonQuery();

                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO sales_order(order_id,ORDER_price, order_subtotal, order_total, order_subquantity, order_tquantity, order_date, order_status, order_customer_id, order_emp_id, order_payment_id, order_product_id) VALUES('" + OrderIncrement + "', @Price, @Subtotal, '" + total + "', @Quantity, '" + totalQuanatity() + "', '" + BuydateLbl.Text + "', 'Paid', '" + customer_id + "', '" + loginForm.user_id + "', '" + PaymentInc + "', '" + prod_id + "')", conn))
                            {

                                cmd.Parameters.AddWithValue("@Price", double.Parse(row.Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                                cmd.Parameters.AddWithValue("@Subtotal", double.Parse(row.Cells[2].Value.ToString()));
                                cmd.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[3].Value.ToString()));
                                cmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Records inserted.");
                        }
                        else if(int.Parse(cashTxt.Text.ToString()) < total)
                        {
                            MessageBox.Show("Cash amount is not enough", "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                    else if(paymentCmb.Text == "Credit")
                    {
                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO sales_order(order_id,ORDER_price, order_subtotal, order_total, order_subquantity, order_tquantity, order_date, order_status, order_customer_id, order_emp_id, order_payment_id, order_product_id) VALUES('" + OrderIncrement + "', @Price, @Subtotal, '" + total + "', @Quantity, '" + totalQuanatity() + "', '" + dateLbl.Text + "', 'Unpaid', '" + customer_id + "', '" + loginForm.user_id + "', '" + PaymentInc + "', '" + prod_id + "')", conn))
                        {

                            cmd.Parameters.AddWithValue("@Price", double.Parse(row.Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                            cmd.Parameters.AddWithValue("@Subtotal", double.Parse(row.Cells[2].Value.ToString()));
                            cmd.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[3].Value.ToString()));
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Records inserted.");
                    }
                    
                }
                conn.Close();
            }            
        }

        private void paymentCmb_TextChanged(object sender, EventArgs e)
        {
            if (paymentCmb.Text == "Cash")
            {
                cashTxt.Enabled = true;
                discountTxt.Enabled = true;
                interestTxt.Enabled = false;
            }
            else if (paymentCmb.Text == "Credit")
            {
                cashTxt.Enabled = false;
                discountTxt.Enabled = false;
                interestTxt.Enabled = true;
            }
        }

        private void buyBackBtn_Click(object sender, EventArgs e)
        {
            buyPanel.Hide();
        }

        //update the values of data from Datagrid
        private void editOrderBtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow updRow = orderDG.Rows[rowIndex];

            updRow.Cells[0].Value = productnameTxt.Text;
            updRow.Cells[1].Value = ppriceTxt.Text;
            updRow.Cells[2].Value = pquant.Text;
            updRow.Cells[3].Value = ptotal.Text;
            calcSum();
        }
        //Add order to Datagrid
        private void addOrder_Click(object sender, EventArgs e)
        {
             if (custnameTxt.Text == "" || productnameTxt.Text == "" || ppriceTxt.Text == "" || pquant.Text == "" || ptotal.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Add Customer Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                MySqlCommand getQuantity = new MySqlCommand("select quantity from inventory where inventory_id ='" + inv_id + "'", conn);
                availableStock = Convert.ToInt32(getQuantity.ExecuteScalar());
                conn.Close();


                if(availableStock >= int.Parse(pquant.Text.ToString()))
                {
                    string firstColumn = productnameTxt.Text;
                    string secondColumn = ppriceTxt.Text;
                    string thirdColumn = ptotal.Text;
                    string fourthColumn = pquant.Text;
                    string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn };

                    orderDG.Rows.Add(row);

                    productnameTxt.Clear();
                    ppriceTxt.Clear();
                    pquant.Clear();
                    ptotal.Clear();
                    paymentCmb.Text = "";
                    calcSum();

                    stockLbl.Visible = false;
                }
                else
                {
                    MessageBox.Show("The available stock is only " + availableStock, "Not enough stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //Remove the selected row
        private void removeOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.orderDG.SelectedRows)
            {
                orderDG.Rows.RemoveAt(item.Index);
                calcSum();
            }
        }
        //Calculate the total price
        private void calcSum()
        {
            double a = 0, b = 0;
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                a = Convert.ToDouble(row.Cells[2].Value);
                b = b + a;
            }
            totalpriceTxt.Text = b.ToString("#,0.00");
        }
        //Calculate the total quantity
        private int totalQuanatity()
        {
            int a = 0, b = 0;
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                a = int.Parse(row.Cells[3].Value.ToString());
                b = b + a;
            }
            return b;
        }

    }
}

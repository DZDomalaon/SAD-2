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
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Globalization;

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
        public static int customer_id, rowIndex, product_id, availableStock, quan, countProduct, countCustomer, quant;
        public static String prod, price, ln, fn, getPrice;
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

            errorPanel.Visible = false;           
            buyPanel.Visible = false;
            stockLbl.Visible = false;
            custLbl.Visible = false;
            addOrder.Enabled = true;
            editOrderBtn.Enabled = false;

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

            String getCustomer = "SELECT firstname, lastname FROM person, customer where (lastname like '%" + custnameTxt.Text + "%' or firstname like '%" + custnameTxt.Text + "%') and person_type = 'customer' and person_id = customer_person_id ";
            MySqlCommand comm = new MySqlCommand(getCustomer, conn);
            comm.CommandText = getCustomer;
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

            String getProduct = "SELECT PRODUCT_NAME, PRICE FROM PRODUCT";
            MySqlCommand comm = new MySqlCommand(getProduct, conn);
            comm.CommandText = getProduct;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                {
                    productsCollection.Add(drd["PRODUCT_NAME"].ToString());
                }                                        
            }

            drd.Close();            
            conn.Close();            

            productnameTxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productnameTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            productnameTxt.AutoCompleteCustomSource = productsCollection;
        }
        
        //Load product price
        public void productPrice()
        {
            conn.Open();

            String getPrice = "SELECT PRICE FROM PRODUCT WHERE PRODUCT_NAME = '" + productnameTxt.Text +"'";
            MySqlCommand comm = new MySqlCommand(getPrice, conn);
            comm.CommandText = getPrice;
            MySqlDataReader drd = comm.ExecuteReader();

            if (drd.HasRows == true)
            {
                while (drd.Read())
                {
                    ppriceTxt.Text = drd["PRICE"].ToString();
                }                                   
            }

            drd.Close();
            conn.Close();


        }

        //Check product quantity
        public void productQuantity()
        {
            conn.Open();

            MySqlCommand getQuantity = new MySqlCommand("select quantity from inventory, product where product_name = '" + productnameTxt.Text + "' and inventory_id = product_inv_id", conn);
            availableStock = Convert.ToInt32(getQuantity.ExecuteScalar());

            conn.Close();

            stockLbl.Visible = true;
            stockLbl.Text = "The available stock is only " + availableStock;
        }

        //calculate quantity * price
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

        //filter for customer
        public void checkCustomer()
        {
            conn.Close();
            conn.Open();

            MySqlCommand getCustomer = new MySqlCommand("SELECT COUNT(*) FROM PERSON, CUSTOMER WHERE CONCAT(FIRSTNAME, ' ', LASTNAME) = '" + custnameTxt.Text + "' AND PERSON_TYPE = 'CUSTOMER' AND PERSON_ID = CUSTOMER_PERSON_ID", conn);
            countCustomer = Convert.ToInt16(getCustomer.ExecuteScalar());

            conn.Close();

            if (custnameTxt.Text == "" || countCustomer == 0)
            {
                custLbl.Visible = true;
                this.custLbl.ForeColor = Color.Red;
                custLbl.Text = "This customer is not recognized.";
            }
            else
            {
                custLbl.Visible = true;
                this.custLbl.ForeColor = Color.Green;
                custLbl.Text = "Customer found";
            }
        }

        private void cashTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(cashTxt.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void closePanel_Click(object sender, EventArgs e)
        {
            errorPanel.Hide();           
        }

        private void custnameTxt_TextChanged(object sender, EventArgs e)
        {
            checkCustomer();
            
            if(custnameTxt.Text == "")
            {
                custLbl.Visible = false;
            }
        }

        //Filter for productnameTxt
        private void productnameTxt_TextChanged(object sender, EventArgs e)
        {           
            conn.Open();
            MySqlCommand getProduct = new MySqlCommand("SELECT COUNT(*) FROM PRODUCT WHERE PRODUCT_NAME = '" + productnameTxt.Text + "'", conn);
            countProduct = Convert.ToInt16(getProduct.ExecuteScalar());
            conn.Close();
            
            if (productnameTxt.Text == "" || countProduct == 0)
            {
                ppriceTxt.Clear();
                pquant.Clear();
                ptotal.Clear();
                stockLbl.Visible = false;
            }
            else
            {
                productPrice();
                productQuantity();
            }            
        }

        private void orderForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            fromOrder.Show();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            if (orderDG.Rows.Count == 0)
            {
                errorPanel.Visible = true;
                errorPanel.Enabled = true;
                errorPanel.Location = new Point(269, 185);
            }
            else
            {
                buyPanel.Visible = true;
                buyPanel.Enabled = true;
                BuydateLbl.Text = DateTime.Now.Date.ToString("yyyy/MM/dd");

                DateTime theDate = DateTime.Now;
                
                MessageBox.Show(theDate.ToString("yyyy-MM-dd"));
            }
                
        }
        //pass all data from Datagridview to textboxes
        private void orderDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addOrder.Enabled = false;
            editOrderBtn.Enabled = true;
            rowIndex = e.RowIndex; 
            DataGridViewRow row = orderDG.Rows[rowIndex];

            productnameTxt.Text = row.Cells[0].Value.ToString();
            ppriceTxt.Text = row.Cells[1].Value.ToString();            
            ptotal.Text = row.Cells[2].Value.ToString();
            pquant.Text = row.Cells[3].Value.ToString();
        }

        //Confirm order
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int maxOrderId = 0;
            int OrderIncrement = 0;
            int maxPaymentId = 0;
            int PaymentInc = 0;
            int prod_id = 0;
            DateTime theDate = DateTime.Now;
            string formatForMySql = theDate.ToString("yyyy-MM-dd");
            double total = double.Parse(totalpriceTxt.Text.ToString());

            conn.Open();

            //Get the id of selected customer
            MySqlCommand getCustomerID = new MySqlCommand("SELECT customer_id FROM customer, person where (CONCAT(FIRSTNAME, ' ', LASTNAME) LIKE '%" + custnameTxt.Text + "%') and person_type = 'customer' and person_id = customer_person_id ", conn);
            customer_id = Convert.ToInt16(getCustomerID.ExecuteScalar());            

            if (paymentCmb.Text == "Cash")
            {
                if (double.Parse(cashTxt.Text.ToString()) >= total)
                {
                    //insert payment amount
                    String insertToPayment = "INSERT INTO PAYMENT(AMOUNT, PAYMENT_DATE, TYPE) VALUES('" + double.Parse(cashTxt.Text.ToString()) + "', '" + formatForMySql + "', 'Cash')";
                    MySqlCommand comm = new MySqlCommand(insertToPayment, conn);
                    comm.ExecuteNonQuery();

                    //Get max id fron payment
                    MySqlCommand maxIDPayment = new MySqlCommand("SELECT MAX(payment_id) FROM payment", conn);
                    maxPaymentId = Convert.ToInt16(maxIDPayment.ExecuteScalar());
                    PaymentInc = maxPaymentId;

                    //Insert data to sales_order                    
                    string insertToSO = "INSERT INTO sales_order(ORDER_DATE, ORDER_WARRANTY, ORDER_STATUS, WARRANTY_STATUS, order_customer_id, order_emp_id, order_payment_id) VALUES('" + formatForMySql + "', '" + formatForMySql + "', 'Paid', 'Valid', '" + customer_id + "', '" + loginForm.user_id + "', '" + PaymentInc + "')";
                    MySqlCommand insertToSOComm = new MySqlCommand(insertToSO, conn);
                    insertToSOComm.ExecuteNonQuery();

                    //Get max id from sales_order
                    MySqlCommand maxIDOrder = new MySqlCommand("SELECT MAX(order_id) FROM SALES_ORDER", conn);
                    maxOrderId = Convert.ToInt16(maxIDOrder.ExecuteScalar());
                    OrderIncrement = maxOrderId;

                    conn.Close();

                    foreach (DataGridViewRow row in orderDG.Rows)
                    {
                        conn.Open();
                        //Get all product id
                        MySqlCommand getProduct_id = new MySqlCommand("SELECT PRODUCT_ID FROM PRODUCT WHERE (PRODUCT_NAME LIKE'%" + row.Cells[0].Value + "%' AND PRICE LIKE '%" + row.Cells[1].Value + "%')", conn);
                        prod_id = Convert.ToInt32(getProduct_id.ExecuteScalar());

                        using (conn)
                        {
                            //insert to database
                            using (MySqlCommand addToSales = new MySqlCommand("INSERT INTO SALES_ORDER_DETAILS(ORDER_PRODUCT_ID, ORDER_UNIT_PRICE, ORDER_SUBTOTAL, ORDER_TOTAL, ORDER_TQUANTITY, ORDER_SUBQUANTITY, SO_ID) VALUES('" + prod_id + "', @Price, @Subtotal, '" + total + "', '" + totalQuanatity() + "', @Quantity, '" + OrderIncrement + "')", conn))
                            {
                                //Get data of price, subtotal, and quatity per row in the datagrid
                                //@Price, @Subtotal, and @Quantity are the names of the columns
                                addToSales.Parameters.AddWithValue("@Price", double.Parse(row.Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                                addToSales.Parameters.AddWithValue("@Subtotal", double.Parse(row.Cells[2].Value.ToString()));
                                addToSales.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[3].Value.ToString()));
                                addToSales.ExecuteNonQuery();
                            }

                            //deduct quantity
                            quan = int.Parse(row.Cells[3].Value.ToString());
                            string deductQuantity = "UPDATE INVENTORY SET QUANTITY = QUANTITY - '" + quan + "' WHERE INVENTORY_ID = (SELECT PRODUCT_INV_ID FROM PRODUCT WHERE PRODUCT_NAME LIKE'%" + row.Cells[0].Value + "%' AND PRICE LIKE '%" + row.Cells[1].Value + "%')";
                            MySqlCommand comm2 = new MySqlCommand(deductQuantity, conn);
                            comm2.ExecuteNonQuery();
                        }
                    }
                    conn.Close();

                    custnameTxt.Clear();
                    buyPanel.Hide();
                    cashTxt.Clear();
                    discountTxt.Clear();
                    paymentCmb.Text = " ";
                    this.orderDG.Rows.Clear();
                    calcSum();
                    MessageBox.Show("Trasaction complete");
                }
                else if (double.Parse(cashTxt.Text.ToString()) < total)
                {
                    MessageBox.Show("Cash amount is not enough", "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                         
            }
            else if (paymentCmb.Text == "Credit")
            {
                //Insert total to balance
                string insertToCustomer = "UPDATE CUSTOMER SET BALANCE = BALANCE + '" + total + "' where CUSTOMER_ID = '" + customer_id + "'";
                MySqlCommand insertToCustomerComm = new MySqlCommand(insertToCustomer, conn);
                insertToCustomerComm.ExecuteNonQuery();

                //insert payment amount
                String insertToPayment = "INSERT INTO PAYMENT(AMOUNT, PAYMENT_DATE, TYPE) VALUES('" + total + "', '" + formatForMySql + "', 'Credit')";
                MySqlCommand comm = new MySqlCommand(insertToPayment, conn);
                comm.ExecuteNonQuery();

                //Get max id fron payment
                MySqlCommand maxIDPayment = new MySqlCommand("SELECT MAX(payment_id) FROM payment", conn);
                maxPaymentId = Convert.ToInt16(maxIDPayment.ExecuteScalar());
                PaymentInc = maxPaymentId;

                //Insert data to sales_order                    
                string insertToSO = "INSERT INTO sales_order(ORDER_DATE, ORDER_WARRANTY, ORDER_STATUS, WARRANTY_STATUS, order_customer_id, order_emp_id, order_payment_id) VALUES('" + formatForMySql + "', '" + formatForMySql + "', 'Unpaid', 'Valid', '" + customer_id + "', '" + loginForm.user_id + "', '" + PaymentInc + "')";
                MySqlCommand insertToSOComm = new MySqlCommand(insertToSO, conn);
                insertToSOComm.ExecuteNonQuery();                

                //Get max id from sales_order
                MySqlCommand maxIDOrder = new MySqlCommand("SELECT MAX(order_id) FROM SALES_ORDER", conn);
                maxOrderId = Convert.ToInt16(maxIDOrder.ExecuteScalar());
                OrderIncrement = maxOrderId;

                conn.Close();

                foreach (DataGridViewRow row in orderDG.Rows)
                {
                    conn.Open();

                    //Get all product id
                    MySqlCommand getProduct_id = new MySqlCommand("SELECT PRODUCT_ID FROM PRODUCT WHERE (PRODUCT_NAME LIKE'%" + row.Cells[0].Value + "%' AND PRICE LIKE '%" + row.Cells[1].Value + "%')", conn);
                    prod_id = Convert.ToInt32(getProduct_id.ExecuteScalar());

                    using (conn)
                    {
                        //insert to database
                        using (MySqlCommand addToSales = new MySqlCommand("INSERT INTO SALES_ORDER_DETAILS(ORDER_PRODUCT_ID, ORDER_UNIT_PRICE, ORDER_SUBTOTAL, ORDER_TOTAL, ORDER_TQUANTITY, ORDER_SUBQUANTITY, SO_ID) VALUES('" + prod_id + "', @Price, @Subtotal, '" + total + "', '" + totalQuanatity() + "', @Quantity, '" + OrderIncrement + "')", conn))
                        {
                            //Get data of price, subtotal, and quatity per row in the datagrid
                            //@Price, @Subtotal, and @Quantity are the names of the columns
                            addToSales.Parameters.AddWithValue("@Price", double.Parse(row.Cells[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture));
                            addToSales.Parameters.AddWithValue("@Subtotal", double.Parse(row.Cells[2].Value.ToString()));
                            addToSales.Parameters.AddWithValue("@Quantity", int.Parse(row.Cells[3].Value.ToString()));
                            addToSales.ExecuteNonQuery();
                        }

                        //deduct quantity
                        quan = int.Parse(row.Cells[3].Value.ToString());
                        string deductQuantity = "UPDATE INVENTORY SET QUANTITY = QUANTITY - '" + quan + "' WHERE INVENTORY_ID = (SELECT PRODUCT_INV_ID FROM PRODUCT WHERE PRODUCT_NAME LIKE'%" + row.Cells[0].Value + "%' AND PRICE LIKE '%" + row.Cells[1].Value + "%')";
                        MySqlCommand comm2 = new MySqlCommand(deductQuantity, conn);
                        comm2.ExecuteNonQuery();
                    }
                }
                conn.Close();

                custnameTxt.Clear();
                buyPanel.Hide();
                cashTxt.Clear();
                discountTxt.Clear();
                paymentCmb.Text = " ";
                this.orderDG.Rows.Clear();
                calcSum();
                MessageBox.Show("Trasaction complete");
            }            
            conn.Close();
        }

        private void buyBackBtn_Click(object sender, EventArgs e)
        {
            buyPanel.Hide();
        }

        //update the values of data from Datagrid
        private void editOrderBtn_Click(object sender, EventArgs e)
        {
            if(productnameTxt.Text == "" && ppriceTxt.Text == "" && pquant.Text == "" && ptotal.Text == "")
            {
                MessageBox.Show("There's no data selected", "Empty textboxes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow updRow = orderDG.Rows[rowIndex];

                updRow.Cells[0].Value = productnameTxt.Text;
                updRow.Cells[1].Value = ppriceTxt.Text;
                updRow.Cells[2].Value = ptotal.Text;
                updRow.Cells[3].Value = pquant.Text;

                productnameTxt.Clear();
                ppriceTxt.Clear();
                pquant.Clear();
                ptotal.Clear();
                addOrder.Enabled = true;
                editOrderBtn.Enabled = false;
            }
            calcSum();
        }

        //Add order to Datagrid
        private void addOrder_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(pquant.Text.ToString());
            double total_price = double.Parse(ptotal.Text.ToString()) / double.Parse(pquant.Text.ToString());

            if (custnameTxt.Text == "" || productnameTxt.Text == "" || ppriceTxt.Text == "" || pquant.Text == "" || ptotal.Text == "")
            {
                MessageBox.Show("Please fill up all the data", "Add Customer Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                MySqlCommand getQuantity = new MySqlCommand("select quantity from inventory, product where product_name = '" + productnameTxt.Text + "' and inventory_id = product_inv_id", conn);
                availableStock = Convert.ToInt32(getQuantity.ExecuteScalar());
                conn.Close();

                if(availableStock >= quantity)
                {
                    for(int i = 0; i < quantity; i++)
                    {
                        string firstColumn = productnameTxt.Text;
                        string secondColumn = ppriceTxt.Text;
                        string thirdColumn = total_price.ToString();
                        string fourthColumn = "1";
                        string[] row = { firstColumn, secondColumn, thirdColumn, fourthColumn };

                        orderDG.Rows.Add(row);
                    }                    

                    productnameTxt.Clear();
                    ppriceTxt.Clear();
                    pquant.Clear();
                    ptotal.Clear();
                    calcSum();

                    editOrderBtn.Enabled = true;
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
            }
            calcSum();
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

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_001340166
{
    public partial class CustomerModScreen : Form
    {
        private string customerModType;
        private Hashtable selectedCustomer;
        public CustomerModScreen(string customerMType)
        {
            InitializeComponent();
            customerModType = customerMType;
            gridView_customer_customers.AutoGenerateColumns = true;
            gridView_customer_customers.DataMember = "Table";
            cbox_customer_add_active.Text = "Yes";
            updateScreen();
        }

        private void updateScreen()
        {
            if (customerModType == "add")
            {
                panel_customer_addCustomerComponents.Visible = true;
                panel_customer_modCustomerComponents.Visible = false;
                this.Size = new Size(432, 318);
                panel_customer_addCustomerComponents.Dock = DockStyle.Fill;
                panel_customer_addCustomerComponents.Size = new Size(432, 318);
            }
            else if (customerModType == "update")
            {
                panel_customer_addCustomerComponents.Visible = false;
                panel_customer_modCustomerComponents.Visible = true;
                this.Size = new Size(823, 428);
                updateCustomerGrid();
            }
            else if (customerModType == "updating") {
                btn_customer_add.Visible = false;
                btn_customer_add_update.Visible = true;
                panel_customer_addCustomerComponents.Visible = true;
                panel_customer_modCustomerComponents.Visible = false;
                this.Size = new Size(432, 318);
                tbox_customer_add_name.Text = selectedCustomer["customerName"].ToString();
                tbox_customer_add_address.Text = selectedCustomer["address"].ToString();
                tbox_customer_add_address2.Text = selectedCustomer["address2"].ToString();
                tbox_customer_add_zip.Text = selectedCustomer["postalCode"].ToString();
                tbox_customer_add_phone.Text = selectedCustomer["phone"].ToString();
                tbox_customer_add_city.Text = selectedCustomer["city"].ToString();
                tbox_customer_add_country.Text = selectedCustomer["country"].ToString();
                if (selectedCustomer["active"].ToString() == "True")
                {
                    cbox_customer_add_active.Text = "Yes";
                }
                else
                {
                    cbox_customer_add_active.Text = "No";
                }
            }
            else if (customerModType == "delete")
            {
                btn_customer_update_update.Visible = false;
                btn_customer_update_delete.Visible = true;
                panel_customer_addCustomerComponents.Visible = false;
                panel_customer_modCustomerComponents.Visible = true;
                this.Size = new Size(823, 428);
                updateCustomerGrid();
            }
        }

        private void updateCustomerGrid() {
            gridView_customer_customers.DataSource = DBConn.getDBDataset("SELECT customer.customerId,customer.customerName,address.address,address.address2,address.postalCode,address.phone,city.city,country.country,customer.active FROM customer INNER JOIN address on customer.addressId = address.addressId INNER JOIN city ON address.addressId = city.cityId INNER JOIN country on city.countryId = country.countryId;");
            foreach (DataGridViewColumn column in gridView_customer_customers.Columns)
            {
                if (column.HeaderText == "userID" || column.HeaderText == "customerId")
                {
                    column.Visible = false;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btn_customer_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_customer_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbox_customer_add_name.Text) || !string.IsNullOrWhiteSpace(tbox_customer_add_phone.Text) ||
                !string.IsNullOrWhiteSpace(tbox_customer_add_address.Text) || !string.IsNullOrWhiteSpace(tbox_customer_add_city.Text) ||
                !string.IsNullOrWhiteSpace(tbox_customer_add_zip.Text) || !string.IsNullOrWhiteSpace(tbox_customer_add_country.Text))
            {
                string time = (DateTime.Now).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
                int country = DBConn.addToTable("country", time, tbox_customer_add_country.Text, -1);
                int city = DBConn.addToTable("city", time, tbox_customer_add_city.Text, country);
                int address = DBConn.addToTable("address", time, $"{tbox_customer_add_address.Text}~{tbox_customer_add_address2.Text}~{tbox_customer_add_zip.Text}~{tbox_customer_add_phone.Text}", city);
                DBConn.addToTable("customer", time, $"{tbox_customer_add_name.Text}~{cbox_customer_add_active.Text}", address);
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields (except 'Address 2') must be filled before adding customer.");
            }
        }

        private void btn_customer_update_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_customer_update_update_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {
                selectedRow = gridView_customer_customers.CurrentRow;
            }
            catch
            {
                MessageBox.Show("No customer was selected.");
                return;
            }
            if (selectedRow == null)
            {
                MessageBox.Show("No customer was selected.");
                return;
            }
            else {
                selectedCustomer = DBConn.dataRowToHashtable(gridView_customer_customers, selectedRow);
            }
            customerModType = "updating";
            updateScreen();
        }

        private void btn_customer_add_update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbox_customer_add_name.Text) || !string.IsNullOrWhiteSpace(tbox_customer_add_phone.Text) ||
                !string.IsNullOrWhiteSpace(tbox_customer_add_address.Text) || !string.IsNullOrWhiteSpace(tbox_customer_add_city.Text) ||
                !string.IsNullOrWhiteSpace(tbox_customer_add_zip.Text) || !string.IsNullOrWhiteSpace(tbox_customer_add_country.Text))
            {
                string time = (DateTime.Now).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
                Hashtable customerInfo = new Hashtable();
                int country = DBConn.addToTable("country", time, tbox_customer_add_country.Text, -1);
                int city = DBConn.addToTable("city", time, tbox_customer_add_city.Text, country);
                int address = DBConn.addToTable("address", time, $"{tbox_customer_add_address.Text}~{tbox_customer_add_address2.Text}~{tbox_customer_add_zip.Text}~{tbox_customer_add_phone.Text}", city);
                customerInfo.Add("CustomerName", tbox_customer_add_name.Text);
                customerInfo.Add("CustomerAddressID", address);
                customerInfo.Add("Time", time);
                customerInfo.Add("CustomerID", selectedCustomer["customerId"]);
                if(cbox_customer_add_active.Text == "Yes")
                {
                    customerInfo.Add("CustomerActive", "1");
                }
                else
                {
                    customerInfo.Add("CustomerActive", "0");
                }
                DBConn.updateCustomer(customerInfo);
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields (except 'Address 2') must be filled before updating customer.");
            }
        }

        private void btn_customer_update_delete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {
                selectedRow = gridView_customer_customers.CurrentRow;
            }
            catch
            {
                MessageBox.Show("No customer was selected.");
                return;
            }
            if (selectedRow == null)
            {
                MessageBox.Show("No customer was selected.");
                return;
            }
            else
            {
                selectedCustomer = DBConn.dataRowToHashtable(gridView_customer_customers, selectedRow);
                DBConn.removeFromTable("customer", int.Parse(selectedCustomer["customerId"].ToString()));
            }
            updateCustomerGrid();
        }
    }
}

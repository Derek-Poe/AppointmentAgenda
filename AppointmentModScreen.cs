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
    public partial class AppointmentModScreen : Form
    {
        private Hashtable selectedCustomer;
        private string selectedAppointmentID = "-1";
        private DateTime inputStart;
        private DateTime inputEnd;
        public AppointmentModScreen()
        {
            InitializeComponent();
            gridView_appointment_customers.AutoGenerateColumns = true;
            gridView_appointment_customers.DataMember = "Table";
            updateCustomerGrid();
        }

        public AppointmentModScreen(Hashtable selectedAppointment)
        {
            InitializeComponent();
            gridView_appointment_customers.AutoGenerateColumns = true;
            gridView_appointment_customers.DataMember = "Table";
            updateCustomerGrid();
            selectedAppointmentID = selectedAppointment["appointmentId"].ToString();
            DataSet newDataSet = new DataSet();
            newDataSet.Tables.Add();
            newDataSet.Tables[0].TableName = "Table";
            newDataSet.Tables[0].Columns.Add("customerId");
            newDataSet.Tables[0].Columns.Add("customerName");
            newDataSet.Tables[0].Columns.Add("address");
            newDataSet.Tables[0].Columns.Add("address2");
            newDataSet.Tables[0].Columns.Add("postalCode");
            newDataSet.Tables[0].Columns.Add("phone");
            newDataSet.Tables[0].Columns.Add("city");
            newDataSet.Tables[0].Columns.Add("country");
            newDataSet.Tables[0].Columns.Add("active");
            foreach (DataGridViewRow row in gridView_appointment_customers.Rows)
            {
                if(row.Cells["customerId"].Value.ToString() == selectedAppointment["customerId"].ToString())
                {
                    newDataSet.Tables[0].Rows.Add(((DataRowView)row.DataBoundItem).Row.ItemArray);
                }
            }
            gridView_appointment_customers.DataSource = null;
            gridView_appointment_customers.DataMember = "Table";
            gridView_appointment_customers.DataSource = newDataSet;
            gridView_appointment_customers.Rows[0].Selected = true;
            btn_appointment_update.Visible = true;
            tbox_appointment_type.Text = selectedAppointment["type"].ToString();
            dateTime_appointment_start.Value = DateTime.Parse(selectedAppointment["start"].ToString());
            dateTime_appointment_end.Value = DateTime.Parse(selectedAppointment["end"].ToString());
        }

        private void updateCustomerGrid()
        {
            gridView_appointment_customers.DataSource = DBConn.getDBDataset("SELECT customer.customerId,customer.customerName,address.address,address.address2,address.postalCode,address.phone,city.city,country.country,customer.active FROM customer INNER JOIN address on customer.addressId = address.addressId INNER JOIN city ON address.addressId = city.cityId INNER JOIN country on city.countryId = country.countryId;");
            foreach (DataGridViewColumn column in gridView_appointment_customers.Columns)
            {
                if (column.HeaderText == "userID")
                {
                    column.Visible = false;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void setTimes()
        {
            inputStart = dateTime_appointment_start.Value.ToUniversalTime();
            inputEnd = dateTime_appointment_end.Value.ToUniversalTime();
        }

        private bool checkForBusinessHours()
        {
            if (inputStart > inputEnd)
            {
                MessageBox.Show("Appointment start time cannot be same as or after the end time.");
                return false;
            }
            if (inputStart.ToLocalTime().Day != inputEnd.ToLocalTime().Day || inputStart.ToLocalTime().Month != inputEnd.ToLocalTime().Month || inputStart.ToLocalTime().Year != inputEnd.ToLocalTime().Year)
            {
                MessageBox.Show("Appointment start and end times must occur on the same day, month, and year.");
                return false;
            }
            if (inputStart.ToLocalTime().Hour < 9 || inputEnd.ToLocalTime().Hour >= 17)
            {
                MessageBox.Show("Appointment time must be within business hours. (0900 - 1700)");
                return false;
            }
            return true;
        }

        private Hashtable checkForExistingAppointment()
        {
            Hashtable result = new Hashtable();
            result.Add("check", "Pass");
            result.Add("text", "");
            foreach (DataRow row in DBConn.getDBData("SELECT appointment.appointmentId,customer.customerName,appointment.type,appointment.start,appointment.end FROM appointment INNER JOIN customer ON customer.customerId=appointment.customerId;"))
            {
                DateTime refStart = DateTime.Parse(row["start"].ToString());
                DateTime refEnd = DateTime.Parse(row["end"].ToString());
                if (((inputStart >= refStart && inputStart <= refEnd) || (inputEnd >= refStart && inputEnd <= refEnd)) && row["appointmentId"].ToString() != selectedAppointmentID)
                {
                    result["check"] = "Fail";
                    result["text"] = $"Appointment time is in conflict with the {row["customerName"].ToString()} {row["type"].ToString()} appointment on {refStart.ToLocalTime().ToString("MM/dd/yyyy")} ({refStart.ToLocalTime().ToString("HH:mm")} - {refEnd.ToLocalTime().ToString("HH:mm")}).";
                    return result;
                }
            }
            return result;
        }

        private void btn_customer_update_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_customer_update_delete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {
                selectedRow = gridView_appointment_customers.CurrentRow;
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
                selectedCustomer = DBConn.dataRowToHashtable(gridView_appointment_customers, selectedRow);
            }
            if (!string.IsNullOrWhiteSpace(tbox_appointment_type.Text)) {
                setTimes();
                if (!checkForBusinessHours())
                {
                    return;
                }
                Hashtable conflictCheck = checkForExistingAppointment();
                if (conflictCheck["check"].ToString() == "Fail")
                {
                    MessageBox.Show(conflictCheck["text"].ToString());
                    return;
                }
                string time = (DateTime.Now).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
                Hashtable appointmentData = new Hashtable();
                appointmentData.Add("Time", time);
                appointmentData.Add("StartTime", inputStart.ToString("yyyy-MM-dd HH:mm:ss"));
                appointmentData.Add("EndTime", inputEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                appointmentData.Add("Type", tbox_appointment_type.Text);
                DBConn.addAppointment(selectedCustomer, appointmentData);
                this.Close();
            }
            else
            {
                MessageBox.Show("Type cannot be blank.");
                return;
            }
        }

        private void btn_appointment_update_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {
                selectedRow = gridView_appointment_customers.CurrentRow;
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
                selectedCustomer = DBConn.dataRowToHashtable(gridView_appointment_customers, selectedRow);
            }
            if (!string.IsNullOrWhiteSpace(tbox_appointment_type.Text))
            {
                setTimes();
                if (!checkForBusinessHours())
                {
                    return;
                }
                Hashtable conflictCheck = checkForExistingAppointment();
                if (conflictCheck["check"].ToString() == "Fail")
                {
                    MessageBox.Show(conflictCheck["text"].ToString());
                    return;
                }
                string time = (DateTime.Now).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
                Hashtable appointmentData = new Hashtable();
                appointmentData.Add("Time", time);
                appointmentData.Add("StartTime",inputStart.ToString("yyyy-MM-dd HH:mm:ss"));
                appointmentData.Add("EndTime", inputEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                appointmentData.Add("Type", tbox_appointment_type.Text);
                appointmentData.Add("appointmentId", selectedAppointmentID);
                DBConn.updateAppointment(appointmentData);
                this.Close();
            }
            else
            {
                MessageBox.Show("Type cannot be blank.");
                return;
            }
        }
    }
}

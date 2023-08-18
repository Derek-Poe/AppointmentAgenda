using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_001340166
{
    public partial class MainScreen : Form
    {
        public static int CurrentUserID;
        public static string CurrentUsername;
        private string[] daysMarked;
        private DataSet appointmentDataSource;
        private Hashtable appointmentsDays = new Hashtable();
        public MainScreen(int userID, string username)
        {
            InitializeComponent();
            CurrentUserID = userID;
            CurrentUsername = username;
            cbox_mainScreen_calendarType.Text = "Month";
            gridView_mainScreen_appointments.AutoGenerateColumns = true;
            gridView_mainScreen_appointments.DataMember = "Table";
            gridView_mainScreen_calendar.AutoGenerateColumns = true;
            gridView_mainScreen_calendar.DataMember = "Table";
            updateAppointmentGrid();
            createCalendar();
            List<DataRow> appointments = new List<DataRow>();
            appointments.AddRange(DBConn.getDBData("SELECT appointment.appointmentId,appointment.customerId,customer.customerName,appointment.type,appointment.start,appointment.end FROM appointment INNER JOIN customer on appointment.customerId = customer.customerId ORDER BY appointment.start;").Cast<DataRow>());
            DataRow nextAppointment = appointments.Where(row => DateTime.SpecifyKind(DateTime.Parse(row["start"].ToString()), DateTimeKind.Utc).ToLocalTime() >= DateTime.Now).FirstOrDefault(); //Lambda expression simplifies filtering out dates that are in the past
            if (nextAppointment != null)
            {
                int minutesUntilNext = int.Parse(TimeSpan.FromTicks(DateTime.SpecifyKind(DateTime.Parse(nextAppointment["start"].ToString()), DateTimeKind.Utc).ToLocalTime().Ticks - DateTime.Now.Ticks).TotalMinutes.ToString().Split(char.Parse("."))[0]);
                if (minutesUntilNext <= 15)
                {
                    MessageBox.Show($"The {nextAppointment["customerName"].ToString()} {nextAppointment["type"].ToString()} appointment starts in {minutesUntilNext} minutes.");
                }
            }
        }

        public void updateAppointmentGrid() {
            appointmentDataSource = DBConn.getDBDataset("SELECT appointment.appointmentId,appointment.customerId,customer.customerName,appointment.type,appointment.start,appointment.end,appointment.createdBy FROM appointment INNER JOIN customer on appointment.customerId = customer.customerId;");
            appointmentDataSource.Tables[0].TableName = "Table";
            gridView_mainScreen_appointments.DataSource = appointmentDataSource;
            foreach (DataGridViewColumn column in gridView_mainScreen_appointments.Columns)
            {
                if (column.HeaderText == "userID" || column.HeaderText == "customerId")
                {
                    column.Visible = false;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            foreach (DataGridViewRow row in gridView_mainScreen_appointments.Rows)
            {
                row.Cells["start"].Value = DateTime.SpecifyKind(DateTime.Parse(row.Cells["start"].Value.ToString()), DateTimeKind.Utc).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                row.Cells["end"].Value = DateTime.SpecifyKind(DateTime.Parse(row.Cells["end"].Value.ToString()), DateTimeKind.Utc).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public void createCalendar()
        {
            gridView_mainScreen_calendar.DataSource = null;
            gridView_mainScreen_calendar.DataMember = "Table";
            DateTime today = (DateTime.Now).ToUniversalTime();
            string month = today.ToLocalTime().ToString("MMMM").Trim();
            lab_mainScreen_calendar.Text = month;
            DataSet calendar = new DataSet();
            calendar.Tables.Add();
            calendar.Tables[0].TableName = "Table";
            calendar.Tables[0].Columns.Add("Sunday", typeof(string));
            calendar.Tables[0].Columns.Add("Monday", typeof(string));
            calendar.Tables[0].Columns.Add("Tuesday", typeof(string));
            calendar.Tables[0].Columns.Add("Wednesday", typeof(string));
            calendar.Tables[0].Columns.Add("Thursday", typeof(string));
            calendar.Tables[0].Columns.Add("Friday", typeof(string));
            calendar.Tables[0].Columns.Add("Saturday", typeof(string));
            if (cbox_mainScreen_calendarType.Text == "Month")
            {
                calendar.Tables[0].Rows.Add();
                calendar.Tables[0].Rows.Add();
                calendar.Tables[0].Rows.Add();
                calendar.Tables[0].Rows.Add();
                calendar.Tables[0].Rows.Add();
                int calendarRow = 0;
                string daysToMark = "";
                for (int i = 0; i < 31; i++)
                {
                    DateTime day = DateTime.Parse("1/1/2099");
                    try
                    {
                        day = (DateTime.Parse($"{today.Month}/{i + 1}/{today.Year}")).ToUniversalTime();
                    }
                    catch { }
                    foreach (DataRow row in appointmentDataSource.Tables[0].Rows)
                    {
                        if (day.Day == DateTime.Parse(row["start"].ToString()).ToUniversalTime().Day && day.Month == DateTime.Parse(row["start"].ToString()).ToUniversalTime().Month && day.Year == DateTime.Parse(row["start"].ToString()).ToUniversalTime().Year)
                        {
                            if (daysToMark != "")
                            {
                                daysToMark += ",";
                            }
                            daysToMark += (i + 1).ToString();                     
                            if (!appointmentsDays.ContainsKey(row["appointmentId"]))
                            {
                                appointmentsDays.Add(row["appointmentId"], (i + 1).ToString());
                            }
                            else
                            {
                                if (!appointmentsDays[row["appointmentId"]].ToString().Split(char.Parse(",")).Contains((i + 1).ToString())) {
                                    appointmentsDays[row["appointmentId"]] = appointmentsDays[row["appointmentId"]] + "," + (i + 1).ToString();
                                }
                            }
                        }
                    }
                    calendar.Tables[0].Rows[calendarRow][day.DayOfWeek.ToString()] = day.Day.ToString();
                    if (day.DayOfWeek.ToString() == "Saturday")
                    {
                        calendarRow++;
                    }
                }
                gridView_mainScreen_calendar.DataSource = calendar;
                foreach (DataGridViewColumn column in gridView_mainScreen_calendar.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                daysMarked = daysToMark.Split(char.Parse(","));
                foreach (DataGridViewRow row in gridView_mainScreen_calendar.Rows)
                {
                    foreach(DataGridViewCell cell in row.Cells)
                    {
                        if (!string.IsNullOrEmpty(cell.Value.ToString()))
                        {
                            if (daysMarked.Contains(cell.Value.ToString()))
                            {
                                cell.Style.BackColor = Color.LightGoldenrodYellow;
                                cell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                                cell.Value = cell.Value.ToString() + "~";
                            }
                        }
                    }
                }
                gridView_mainScreen_appointments.DataSource = null;
                gridView_mainScreen_appointments.DataMember = "Table";
                gridView_mainScreen_appointments.DataSource = appointmentDataSource;
            }
            else if (cbox_mainScreen_calendarType.Text == "Week")
            {
                DateTime lastSunday = today;
                bool searching = true;
                while (searching)
                {
                    if(lastSunday.DayOfWeek.ToString() == "Sunday")
                    {
                        searching = false;
                    }
                    else
                    {
                        lastSunday = lastSunday.AddDays(-1);
                    }
                }
                calendar.Tables[0].Rows.Add();
                
                string daysToMark = "";
                DateTime day = lastSunday;
                for (int i = 0; i < 7; i++)
                {
                    foreach (DataRow row in appointmentDataSource.Tables[0].Rows)
                    {
                        if (day.Day == DateTime.Parse(row["start"].ToString()).ToUniversalTime().Day && day.Month == DateTime.Parse(row["start"].ToString()).ToUniversalTime().Month && day.Year == DateTime.Parse(row["start"].ToString()).ToUniversalTime().Year)
                        {
                            if (daysToMark != "")
                            {
                                daysToMark += ",";
                            }
                            daysToMark += day.Day.ToString();
                            if (!appointmentsDays.ContainsKey(row["appointmentId"]))
                            {
                                appointmentsDays.Add(row["appointmentId"], day.Day.ToString());
                            }
                            else
                            {
                                if (!appointmentsDays[row["appointmentId"]].ToString().Split(char.Parse(",")).Contains((i + 1).ToString()))
                                {
                                    appointmentsDays[row["appointmentId"]] = appointmentsDays[row["appointmentId"]] + "," + (i + 1).ToString();
                                }
                            }
                        }
                    }
                    calendar.Tables[0].Rows[0][day.DayOfWeek.ToString()] = day.Day.ToString();
                    day = day.AddDays(1);
                }
                gridView_mainScreen_calendar.DataSource = calendar;
                foreach (DataGridViewColumn column in gridView_mainScreen_calendar.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                daysMarked = daysToMark.Split(char.Parse(","));
                foreach (DataGridViewRow row in gridView_mainScreen_calendar.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (!string.IsNullOrEmpty(cell.Value.ToString()))
                        {
                            if (daysMarked.Contains(cell.Value.ToString()))
                            {
                                cell.Style.BackColor = Color.LightGoldenrodYellow;
                                cell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                                cell.Value = cell.Value.ToString() + "~";
                            }
                        }
                    }
                }
                gridView_mainScreen_appointments.DataSource = null;
                gridView_mainScreen_appointments.DataMember = "Table";
                gridView_mainScreen_appointments.DataSource = appointmentDataSource;
            }
            gridView_mainScreen_calendar.Refresh();
            gridView_mainScreen_appointments.Refresh();
            gridView_mainScreen_appointments.RefreshEdit();
        }

        private void smenu_mainScreen_customer_add_Click(object sender, EventArgs e)
        {
            new CustomerModScreen("add").ShowDialog();
        }

        private void smenu_mainScreen_update_Click(object sender, EventArgs e)
        {
            new CustomerModScreen("update").ShowDialog();
        }

        private void smenu_mainScreen_customer_delete_Click(object sender, EventArgs e)
        {
            new CustomerModScreen("delete").ShowDialog();
        }

        private void btn_mainScreen_addAppointment_Click(object sender, EventArgs e)
        {
            new AppointmentModScreen().ShowDialog();
            updateAppointmentGrid();
            createCalendar();
        }

        private void cbox_mainScreen_calendarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateAppointmentGrid();
            createCalendar();
        }

        private void gridView_mainScreen_calendar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = gridView_mainScreen_calendar.CurrentCell;
            if (daysMarked.Contains(selectedCell.Value.ToString().Split(char.Parse("~"))[0]))
            {
                updateAppointmentGrid();
                DataSet newDataSet = new DataSet();
                newDataSet.Tables.Add();
                newDataSet.Tables[0].TableName = "Table";
                newDataSet.Tables[0].Columns.Add("appointmentId", typeof(string));
                newDataSet.Tables[0].Columns.Add("customerId", typeof(string));
                newDataSet.Tables[0].Columns.Add("customerName", typeof(string));
                newDataSet.Tables[0].Columns.Add("type", typeof(string));
                newDataSet.Tables[0].Columns.Add("start", typeof(string));
                newDataSet.Tables[0].Columns.Add("end", typeof(string));
                newDataSet.Tables[0].Columns.Add("createdBy", typeof(string));
                foreach (DataGridViewRow row in gridView_mainScreen_appointments.Rows)
                {
                    if (appointmentsDays.ContainsKey(int.Parse(row.Cells["appointmentId"].Value.ToString())))
                    {
                        if (appointmentsDays[int.Parse(row.Cells["appointmentId"].Value.ToString())].ToString().Split(char.Parse(",")).Contains(selectedCell.Value.ToString().Split(char.Parse("~"))[0]))
                        {
                            newDataSet.Tables[0].Rows.Add(((DataRowView)row.DataBoundItem).Row.ItemArray);
                        }
                    }
                }
                gridView_mainScreen_appointments.DataSource = null;
                gridView_mainScreen_appointments.DataMember = "Table";
                gridView_mainScreen_appointments.DataSource = newDataSet;
            }
        }

        private void btn_mainScreen_showAll_Click(object sender, EventArgs e)
        {
            updateAppointmentGrid();
            createCalendar();
        }

        private void btn_mainScreen_updateCustomer_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {
                selectedRow = gridView_mainScreen_appointments.CurrentRow;
            }
            catch
            {
                MessageBox.Show("No appointment was selected.");
                return;
            }
            if (selectedRow == null)
            {
                MessageBox.Show("No appointment was selected.");
                return;
            }
            else
            {
                Hashtable appointmentData = new Hashtable();
                appointmentData.Add("appointmentId",selectedRow.Cells["appointmentId"].Value);
                appointmentData.Add("customerId", selectedRow.Cells["customerId"].Value);
                appointmentData.Add("type", selectedRow.Cells["type"].Value);
                appointmentData.Add("start", selectedRow.Cells["start"].Value);
                appointmentData.Add("end", selectedRow.Cells["end"].Value);
                new AppointmentModScreen(appointmentData).ShowDialog();
                updateAppointmentGrid();
                createCalendar();
            }
        }

        private void btn_mainScreen_deleteCustomer_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {
                selectedRow = gridView_mainScreen_appointments.CurrentRow;
            }
            catch
            {
                MessageBox.Show("No appointment was selected.");
                return;
            }
            if (selectedRow == null)
            {
                MessageBox.Show("No appointment was selected.");
                return;
            }
            else
            {
                DBConn.removeFromTable("appointment", int.Parse(selectedRow.Cells["appointmentId"].Value.ToString()));
            }
            updateAppointmentGrid();
            createCalendar();
        }

        private void smenu_mainScreen_report_appointments_Click(object sender, EventArgs e)
        {
            new ReportScreen("Appointment Types").ShowDialog();
        }

        private void smenu_mainScreen_consultantSchedule_Click(object sender, EventArgs e)
        {
            new ReportScreen("Schedules").ShowDialog();
        }

        private void smenu_mainScreen_logins_Click(object sender, EventArgs e)
        {
            new ReportScreen("Logins").ShowDialog();
        }
    }
}

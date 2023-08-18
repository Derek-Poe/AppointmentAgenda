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
using System.IO;

namespace C969_001340166
{
    public partial class ReportScreen : Form
    {
        private string reportType;
        public ReportScreen(string type)
        {
            InitializeComponent();
            reportType = type;
            gridView_report_report.AutoGenerateColumns = true;
            changeReport();
        }

        private void changeReport()
        {
            gridView_report_report.DataSource = null;
            gridView_report_report.DataMember = "Table";
            cbox_report_userSelect.Visible = false;
            if (reportType == "Appointment Types")
            {
                createAppointmentTypesReport();
            }
            else if (reportType == "Schedules")
            {
                createScheduleReport(false);
            }
            else if (reportType == "Logins")
            {
                createLoginReport();
            }
        }

        private void createAppointmentTypesReport()
        {
            cbox_report_reportType.Text = "Appointment Types";
            lab_report_reportType.Text = "Appointment Types";
            List<DataRow> appointments = new List<DataRow>();
            appointments.AddRange(DBConn.getDBData("SELECT appointment.appointmentId,appointment.customerId,customer.customerName,appointment.type,appointment.start,appointment.end FROM appointment INNER JOIN customer on appointment.customerId = customer.customerId ORDER BY appointment.start;").Cast<DataRow>());
            List<string> allMonths = new List<string>();
            List<string> allTypes = new List<string>();
            foreach (DataRow row in appointments)
            {
                string month = DateTime.SpecifyKind(DateTime.Parse(row["start"].ToString()), DateTimeKind.Utc).ToLocalTime().ToString("MMMM");
                string type = row["type"].ToString();
                if (!allMonths.Contains(month))
                {
                    allMonths.Add(month);
                }
                if (!allTypes.Contains(type))
                {
                    allTypes.Add(type);
                }
            }
            DataSet dataset = new DataSet();
            dataset.Tables.Add();
            dataset.Tables[0].TableName = "Table";
            dataset.Tables[0].Columns.Add("Month", typeof(string));
            foreach (string type in allTypes)
            {
                dataset.Tables[0].Columns.Add(type, typeof(int));
            }
            for(int i = 0; i < allMonths.Count; i++)
            {
                dataset.Tables[0].Rows.Add();
                dataset.Tables[0].Rows[i]["Month"] = allMonths[i];
                foreach (string type in allTypes)
                {
                    dataset.Tables[0].Rows[i][type] = appointments.Where(row => DateTime.SpecifyKind(DateTime.Parse(row["start"].ToString()), DateTimeKind.Utc).ToLocalTime().ToString("MMMM") == allMonths[i] && row["type"].ToString().ToString() == type).Count(); //Lambda expression simplifies filtering down to specified type that occurred in specified month
                }
            }
            gridView_report_report.DataSource = dataset;
            foreach (DataGridViewColumn column in gridView_report_report.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }
        private void createScheduleReport(bool change)
        {
            if (!change)
            {
                cbox_report_reportType.Text = "Schedules";
                lab_report_reportType.Text = "Schedules";
                cbox_report_userSelect.Visible = true;
                List<string> users = new List<string>();
                foreach (DataRow row in DBConn.getDBData("SELECT userName FROM user;"))
                {
                    users.Add(row["userName"].ToString());
                }
                cbox_report_userSelect.DataSource = users;
                cbox_report_userSelect.SelectedIndex = 0;
            }
            List<DataRow> appointments = new List<DataRow>();
            DataSet dataset = new DataSet();
            dataset.Tables.Add();
            dataset.Tables[0].TableName = "Table";
            dataset.Tables[0].Columns.Add("appointmentId", typeof(string));
            dataset.Tables[0].Columns.Add("customerId", typeof(string));
            dataset.Tables[0].Columns.Add("customerName", typeof(string));
            dataset.Tables[0].Columns.Add("type", typeof(string));
            dataset.Tables[0].Columns.Add("start", typeof(string));
            dataset.Tables[0].Columns.Add("end", typeof(string));
            dataset.Tables[0].Columns.Add("createdBy", typeof(string));
            appointments.AddRange(DBConn.getDBData("SELECT appointment.appointmentId,appointment.customerId,customer.customerName,appointment.type,appointment.start,appointment.end,appointment.createdBy FROM appointment INNER JOIN customer on appointment.customerId = customer.customerId ORDER BY appointment.start;").Cast<DataRow>());
            foreach (DataRow dataRow in appointments.Where(row => row["createdBy"].ToString() == cbox_report_userSelect.Text)) { //Lambda expression simplifies filtering to appointments for selected consultant
                dataset.Tables[0].Rows.Add(dataRow.ItemArray);
            }
            gridView_report_report.DataSource = dataset;
            foreach (DataGridViewRow row in gridView_report_report.Rows)
            {
                row.Cells["start"].Value = DateTime.SpecifyKind(DateTime.Parse(row.Cells["start"].Value.ToString()), DateTimeKind.Utc).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                row.Cells["end"].Value = DateTime.SpecifyKind(DateTime.Parse(row.Cells["end"].Value.ToString()), DateTimeKind.Utc).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            }
            foreach (DataGridViewColumn column in gridView_report_report.Columns)
            {
                if (column.HeaderText == "customerId" || column.HeaderText == "createdBy")
                {
                    column.Visible = false;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void createLoginReport()
        {
            cbox_report_reportType.Text = "Logins";
            lab_report_reportType.Text = "Logins";
            List<string> logs = new List<string>(File.ReadAllLines("log.txt"));
            Hashtable userLogins = new Hashtable();
            foreach (string line in logs)
            {
                string user = line.Split(char.Parse("~"))[1].Split(char.Parse(";"))[1].Split(char.Parse(","))[1];
                if (!userLogins.ContainsKey(user))
                {
                    userLogins.Add(user, 0);
                }
                userLogins[user] = int.Parse(userLogins[user].ToString()) + 1;
            }
            DataSet dataset = new DataSet();
            dataset.Tables.Add();
            dataset.Tables[0].TableName = "Table";
            dataset.Tables[0].Columns.Add("User", typeof(string));
            dataset.Tables[0].Columns.Add("Logins", typeof(string));
            foreach (DictionaryEntry key in userLogins)
            {
                dataset.Tables[0].Rows.Add(key.Key.ToString(), key.Value.ToString());
            }
            gridView_report_report.DataSource = dataset;
            foreach (DataGridViewColumn column in gridView_report_report.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void cbox_report_reportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportType = cbox_report_reportType.Text;
            changeReport();
        }

        private void cbox_report_userSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            createScheduleReport(true);
        }
    }
}

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace C969_001340166
{
    public class DBConn
    {
        public static MySqlConnection mconn;
        public static MySqlCommand mcmd;
        public static DataSet dataset;
        public static MySqlDataAdapter madapter;

        public static Hashtable dataRowToHashtable(DataGridView datagridview, DataGridViewRow datarow)
        {
            Hashtable hashtable = new Hashtable();
            foreach (DataGridViewCell cell in datarow.Cells)
            {
                hashtable.Add(datagridview.Columns[cell.ColumnIndex].HeaderText.ToString(), cell.Value.ToString());
            }
            return hashtable;
        }
        public static void startConnection()
        {
            mconn = new MySqlConnection("server=127.0.0.1; uid=sqlUser; pwd=Passw0rd!; database=client_schedule;");
            mconn.Open();
            mcmd = new MySqlCommand();
            mcmd.Connection = mconn;
            dataset = new DataSet();
            madapter = new MySqlDataAdapter(mcmd);
        }
        public static DataSet getDBDataset(string query)
        {
            mcmd.CommandText = query;
            dataset.Clear();
            dataset = new DataSet();
            madapter.Fill(dataset);
            return dataset;
        }
        public static DataRowCollection getDBData(string query)
        {
            mcmd.CommandText = query;
            dataset.Clear();
            dataset = new DataSet();
            madapter.Fill(dataset);
            return dataset.Tables[0].Rows;
        }
        public static int addToTable(string table, string time, string data, int exID)
        {
            int newID;
            if (table == "country")
            {
                DataRowCollection existing = getDBData($"SELECT * FROM {table} WHERE {table} = '{data}';");
                if(existing.Count == 0)
                {
                    DataRowCollection currentIDs = getDBData($"SELECT {table}Id FROM {table};");
                    int maxNum = 0;
                    for(int i = 0; i < currentIDs.Count; i++)
                    {
                        if (maxNum < int.Parse(currentIDs[i][$"{table}Id"].ToString()))
                        {
                            maxNum = int.Parse(currentIDs[i][$"{table}Id"].ToString());
                        }
                    }
                    newID = maxNum + 1;
                    mcmd.CommandText = $"INSERT INTO {table} VALUES ('{newID}', '{data}', '{time}', '{MainScreen.CurrentUsername}', '{time}', '{MainScreen.CurrentUsername}');";
                    mcmd.ExecuteNonQuery();
                    return newID;
                }
                else
                {
                    return int.Parse(existing[0][$"{table}Id"].ToString());
                }
            }
            else if (table == "city")
            {
                DataRowCollection existing = getDBData($"SELECT * FROM {table} WHERE {table} = '{data}';");
                if (existing.Count == 0)
                {
                    DataRowCollection currentIDs = getDBData($"SELECT {table}Id FROM {table};");
                    int maxNum = 0;
                    for (int i = 0; i < currentIDs.Count; i++)
                    {
                        if (maxNum < int.Parse(currentIDs[i][$"{table}Id"].ToString()))
                        {
                            maxNum = int.Parse(currentIDs[i][$"{table}Id"].ToString());
                        }
                    }
                    newID = maxNum + 1;
                    mcmd.CommandText = $"INSERT INTO {table} VALUES ('{newID}', '{data}', '{exID}', '{time}', '{MainScreen.CurrentUsername}', '{time}', '{MainScreen.CurrentUsername}');";
                    mcmd.ExecuteNonQuery();
                    return newID;
                }
                else
                {
                    return int.Parse(existing[0][$"{table}Id"].ToString());
                }
            }
            else if (table == "address")
            {
                string[] addressData = data.Split(char.Parse("~"));
                DataRowCollection existing = getDBData($"SELECT * FROM {table} WHERE {table} = '{addressData[0]}' AND {table}2 = '{addressData[1]}';");
                if (existing.Count == 0)
                {
                    DataRowCollection currentIDs = getDBData($"SELECT {table}Id FROM {table};");
                    int maxNum = 0;
                    for (int i = 0; i < currentIDs.Count; i++)
                    {

                        if (maxNum < int.Parse(currentIDs[i][$"{table}Id"].ToString()))
                        {
                            maxNum = int.Parse(currentIDs[i][$"{table}Id"].ToString());
                        }
                    }
                    newID = maxNum + 1;
                    mcmd.CommandText = $"INSERT INTO {table} VALUES ('{newID}', '{addressData[0]}', '{addressData[1]}', '{exID}', '{addressData[2]}', '{addressData[3]}', '{time}', '{MainScreen.CurrentUsername}', '{time}', '{MainScreen.CurrentUsername}');";
                    mcmd.ExecuteNonQuery();
                    return newID;
                }
                else
                {
                    return int.Parse(existing[0][$"{table}Id"].ToString());
                }
            }
            else if (table == "customer")
            {
                string[] customerData = data.Split(char.Parse("~"));
                int active;
                if (customerData[1] == "Yes")
                {
                    active = 1;
                }
                else
                {
                    active = 0;
                }
                DataRowCollection currentIDs = getDBData($"SELECT {table}Id FROM {table};");
                int maxNum = 0;
                for (int i = 0; i < currentIDs.Count; i++)
                {
                    if (maxNum < int.Parse(currentIDs[i][$"{table}Id"].ToString()))
                    {
                        maxNum = int.Parse(currentIDs[i][$"{table}Id"].ToString());
                    }
                }
                newID = maxNum + 1;
                mcmd.CommandText = $"INSERT INTO {table} VALUES ('{newID}', '{customerData[0]}', '{exID}', '{active}', '{time}', '{MainScreen.CurrentUsername}', '{time}', '{MainScreen.CurrentUsername}');";
                mcmd.ExecuteNonQuery();
                return newID;
            }
            else
            {
                return -1;
            }
        }
        public static void updateCustomer(Hashtable customerInfo)
        {
            mcmd.CommandText = $"UPDATE customer SET customerName='{customerInfo["CustomerName"]}',addressId='{customerInfo["CustomerAddressID"]}',active='{customerInfo["CustomerActive"]}',lastUpdate='{customerInfo["Time"]}',lastUpdateBy='{MainScreen.CurrentUsername}' WHERE  customerId='{customerInfo["CustomerID"]}';";
            mcmd.ExecuteNonQuery();
        }
        public static void removeFromTable(string table, int rowId)
        {
            mcmd.CommandText = $"DELETE FROM {table} WHERE {table}Id = '{rowId}';";
            mcmd.ExecuteNonQuery();
        }
        public static void addAppointment(Hashtable customerData, Hashtable appointmentData)
        {
            int newID;
            DataRowCollection currentIDs = getDBData($"SELECT appointmentId FROM appointment;");
            int maxNum = 0;
            for (int i = 0; i < currentIDs.Count; i++)
            {
                if (maxNum < int.Parse(currentIDs[i]["appointmentId"].ToString()))
                {
                    maxNum = int.Parse(currentIDs[i]["appointmentId"].ToString());
                }
            }
            newID = maxNum + 1;
            mcmd.CommandText = $"INSERT INTO appointment VALUES ('{newID}', '{customerData["customerId"]}', '{MainScreen.CurrentUserID}', 'not needed', 'not needed', 'not needed', 'not needed', '{appointmentData["Type"]}', 'not needed', '{appointmentData["StartTime"]}', '{appointmentData["EndTime"]}', '{appointmentData["Time"]}', '{MainScreen.CurrentUsername}', '{appointmentData["Time"]}', '{MainScreen.CurrentUsername}');";
            mcmd.ExecuteNonQuery();
        }
        public static void updateAppointment(Hashtable appointmentData)
        {
            mcmd.CommandText = $"UPDATE appointment SET type='{appointmentData["Type"]}',start='{appointmentData["StartTime"]}',end='{appointmentData["EndTime"]}',lastUpdate='{appointmentData["Time"]}',lastUpdateBy='{MainScreen.CurrentUsername}' WHERE appointmentId='{appointmentData["appointmentId"]}';";
            mcmd.ExecuteNonQuery();
        }
    }
}

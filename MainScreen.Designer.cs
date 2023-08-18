
namespace C969_001340166
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridView_mainScreen_appointments = new System.Windows.Forms.DataGridView();
            this.lab_mainScreen_mainTitle = new System.Windows.Forms.Label();
            this.cbox_mainScreen_calendarType = new System.Windows.Forms.ComboBox();
            this.btn_mainScreen_addAppointment = new System.Windows.Forms.Button();
            this.btn_mainScreen_updateCustomer = new System.Windows.Forms.Button();
            this.btn_mainScreen_deleteCustomer = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smenu_mainScreen_customer = new System.Windows.Forms.ToolStripMenuItem();
            this.smenu_mainScreen_customer_add = new System.Windows.Forms.ToolStripMenuItem();
            this.smenu_mainScreen_update = new System.Windows.Forms.ToolStripMenuItem();
            this.smenu_mainScreen_customer_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.smenu_mainScreen_report = new System.Windows.Forms.ToolStripMenuItem();
            this.smenu_mainScreen_report_appointments = new System.Windows.Forms.ToolStripMenuItem();
            this.smenu_mainScreen_consultantSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.smenu_mainScreen_logins = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_mainScreen_calendar = new System.Windows.Forms.DataGridView();
            this.lab_mainScreen_calendar = new System.Windows.Forms.Label();
            this.btn_mainScreen_showAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_mainScreen_appointments)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_mainScreen_calendar)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView_mainScreen_appointments
            // 
            this.gridView_mainScreen_appointments.AllowUserToAddRows = false;
            this.gridView_mainScreen_appointments.AllowUserToDeleteRows = false;
            this.gridView_mainScreen_appointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_mainScreen_appointments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridView_mainScreen_appointments.Location = new System.Drawing.Point(55, 333);
            this.gridView_mainScreen_appointments.MultiSelect = false;
            this.gridView_mainScreen_appointments.Name = "gridView_mainScreen_appointments";
            this.gridView_mainScreen_appointments.ReadOnly = true;
            this.gridView_mainScreen_appointments.RowHeadersWidth = 51;
            this.gridView_mainScreen_appointments.RowTemplate.Height = 24;
            this.gridView_mainScreen_appointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView_mainScreen_appointments.Size = new System.Drawing.Size(827, 204);
            this.gridView_mainScreen_appointments.TabIndex = 0;
            // 
            // lab_mainScreen_mainTitle
            // 
            this.lab_mainScreen_mainTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_mainScreen_mainTitle.AutoSize = true;
            this.lab_mainScreen_mainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.lab_mainScreen_mainTitle.Location = new System.Drawing.Point(371, 31);
            this.lab_mainScreen_mainTitle.Name = "lab_mainScreen_mainTitle";
            this.lab_mainScreen_mainTitle.Size = new System.Drawing.Size(193, 33);
            this.lab_mainScreen_mainTitle.TabIndex = 1;
            this.lab_mainScreen_mainTitle.Text = "Appointments";
            this.lab_mainScreen_mainTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbox_mainScreen_calendarType
            // 
            this.cbox_mainScreen_calendarType.FormattingEnabled = true;
            this.cbox_mainScreen_calendarType.Items.AddRange(new object[] {
            "Month",
            "Week"});
            this.cbox_mainScreen_calendarType.Location = new System.Drawing.Point(761, 293);
            this.cbox_mainScreen_calendarType.Name = "cbox_mainScreen_calendarType";
            this.cbox_mainScreen_calendarType.Size = new System.Drawing.Size(121, 24);
            this.cbox_mainScreen_calendarType.TabIndex = 2;
            this.cbox_mainScreen_calendarType.SelectedIndexChanged += new System.EventHandler(this.cbox_mainScreen_calendarType_SelectedIndexChanged);
            // 
            // btn_mainScreen_addAppointment
            // 
            this.btn_mainScreen_addAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_mainScreen_addAppointment.Location = new System.Drawing.Point(303, 543);
            this.btn_mainScreen_addAppointment.Name = "btn_mainScreen_addAppointment";
            this.btn_mainScreen_addAppointment.Size = new System.Drawing.Size(112, 31);
            this.btn_mainScreen_addAppointment.TabIndex = 3;
            this.btn_mainScreen_addAppointment.Text = "Add";
            this.btn_mainScreen_addAppointment.UseVisualStyleBackColor = true;
            this.btn_mainScreen_addAppointment.Click += new System.EventHandler(this.btn_mainScreen_addAppointment_Click);
            // 
            // btn_mainScreen_updateCustomer
            // 
            this.btn_mainScreen_updateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_mainScreen_updateCustomer.Location = new System.Drawing.Point(415, 543);
            this.btn_mainScreen_updateCustomer.Name = "btn_mainScreen_updateCustomer";
            this.btn_mainScreen_updateCustomer.Size = new System.Drawing.Size(112, 31);
            this.btn_mainScreen_updateCustomer.TabIndex = 4;
            this.btn_mainScreen_updateCustomer.Text = "Update";
            this.btn_mainScreen_updateCustomer.UseVisualStyleBackColor = true;
            this.btn_mainScreen_updateCustomer.Click += new System.EventHandler(this.btn_mainScreen_updateCustomer_Click);
            // 
            // btn_mainScreen_deleteCustomer
            // 
            this.btn_mainScreen_deleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_mainScreen_deleteCustomer.Location = new System.Drawing.Point(527, 543);
            this.btn_mainScreen_deleteCustomer.Name = "btn_mainScreen_deleteCustomer";
            this.btn_mainScreen_deleteCustomer.Size = new System.Drawing.Size(112, 31);
            this.btn_mainScreen_deleteCustomer.TabIndex = 5;
            this.btn_mainScreen_deleteCustomer.Text = "Delete";
            this.btn_mainScreen_deleteCustomer.UseVisualStyleBackColor = true;
            this.btn_mainScreen_deleteCustomer.Click += new System.EventHandler(this.btn_mainScreen_deleteCustomer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smenu_mainScreen_customer,
            this.smenu_mainScreen_report});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(937, 31);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smenu_mainScreen_customer
            // 
            this.smenu_mainScreen_customer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smenu_mainScreen_customer_add,
            this.smenu_mainScreen_update,
            this.smenu_mainScreen_customer_delete});
            this.smenu_mainScreen_customer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.smenu_mainScreen_customer.Name = "smenu_mainScreen_customer";
            this.smenu_mainScreen_customer.Size = new System.Drawing.Size(98, 27);
            this.smenu_mainScreen_customer.Text = "Customer";
            // 
            // smenu_mainScreen_customer_add
            // 
            this.smenu_mainScreen_customer_add.Name = "smenu_mainScreen_customer_add";
            this.smenu_mainScreen_customer_add.Size = new System.Drawing.Size(150, 28);
            this.smenu_mainScreen_customer_add.Text = "Add";
            this.smenu_mainScreen_customer_add.Click += new System.EventHandler(this.smenu_mainScreen_customer_add_Click);
            // 
            // smenu_mainScreen_update
            // 
            this.smenu_mainScreen_update.Name = "smenu_mainScreen_update";
            this.smenu_mainScreen_update.Size = new System.Drawing.Size(150, 28);
            this.smenu_mainScreen_update.Text = "Update";
            this.smenu_mainScreen_update.Click += new System.EventHandler(this.smenu_mainScreen_update_Click);
            // 
            // smenu_mainScreen_customer_delete
            // 
            this.smenu_mainScreen_customer_delete.Name = "smenu_mainScreen_customer_delete";
            this.smenu_mainScreen_customer_delete.Size = new System.Drawing.Size(150, 28);
            this.smenu_mainScreen_customer_delete.Text = "Delete";
            this.smenu_mainScreen_customer_delete.Click += new System.EventHandler(this.smenu_mainScreen_customer_delete_Click);
            // 
            // smenu_mainScreen_report
            // 
            this.smenu_mainScreen_report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smenu_mainScreen_report_appointments,
            this.smenu_mainScreen_consultantSchedule,
            this.smenu_mainScreen_logins});
            this.smenu_mainScreen_report.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.smenu_mainScreen_report.Name = "smenu_mainScreen_report";
            this.smenu_mainScreen_report.Size = new System.Drawing.Size(75, 27);
            this.smenu_mainScreen_report.Text = "Report";
            // 
            // smenu_mainScreen_report_appointments
            // 
            this.smenu_mainScreen_report_appointments.Name = "smenu_mainScreen_report_appointments";
            this.smenu_mainScreen_report_appointments.Size = new System.Drawing.Size(258, 28);
            this.smenu_mainScreen_report_appointments.Text = "Appointment Types";
            this.smenu_mainScreen_report_appointments.Click += new System.EventHandler(this.smenu_mainScreen_report_appointments_Click);
            // 
            // smenu_mainScreen_consultantSchedule
            // 
            this.smenu_mainScreen_consultantSchedule.Name = "smenu_mainScreen_consultantSchedule";
            this.smenu_mainScreen_consultantSchedule.Size = new System.Drawing.Size(258, 28);
            this.smenu_mainScreen_consultantSchedule.Text = "Consultant Schedules";
            this.smenu_mainScreen_consultantSchedule.Click += new System.EventHandler(this.smenu_mainScreen_consultantSchedule_Click);
            // 
            // smenu_mainScreen_logins
            // 
            this.smenu_mainScreen_logins.Name = "smenu_mainScreen_logins";
            this.smenu_mainScreen_logins.Size = new System.Drawing.Size(258, 28);
            this.smenu_mainScreen_logins.Text = "Logins";
            this.smenu_mainScreen_logins.Click += new System.EventHandler(this.smenu_mainScreen_logins_Click);
            // 
            // gridView_mainScreen_calendar
            // 
            this.gridView_mainScreen_calendar.AllowUserToAddRows = false;
            this.gridView_mainScreen_calendar.AllowUserToDeleteRows = false;
            this.gridView_mainScreen_calendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_mainScreen_calendar.Location = new System.Drawing.Point(55, 105);
            this.gridView_mainScreen_calendar.Name = "gridView_mainScreen_calendar";
            this.gridView_mainScreen_calendar.ReadOnly = true;
            this.gridView_mainScreen_calendar.RowHeadersWidth = 51;
            this.gridView_mainScreen_calendar.RowTemplate.Height = 24;
            this.gridView_mainScreen_calendar.Size = new System.Drawing.Size(827, 182);
            this.gridView_mainScreen_calendar.TabIndex = 7;
            this.gridView_mainScreen_calendar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_mainScreen_calendar_CellContentClick);
            // 
            // lab_mainScreen_calendar
            // 
            this.lab_mainScreen_calendar.AutoSize = true;
            this.lab_mainScreen_calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lab_mainScreen_calendar.Location = new System.Drawing.Point(424, 69);
            this.lab_mainScreen_calendar.Name = "lab_mainScreen_calendar";
            this.lab_mainScreen_calendar.Size = new System.Drawing.Size(100, 26);
            this.lab_mainScreen_calendar.TabIndex = 8;
            this.lab_mainScreen_calendar.Text = "Calendar";
            // 
            // btn_mainScreen_showAll
            // 
            this.btn_mainScreen_showAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_mainScreen_showAll.Location = new System.Drawing.Point(784, 543);
            this.btn_mainScreen_showAll.Name = "btn_mainScreen_showAll";
            this.btn_mainScreen_showAll.Size = new System.Drawing.Size(98, 31);
            this.btn_mainScreen_showAll.TabIndex = 9;
            this.btn_mainScreen_showAll.Text = "Show All";
            this.btn_mainScreen_showAll.UseVisualStyleBackColor = true;
            this.btn_mainScreen_showAll.Click += new System.EventHandler(this.btn_mainScreen_showAll_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 600);
            this.Controls.Add(this.btn_mainScreen_showAll);
            this.Controls.Add(this.lab_mainScreen_calendar);
            this.Controls.Add(this.gridView_mainScreen_calendar);
            this.Controls.Add(this.btn_mainScreen_deleteCustomer);
            this.Controls.Add(this.btn_mainScreen_updateCustomer);
            this.Controls.Add(this.btn_mainScreen_addAppointment);
            this.Controls.Add(this.cbox_mainScreen_calendarType);
            this.Controls.Add(this.lab_mainScreen_mainTitle);
            this.Controls.Add(this.gridView_mainScreen_appointments);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.gridView_mainScreen_appointments)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_mainScreen_calendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_mainScreen_mainTitle;
        private System.Windows.Forms.ComboBox cbox_mainScreen_calendarType;
        private System.Windows.Forms.Button btn_mainScreen_addAppointment;
        private System.Windows.Forms.Button btn_mainScreen_updateCustomer;
        private System.Windows.Forms.Button btn_mainScreen_deleteCustomer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_customer;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_customer_add;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_update;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_customer_delete;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_report;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_report_appointments;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_consultantSchedule;
        private System.Windows.Forms.ToolStripMenuItem smenu_mainScreen_logins;
        private System.Windows.Forms.Label lab_mainScreen_calendar;
        private System.Windows.Forms.Button btn_mainScreen_showAll;
        private System.Windows.Forms.DataGridView gridView_mainScreen_calendar;
        private System.Windows.Forms.DataGridView gridView_mainScreen_appointments;
    }
}
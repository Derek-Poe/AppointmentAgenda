
namespace C969_001340166
{
    partial class AppointmentModScreen
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
            this.btn_customer_update_delete = new System.Windows.Forms.Button();
            this.btn_customer_update_cancel = new System.Windows.Forms.Button();
            this.gridView_appointment_customers = new System.Windows.Forms.DataGridView();
            this.lab_appointment_startTime = new System.Windows.Forms.Label();
            this.lab_appointment_endTime = new System.Windows.Forms.Label();
            this.dateTime_appointment_start = new System.Windows.Forms.DateTimePicker();
            this.dateTime_appointment_end = new System.Windows.Forms.DateTimePicker();
            this.lab_appointment_type = new System.Windows.Forms.Label();
            this.tbox_appointment_type = new System.Windows.Forms.TextBox();
            this.btn_appointment_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_appointment_customers)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_customer_update_delete
            // 
            this.btn_customer_update_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_customer_update_delete.Location = new System.Drawing.Point(253, 472);
            this.btn_customer_update_delete.Name = "btn_customer_update_delete";
            this.btn_customer_update_delete.Size = new System.Drawing.Size(109, 37);
            this.btn_customer_update_delete.TabIndex = 19;
            this.btn_customer_update_delete.Text = "Add";
            this.btn_customer_update_delete.UseVisualStyleBackColor = true;
            this.btn_customer_update_delete.Click += new System.EventHandler(this.btn_customer_update_delete_Click);
            // 
            // btn_customer_update_cancel
            // 
            this.btn_customer_update_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_customer_update_cancel.Location = new System.Drawing.Point(438, 472);
            this.btn_customer_update_cancel.Name = "btn_customer_update_cancel";
            this.btn_customer_update_cancel.Size = new System.Drawing.Size(109, 37);
            this.btn_customer_update_cancel.TabIndex = 18;
            this.btn_customer_update_cancel.Text = "Cancel";
            this.btn_customer_update_cancel.UseVisualStyleBackColor = true;
            this.btn_customer_update_cancel.Click += new System.EventHandler(this.btn_customer_update_cancel_Click);
            // 
            // gridView_appointment_customers
            // 
            this.gridView_appointment_customers.AllowUserToAddRows = false;
            this.gridView_appointment_customers.AllowUserToDeleteRows = false;
            this.gridView_appointment_customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_appointment_customers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridView_appointment_customers.Location = new System.Drawing.Point(19, 27);
            this.gridView_appointment_customers.MultiSelect = false;
            this.gridView_appointment_customers.Name = "gridView_appointment_customers";
            this.gridView_appointment_customers.ReadOnly = true;
            this.gridView_appointment_customers.RowHeadersWidth = 51;
            this.gridView_appointment_customers.RowTemplate.Height = 24;
            this.gridView_appointment_customers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView_appointment_customers.Size = new System.Drawing.Size(769, 325);
            this.gridView_appointment_customers.TabIndex = 17;
            // 
            // lab_appointment_startTime
            // 
            this.lab_appointment_startTime.AutoSize = true;
            this.lab_appointment_startTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lab_appointment_startTime.Location = new System.Drawing.Point(97, 360);
            this.lab_appointment_startTime.Name = "lab_appointment_startTime";
            this.lab_appointment_startTime.Size = new System.Drawing.Size(51, 24);
            this.lab_appointment_startTime.TabIndex = 20;
            this.lab_appointment_startTime.Text = "Start:";
            // 
            // lab_appointment_endTime
            // 
            this.lab_appointment_endTime.AutoSize = true;
            this.lab_appointment_endTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lab_appointment_endTime.Location = new System.Drawing.Point(425, 362);
            this.lab_appointment_endTime.Name = "lab_appointment_endTime";
            this.lab_appointment_endTime.Size = new System.Drawing.Size(50, 24);
            this.lab_appointment_endTime.TabIndex = 21;
            this.lab_appointment_endTime.Text = "End:";
            // 
            // dateTime_appointment_start
            // 
            this.dateTime_appointment_start.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTime_appointment_start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTime_appointment_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateTime_appointment_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime_appointment_start.Location = new System.Drawing.Point(154, 358);
            this.dateTime_appointment_start.Name = "dateTime_appointment_start";
            this.dateTime_appointment_start.Size = new System.Drawing.Size(222, 25);
            this.dateTime_appointment_start.TabIndex = 22;
            // 
            // dateTime_appointment_end
            // 
            this.dateTime_appointment_end.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTime_appointment_end.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTime_appointment_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateTime_appointment_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime_appointment_end.Location = new System.Drawing.Point(481, 360);
            this.dateTime_appointment_end.Name = "dateTime_appointment_end";
            this.dateTime_appointment_end.Size = new System.Drawing.Size(222, 25);
            this.dateTime_appointment_end.TabIndex = 23;
            // 
            // lab_appointment_type
            // 
            this.lab_appointment_type.AutoSize = true;
            this.lab_appointment_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lab_appointment_type.Location = new System.Drawing.Point(293, 417);
            this.lab_appointment_type.Name = "lab_appointment_type";
            this.lab_appointment_type.Size = new System.Drawing.Size(58, 24);
            this.lab_appointment_type.TabIndex = 24;
            this.lab_appointment_type.Text = "Type:";
            // 
            // tbox_appointment_type
            // 
            this.tbox_appointment_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbox_appointment_type.Location = new System.Drawing.Point(357, 414);
            this.tbox_appointment_type.Name = "tbox_appointment_type";
            this.tbox_appointment_type.Size = new System.Drawing.Size(150, 28);
            this.tbox_appointment_type.TabIndex = 25;
            // 
            // btn_appointment_update
            // 
            this.btn_appointment_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_appointment_update.Location = new System.Drawing.Point(253, 472);
            this.btn_appointment_update.Name = "btn_appointment_update";
            this.btn_appointment_update.Size = new System.Drawing.Size(109, 37);
            this.btn_appointment_update.TabIndex = 26;
            this.btn_appointment_update.Text = "Update";
            this.btn_appointment_update.UseVisualStyleBackColor = true;
            this.btn_appointment_update.Visible = false;
            this.btn_appointment_update.Click += new System.EventHandler(this.btn_appointment_update_Click);
            // 
            // AppointmentModScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.btn_appointment_update);
            this.Controls.Add(this.tbox_appointment_type);
            this.Controls.Add(this.lab_appointment_type);
            this.Controls.Add(this.dateTime_appointment_end);
            this.Controls.Add(this.dateTime_appointment_start);
            this.Controls.Add(this.lab_appointment_endTime);
            this.Controls.Add(this.lab_appointment_startTime);
            this.Controls.Add(this.btn_customer_update_delete);
            this.Controls.Add(this.btn_customer_update_cancel);
            this.Controls.Add(this.gridView_appointment_customers);
            this.Name = "AppointmentModScreen";
            this.Text = "Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.gridView_appointment_customers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_customer_update_delete;
        private System.Windows.Forms.Button btn_customer_update_cancel;
        private System.Windows.Forms.DataGridView gridView_appointment_customers;
        private System.Windows.Forms.Label lab_appointment_startTime;
        private System.Windows.Forms.Label lab_appointment_endTime;
        private System.Windows.Forms.DateTimePicker dateTime_appointment_start;
        private System.Windows.Forms.DateTimePicker dateTime_appointment_end;
        private System.Windows.Forms.Label lab_appointment_type;
        private System.Windows.Forms.TextBox tbox_appointment_type;
        private System.Windows.Forms.Button btn_appointment_update;
    }
}
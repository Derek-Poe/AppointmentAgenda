
namespace C969_001340166
{
    partial class ReportScreen
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
            this.lab_report_reportType = new System.Windows.Forms.Label();
            this.lab_report_mainTitle = new System.Windows.Forms.Label();
            this.gridView_report_report = new System.Windows.Forms.DataGridView();
            this.cbox_report_reportType = new System.Windows.Forms.ComboBox();
            this.cbox_report_userSelect = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_report_report)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_report_reportType
            // 
            this.lab_report_reportType.AutoSize = true;
            this.lab_report_reportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lab_report_reportType.Location = new System.Drawing.Point(40, 48);
            this.lab_report_reportType.Name = "lab_report_reportType";
            this.lab_report_reportType.Size = new System.Drawing.Size(199, 26);
            this.lab_report_reportType.TabIndex = 10;
            this.lab_report_reportType.Text = "Appointment Types";
            this.lab_report_reportType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_report_mainTitle
            // 
            this.lab_report_mainTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lab_report_mainTitle.AutoSize = true;
            this.lab_report_mainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.lab_report_mainTitle.Location = new System.Drawing.Point(342, 9);
            this.lab_report_mainTitle.Name = "lab_report_mainTitle";
            this.lab_report_mainTitle.Size = new System.Drawing.Size(117, 33);
            this.lab_report_mainTitle.TabIndex = 9;
            this.lab_report_mainTitle.Text = "Reports";
            this.lab_report_mainTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gridView_report_report
            // 
            this.gridView_report_report.AllowUserToAddRows = false;
            this.gridView_report_report.AllowUserToDeleteRows = false;
            this.gridView_report_report.AllowUserToOrderColumns = true;
            this.gridView_report_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_report_report.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridView_report_report.Location = new System.Drawing.Point(45, 77);
            this.gridView_report_report.MultiSelect = false;
            this.gridView_report_report.Name = "gridView_report_report";
            this.gridView_report_report.ReadOnly = true;
            this.gridView_report_report.RowHeadersWidth = 51;
            this.gridView_report_report.RowTemplate.Height = 24;
            this.gridView_report_report.Size = new System.Drawing.Size(710, 287);
            this.gridView_report_report.TabIndex = 11;
            // 
            // cbox_report_reportType
            // 
            this.cbox_report_reportType.FormattingEnabled = true;
            this.cbox_report_reportType.Items.AddRange(new object[] {
            "Appointment Types",
            "Schedules",
            "Logins"});
            this.cbox_report_reportType.Location = new System.Drawing.Point(599, 370);
            this.cbox_report_reportType.Name = "cbox_report_reportType";
            this.cbox_report_reportType.Size = new System.Drawing.Size(156, 24);
            this.cbox_report_reportType.TabIndex = 12;
            this.cbox_report_reportType.SelectedIndexChanged += new System.EventHandler(this.cbox_report_reportType_SelectedIndexChanged);
            // 
            // cbox_report_userSelect
            // 
            this.cbox_report_userSelect.FormattingEnabled = true;
            this.cbox_report_userSelect.Location = new System.Drawing.Point(45, 370);
            this.cbox_report_userSelect.Name = "cbox_report_userSelect";
            this.cbox_report_userSelect.Size = new System.Drawing.Size(121, 24);
            this.cbox_report_userSelect.TabIndex = 13;
            this.cbox_report_userSelect.Visible = false;
            this.cbox_report_userSelect.SelectedIndexChanged += new System.EventHandler(this.cbox_report_userSelect_SelectedIndexChanged);
            // 
            // ReportScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.cbox_report_userSelect);
            this.Controls.Add(this.cbox_report_reportType);
            this.Controls.Add(this.gridView_report_report);
            this.Controls.Add(this.lab_report_reportType);
            this.Controls.Add(this.lab_report_mainTitle);
            this.Name = "ReportScreen";
            this.Text = "ReportScreen";
            ((System.ComponentModel.ISupportInitialize)(this.gridView_report_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_report_reportType;
        private System.Windows.Forms.Label lab_report_mainTitle;
        private System.Windows.Forms.DataGridView gridView_report_report;
        private System.Windows.Forms.ComboBox cbox_report_reportType;
        private System.Windows.Forms.ComboBox cbox_report_userSelect;
    }
}
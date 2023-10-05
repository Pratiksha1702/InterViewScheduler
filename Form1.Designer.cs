namespace InterViewScheduler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            txtGoogleMeetUrl = new TextBox();
            lblGoogleMeetUrl = new Label();
            cmbDuration = new ComboBox();
            btnSingleOpenFileDialog = new Button();
            btnSave = new Button();
            txtFeedbackLink = new TextBox();
            label18 = new Label();
            txtResumeLink = new TextBox();
            label19 = new Label();
            label15 = new Label();
            label14 = new Label();
            txtAttendes = new TextBox();
            label13 = new Label();
            txtRemark = new TextBox();
            cmbRounds = new ComboBox();
            label11 = new Label();
            cmbdtpInterviewTime = new ComboBox();
            dtpInterviewDate = new DateTimePicker();
            dtpLWD = new DateTimePicker();
            btnDrop = new Button();
            btnSchedule = new Button();
            cmbInterviewerNames = new ComboBox();
            label10 = new Label();
            cmbSchedulers = new ComboBox();
            label12 = new Label();
            label9 = new Label();
            label8 = new Label();
            cmbStatus = new ComboBox();
            label7 = new Label();
            cmbLocation = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            txtSkills = new TextBox();
            label4 = new Label();
            txtCandEmail = new TextBox();
            label3 = new Label();
            txtCondMobile = new TextBox();
            label2 = new Label();
            txtCondName = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvCandList = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            adminPanelToolStripMenuItem = new ToolStripMenuItem();
            addInterviewerToolStripMenuItem = new ToolStripMenuItem();
            addRecriuteeToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCandList).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGoogleMeetUrl);
            groupBox1.Controls.Add(lblGoogleMeetUrl);
            groupBox1.Controls.Add(cmbDuration);
            groupBox1.Controls.Add(btnSingleOpenFileDialog);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtFeedbackLink);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(txtResumeLink);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(txtAttendes);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(txtRemark);
            groupBox1.Controls.Add(cmbRounds);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cmbdtpInterviewTime);
            groupBox1.Controls.Add(dtpInterviewDate);
            groupBox1.Controls.Add(dtpLWD);
            groupBox1.Controls.Add(btnDrop);
            groupBox1.Controls.Add(btnSchedule);
            groupBox1.Controls.Add(cmbInterviewerNames);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(cmbSchedulers);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cmbLocation);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtSkills);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtCandEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCondMobile);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCondName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(8, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1307, 361);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Candidate Details";
            // 
            // txtGoogleMeetUrl
            // 
            txtGoogleMeetUrl.Enabled = false;
            txtGoogleMeetUrl.Location = new Point(649, 267);
            txtGoogleMeetUrl.Name = "txtGoogleMeetUrl";
            txtGoogleMeetUrl.Size = new Size(298, 27);
            txtGoogleMeetUrl.TabIndex = 46;
            // 
            // lblGoogleMeetUrl
            // 
            lblGoogleMeetUrl.AutoSize = true;
            lblGoogleMeetUrl.Location = new Point(463, 267);
            lblGoogleMeetUrl.Name = "lblGoogleMeetUrl";
            lblGoogleMeetUrl.Size = new Size(96, 20);
            lblGoogleMeetUrl.TabIndex = 45;
            lblGoogleMeetUrl.Text = "Google Meet";
            // 
            // cmbDuration
            // 
            cmbDuration.FormattingEnabled = true;
            cmbDuration.Items.AddRange(new object[] { "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" });
            cmbDuration.Location = new Point(954, 20);
            cmbDuration.Name = "cmbDuration";
            cmbDuration.Size = new Size(79, 28);
            cmbDuration.TabIndex = 44;
            // 
            // btnSingleOpenFileDialog
            // 
            btnSingleOpenFileDialog.Location = new Point(950, 193);
            btnSingleOpenFileDialog.Margin = new Padding(3, 4, 3, 4);
            btnSingleOpenFileDialog.Name = "btnSingleOpenFileDialog";
            btnSingleOpenFileDialog.Size = new Size(86, 31);
            btnSingleOpenFileDialog.TabIndex = 43;
            btnSingleOpenFileDialog.Text = "&Browse";
            btnSingleOpenFileDialog.UseVisualStyleBackColor = true;
            btnSingleOpenFileDialog.Click += btnSingleOpenFileDialog_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1099, 251);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 18;
            btnSave.Text = "Save Data";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtFeedbackLink
            // 
            txtFeedbackLink.Location = new Point(648, 231);
            txtFeedbackLink.Name = "txtFeedbackLink";
            txtFeedbackLink.Size = new Size(298, 27);
            txtFeedbackLink.TabIndex = 15;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(462, 233);
            label18.Name = "label18";
            label18.Size = new Size(119, 20);
            label18.TabIndex = 41;
            label18.Text = "Feedback Link :- ";
            // 
            // txtResumeLink
            // 
            txtResumeLink.Location = new Point(648, 191);
            txtResumeLink.Name = "txtResumeLink";
            txtResumeLink.Size = new Size(298, 27);
            txtResumeLink.TabIndex = 14;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(463, 195);
            label19.Name = "label19";
            label19.Size = new Size(108, 20);
            label19.TabIndex = 39;
            label19.Text = "Resume Link :- ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(651, 124);
            label15.Name = "label15";
            label15.Size = new Size(257, 20);
            label15.TabIndex = 34;
            label15.Text = "(Add comma \",\" separated email Id's)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(458, 155);
            label14.Name = "label14";
            label14.Size = new Size(149, 20);
            label14.TabIndex = 33;
            label14.Text = "Interview Attendes :- ";
            // 
            // txtAttendes
            // 
            txtAttendes.Location = new Point(648, 151);
            txtAttendes.Name = "txtAttendes";
            txtAttendes.Size = new Size(298, 27);
            txtAttendes.TabIndex = 13;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(966, 100);
            label13.Name = "label13";
            label13.Size = new Size(76, 20);
            label13.TabIndex = 31;
            label13.Text = "Remark :- ";
            // 
            // txtRemark
            // 
            txtRemark.Location = new Point(1041, 19);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new Size(260, 212);
            txtRemark.TabIndex = 16;
            // 
            // cmbRounds
            // 
            cmbRounds.FormattingEnabled = true;
            cmbRounds.Location = new Point(225, 256);
            cmbRounds.Name = "cmbRounds";
            cmbRounds.Size = new Size(219, 28);
            cmbRounds.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(766, 25);
            label11.Name = "label11";
            label11.Size = new Size(59, 20);
            label11.TabIndex = 28;
            label11.Text = "Time :- ";
            // 
            // cmbdtpInterviewTime
            // 
            cmbdtpInterviewTime.FormattingEnabled = true;
            cmbdtpInterviewTime.Items.AddRange(new object[] { "9:00 AM", "9:15 AM", "9:30 AM", "9:45 AM", "10:00 AM", "10:15 AM", "10:30 AM", "10:45 AM", "11:00 AM", "11:15 AM", "11:30 AM", "11:45 AM", "12:00 PM", "12:15 PM", "12:30 PM", "12:45 PM", "1:00 PM", "1:15 PM", "1:30 PM", "1:45 PM", "2:00 PM", "2:15 PM", "2:30 PM", "2:45 PM", "3:00 PM", "3:15 PM", "3:30 PM", "3:45 PM", "4:00 PM", "4:15 PM", "4:30 PM", "4:45 PM", "5:00 PM", "5:15 PM", "5:30 PM", "5:45 PM", "6:00 PM", "6:15 PM", "6:30 PM", "6:45 PM", "7:00 PM", "7:15 PM", "7:30 PM", "7:45 PM", "8:00 PM", "8:15 PM", "8:30 PM", "8:45 PM", "9:00 PM", "9:15 PM", "9:30 PM", "9:45 PM", "10:00 PM", "10:15 PM", "10:30 PM", "10:45 PM", "11:00 PM", "11:15 PM", "11:30 PM", "11:45 PM" });
            cmbdtpInterviewTime.Location = new Point(831, 19);
            cmbdtpInterviewTime.Name = "cmbdtpInterviewTime";
            cmbdtpInterviewTime.Size = new Size(116, 28);
            cmbdtpInterviewTime.TabIndex = 10;
            // 
            // dtpInterviewDate
            // 
            dtpInterviewDate.CustomFormat = "MM/dd/yyyy";
            dtpInterviewDate.Format = DateTimePickerFormat.Custom;
            dtpInterviewDate.Location = new Point(649, 20);
            dtpInterviewDate.MinDate = new DateTime(2022, 3, 15, 0, 0, 0, 0);
            dtpInterviewDate.Name = "dtpInterviewDate";
            dtpInterviewDate.Size = new Size(106, 27);
            dtpInterviewDate.TabIndex = 9;
            // 
            // dtpLWD
            // 
            dtpLWD.CustomFormat = "MM/dd/yyyy";
            dtpLWD.Format = DateTimePickerFormat.Custom;
            dtpLWD.Location = new Point(225, 225);
            dtpLWD.MinDate = new DateTime(2022, 3, 15, 0, 0, 0, 0);
            dtpLWD.Name = "dtpLWD";
            dtpLWD.Size = new Size(121, 27);
            dtpLWD.TabIndex = 7;
            // 
            // btnDrop
            // 
            btnDrop.Location = new Point(999, 251);
            btnDrop.Name = "btnDrop";
            btnDrop.Size = new Size(94, 29);
            btnDrop.TabIndex = 17;
            btnDrop.Text = "Clear Data";
            btnDrop.UseVisualStyleBackColor = true;
            btnDrop.Click += btnDrop_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.Location = new Point(1199, 251);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(94, 29);
            btnSchedule.TabIndex = 19;
            btnSchedule.Text = "Schedule";
            btnSchedule.UseVisualStyleBackColor = true;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // cmbInterviewerNames
            // 
            cmbInterviewerNames.AccessibleRole = AccessibleRole.ScrollBar;
            cmbInterviewerNames.AllowDrop = true;
            cmbInterviewerNames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbInterviewerNames.DropDownHeight = 100000;
            cmbInterviewerNames.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInterviewerNames.FormattingEnabled = true;
            cmbInterviewerNames.IntegralHeight = false;
            cmbInterviewerNames.Location = new Point(649, 57);
            cmbInterviewerNames.MaxDropDownItems = 100;
            cmbInterviewerNames.MaximumSize = new Size(400, 0);
            cmbInterviewerNames.Name = "cmbInterviewerNames";
            cmbInterviewerNames.Size = new Size(300, 28);
            cmbInterviewerNames.TabIndex = 11;
            cmbInterviewerNames.SelectedIndexChanged += cmbInterviewerNames_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(458, 60);
            label10.Name = "label10";
            label10.Size = new Size(143, 20);
            label10.TabIndex = 20;
            label10.Text = "Interviewer Name :- ";
            // 
            // cmbSchedulers
            // 
            cmbSchedulers.FormattingEnabled = true;
            cmbSchedulers.Location = new Point(177, 24);
            cmbSchedulers.Name = "cmbSchedulers";
            cmbSchedulers.Size = new Size(266, 28);
            cmbSchedulers.TabIndex = 1;
            cmbSchedulers.SelectedIndexChanged += cmbSchedulers_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(34, 27);
            label12.Name = "label12";
            label12.Size = new Size(115, 20);
            label12.TabIndex = 20;
            label12.Text = "Scheduled By :- ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(34, 260);
            label9.Name = "label9";
            label9.Size = new Size(173, 20);
            label9.TabIndex = 19;
            label9.Text = "Interview Schedule for :- ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(458, 27);
            label8.Name = "label8";
            label8.Size = new Size(186, 20);
            label8.TabIndex = 15;
            label8.Text = "Interview Schedule Date :- ";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(649, 89);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(299, 28);
            cmbStatus.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(458, 92);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 13;
            label7.Text = "Interview Status :- ";
            // 
            // cmbLocation
            // 
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(225, 191);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(218, 28);
            cmbLocation.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 225);
            label6.Name = "label6";
            label6.Size = new Size(147, 20);
            label6.TabIndex = 10;
            label6.Text = "Last Working Date :- ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 195);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 8;
            label5.Text = "Location :- ";
            // 
            // txtSkills
            // 
            txtSkills.Location = new Point(225, 157);
            txtSkills.Name = "txtSkills";
            txtSkills.Size = new Size(218, 27);
            txtSkills.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 161);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 6;
            label4.Text = "Skills :- ";
            // 
            // txtCandEmail
            // 
            txtCandEmail.Location = new Point(177, 92);
            txtCandEmail.Name = "txtCandEmail";
            txtCandEmail.Size = new Size(266, 27);
            txtCandEmail.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 95);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 4;
            label3.Text = "Email :- ";
            // 
            // txtCondMobile
            // 
            txtCondMobile.Location = new Point(177, 125);
            txtCondMobile.Name = "txtCondMobile";
            txtCondMobile.Size = new Size(266, 27);
            txtCondMobile.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 128);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 2;
            label2.Text = "Mobile No :- ";
            // 
            // txtCondName
            // 
            txtCondName.Location = new Point(177, 59);
            txtCondName.Name = "txtCondName";
            txtCondName.Size = new Size(266, 27);
            txtCondName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 61);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 0;
            label1.Text = "Candidate Name :- ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvCandList);
            groupBox2.Location = new Point(8, 414);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1307, 308);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Candidates";
            // 
            // dgvCandList
            // 
            dgvCandList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCandList.Dock = DockStyle.Fill;
            dgvCandList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCandList.GridColor = SystemColors.ActiveCaption;
            dgvCandList.Location = new Point(3, 23);
            dgvCandList.MultiSelect = false;
            dgvCandList.Name = "dgvCandList";
            dgvCandList.RowHeadersWidth = 51;
            dgvCandList.RowTemplate.Height = 29;
            dgvCandList.Size = new Size(1301, 282);
            dgvCandList.TabIndex = 0;
            dgvCandList.CellDoubleClick += dgvCandList_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(849, 381);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(351, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1207, 380);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminPanelToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1323, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // adminPanelToolStripMenuItem
            // 
            adminPanelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addInterviewerToolStripMenuItem, addRecriuteeToolStripMenuItem });
            adminPanelToolStripMenuItem.Name = "adminPanelToolStripMenuItem";
            adminPanelToolStripMenuItem.Size = new Size(106, 24);
            adminPanelToolStripMenuItem.Text = "Admin Panel";
            // 
            // addInterviewerToolStripMenuItem
            // 
            addInterviewerToolStripMenuItem.Name = "addInterviewerToolStripMenuItem";
            addInterviewerToolStripMenuItem.Size = new Size(197, 26);
            addInterviewerToolStripMenuItem.Text = "Add Interviewer";
            addInterviewerToolStripMenuItem.Click += addInterviewerToolStripMenuItem_Click;
            // 
            // addRecriuteeToolStripMenuItem
            // 
            addRecriuteeToolStripMenuItem.Name = "addRecriuteeToolStripMenuItem";
            addRecriuteeToolStripMenuItem.Size = new Size(197, 26);
            addRecriuteeToolStripMenuItem.Text = "Add Recruiter";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 728);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Interview Scheduler - WonderBiz@2022";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCandList).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtCandEmail;
        private Label label3;
        private TextBox txtCondMobile;
        private Label label2;
        private TextBox txtCondName;
        private Label label1;
        private ComboBox cmbLocation;
        private TextBox txtSkills;
        private ComboBox cmbStatus;
        private Label label7;
        private Label label9;
        private Label label8;
        private ComboBox cmbInterviewerNames;
        private Label label10;
        private ComboBox cmbSchedulers;
        private Label label12;
        private Button btnSchedule;
        private Button btnDrop;
        private GroupBox groupBox2;
        private DataGridView dgvCandList;
        private DateTimePicker dtpLWD;
        private Label label11;
        private ComboBox cmbdtpInterviewTime;
        private DateTimePicker dtpInterviewDate;
        private Label label13;
        private TextBox txtRemark;
        private ComboBox cmbRounds;
        private Label label14;
        private TextBox txtAttendes;
        private Label label15;
        private TextBox txtFeedbackLink;
        private Label label18;
        private TextBox txtResumeLink;
        private Label label19;
        private Button btnSave;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnSingleOpenFileDialog;
        private OpenFileDialog openFileDialog1;
        private ComboBox cmbDuration;
        private TextBox txtGoogleMeetUrl;
        private Label lblGoogleMeetUrl;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminPanelToolStripMenuItem;
        private ToolStripMenuItem addInterviewerToolStripMenuItem;
        private ToolStripMenuItem addRecriuteeToolStripMenuItem;
    }
}
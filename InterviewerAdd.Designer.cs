namespace InterViewScheduler
{
    partial class InterviewerAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterviewerAdd));
            dropDownItem1 = new ColorPicker();
            dropDownItem2 = new ColorPicker();
            groupBox1 = new GroupBox();
            RecordId = new Label();
            colorPicker1 = new ColorPicker();
            btnSave = new Button();
            txtPasscode = new TextBox();
            txtMeetingId = new TextBox();
            txtZoomURL = new TextBox();
            txtInterviewerEmail = new TextBox();
            txtName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label12 = new Label();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dropDownItem1
            // 
            dropDownItem1.Location = new Point(0, 0);
            dropDownItem1.Name = "dropDownItem1";
            dropDownItem1.Size = new Size(121, 28);
            dropDownItem1.TabIndex = 0;
            // 
            // dropDownItem2
            // 
            dropDownItem2.Location = new Point(0, 0);
            dropDownItem2.Name = "dropDownItem2";
            dropDownItem2.Size = new Size(121, 28);
            dropDownItem2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RecordId);
            groupBox1.Controls.Add(colorPicker1);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtPasscode);
            groupBox1.Controls.Add(txtMeetingId);
            groupBox1.Controls.Add(txtZoomURL);
            groupBox1.Controls.Add(txtInterviewerEmail);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label12);
            groupBox1.Location = new Point(12, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(768, 288);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Interviewer Details";
            // 
            // RecordId
            // 
            RecordId.AutoSize = true;
            RecordId.Location = new Point(35, 18);
            RecordId.Name = "RecordId";
            RecordId.Size = new Size(0, 20);
            RecordId.TabIndex = 36;
            RecordId.Visible = false;
            // 
            // colorPicker1
            // 
            colorPicker1.DrawMode = DrawMode.OwnerDrawFixed;
            colorPicker1.DropDownStyle = ComboBoxStyle.DropDownList;
            colorPicker1.FormattingEnabled = true;
            colorPicker1.Location = new Point(319, 213);
            colorPicker1.Name = "colorPicker1";
            colorPicker1.Size = new Size(424, 28);
            colorPicker1.TabIndex = 35;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(649, 247);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 33;
            btnSave.Text = "Save Data";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtPasscode
            // 
            txtPasscode.Location = new Point(319, 173);
            txtPasscode.Name = "txtPasscode";
            txtPasscode.Size = new Size(424, 27);
            txtPasscode.TabIndex = 31;
            // 
            // txtMeetingId
            // 
            txtMeetingId.Location = new Point(319, 137);
            txtMeetingId.Name = "txtMeetingId";
            txtMeetingId.Size = new Size(424, 27);
            txtMeetingId.TabIndex = 30;
            // 
            // txtZoomURL
            // 
            txtZoomURL.Location = new Point(319, 102);
            txtZoomURL.Name = "txtZoomURL";
            txtZoomURL.Size = new Size(424, 27);
            txtZoomURL.TabIndex = 29;
            // 
            // txtInterviewerEmail
            // 
            txtInterviewerEmail.Location = new Point(319, 67);
            txtInterviewerEmail.Name = "txtInterviewerEmail";
            txtInterviewerEmail.Size = new Size(424, 27);
            txtInterviewerEmail.TabIndex = 28;
            // 
            // txtName
            // 
            txtName.Location = new Point(319, 34);
            txtName.Name = "txtName";
            txtName.Size = new Size(424, 27);
            txtName.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 213);
            label5.Name = "label5";
            label5.Size = new Size(178, 20);
            label5.TabIndex = 26;
            label5.Text = "Interviewer Color Code :- ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 176);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 25;
            label4.Text = "Passcode :- ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 140);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 24;
            label3.Text = "Meeting Id :- ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 105);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 23;
            label2.Text = "Zoom URL :-";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 70);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 22;
            label1.Text = "Interviewer Email :- ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(28, 37);
            label12.Name = "label12";
            label12.Size = new Size(66, 20);
            label12.TabIndex = 21;
            label12.Text = "Name :- ";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 319);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(788, 193);
            dataGridView1.TabIndex = 24;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // InterviewerAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 524);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(810, 571);
            Name = "InterviewerAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Interviewer";
            Load += InterviewerAdd_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnSave;
        private TextBox txtPasscode;
        private TextBox txtMeetingId;
        private TextBox txtZoomURL;
        private TextBox txtInterviewerEmail;
        private TextBox txtName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label12;
        private DataGridView dataGridView1;
        private ColorPicker colorPicker1;
        private ColorPicker dropDownItem1;
        private ColorPicker dropDownItem2;
        private Label RecordId;
    }
}
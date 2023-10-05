using CalendarQuickstart;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Drive.v3.Data;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InterViewScheduler
{
    public partial class Form1 : Form
    {
        public string ApplicationName = "";
        public MailContaint mailContaint = null;
        public GoogleSheetParameters gsp = null;
        private int EditedRowId = 0;
        private string DefaultColorNo = "1";
        private string DefaultInterViewerColorCode = "1";
        public Form1()
        {
            try
            {
                InitializeComponent();
                Shown += OnShown;
                using (StreamReader r = new StreamReader("Details.json"))
                {
                    string json = r.ReadToEnd();
                    mailContaint = JsonConvert.DeserializeObject<MailContaint>(json);
                    gsp = JsonConvert.DeserializeObject<GoogleSheetParameters>(json);
                    r.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void OnShown(object sender, EventArgs e)
        {
            txtGoogleMeetUrl.Text = "GoogleMeetLink";
            cmbLocation.DataSource = JsonOperations.ReadLocations().Locations.OrderBy(location => location.Location).ToList();
            cmbLocation.DisplayMember = "Location";
            cmbLocation.ValueMember = "Id";
            cmbInterviewerNames.DataSource = JsonOperations.ReadInterviewers().Interviewers.OrderBy(Interviewer => Interviewer.Name).ToList();
            cmbStatus.DataSource = JsonOperations.ReadFinalStatus().FinalStatus.OrderBy(status => status.Status).ToList();
            cmbSchedulers.DataSource = JsonOperations.ReadSchedulers().Schedulers.OrderBy(Schedulers => Schedulers.Name).ToList();
            cmbRounds.DataSource = JsonOperations.ReadMailTemplates().Template.OrderBy(MailTemplate => MailTemplate.Id).ToList();

            using (StreamReader r = new StreamReader("Details.json"))
            {
                string json = r.ReadToEnd();
                mailContaint = JsonConvert.DeserializeObject<MailContaint>(json);
                gsp = JsonConvert.DeserializeObject<GoogleSheetParameters>(json);
                r.Close();
            }

            GoogleSheetsHelper googleSheetsHelper = new GoogleSheetsHelper(mailContaint.SpreadsheetId);
            //var gsp = new GoogleSheetParameters() { RangeColumnStart, RangeRowStart = 1, RangeColumnEnd = 12, RangeRowEnd = 100, FirstRowIsHeaders = true, SheetName = "sheet1" };

            DataTable dataTable = googleSheetsHelper.ToDataTable(googleSheetsHelper.GetDataFromSheet(gsp));
            dgvCandList.DataSource = dataTable;



        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {

            CandidateDetails candidateDetails = new CandidateDetails();



            try
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;

                if (EditedRowId > 0)
                {
                    candidateDetails.Id = EditedRowId;
                    candidateDetails.RecordType = "Update";
                }
                else
                {
                    candidateDetails.Id = (dgvCandList.RowCount <= 0) ? 1 : dgvCandList.RowCount + 1;
                }
                candidateDetails.SchedulersName = ((InterViewScheduler.Schedulers)cmbSchedulers.SelectedItem).Name;
                candidateDetails.SchedulersEmail = ((InterViewScheduler.Schedulers)cmbSchedulers.SelectedItem).Email;
                candidateDetails.Name = txtCondName.Text;
                candidateDetails.Email = txtCandEmail.Text;
                candidateDetails.Mobile = txtCondMobile.Text;
                candidateDetails.Skills = txtSkills.Text;
                candidateDetails.Location = ((InterViewScheduler.Locations)cmbLocation.SelectedItem).Location;
                //CultureInfo culture = new CultureInfo("en-US");
                candidateDetails.LastWorkingDate = dtpLWD.Text;
                candidateDetails.InterViewRound = ((InterViewScheduler.Template)cmbRounds.SelectedItem).Id;
                candidateDetails.InterviewDateTime = dtpInterviewDate.Text + " " + cmbdtpInterviewTime.Text;//Convert.ToDateTime(dtpInterviewDate.Text + " " + cmbdtpInterviewTime.Text, CultureInfo.InvariantCulture);
                candidateDetails.InterViewerName = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).Name;
                candidateDetails.CreatedDate = DateTime.Now.ToShortDateString();
                candidateDetails.Comment = txtRemark.Text;
                candidateDetails.ResumeLink = txtResumeLink.Text;
                candidateDetails.FeedbackLink = txtFeedbackLink.Text;

                candidateDetails.InterViewerEmail = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).interviewerEmail;
                candidateDetails.ZoomUrl = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).ZoomUrl;
                candidateDetails.PassCode = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).PassCode;
                candidateDetails.MeettingId = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).MeettingId;
                candidateDetails.InterViewStatus = ((InterViewScheduler.FinalStatus)cmbStatus.SelectedItem).Status;

                candidateDetails.CandidateDescription = ((InterViewScheduler.Template)cmbRounds.SelectedItem).CandidateDescription;
                candidateDetails.InterViewerDescription = ((InterViewScheduler.Template)cmbRounds.SelectedItem).InterViewerDescription;
                if (candidateDetails.InterViewRound == "1st Round Interview")
                {
                    candidateDetails.Summary = "Invitation for the first round interview with WonderBiz for the " + candidateDetails.Skills;
                }
                else
                {
                    candidateDetails.Summary = "Invitation for the second round interview with WonderBiz for the " + candidateDetails.Skills;
                }
                candidateDetails.Attendes = txtAttendes.Text;

                candidateDetails.GoogleMeetLink = txtGoogleMeetUrl.Text;
                if (!IsAnyNullOrEmpty(candidateDetails))
                {
                    if (cmbDuration.Text != "")
                    {
                        candidateDetails.Duration = Convert.ToInt32(cmbDuration.Text);
                    }
                    else
                    {
                        candidateDetails.Duration = 60;
                    }

                    /*Uplaod files*/

                    if (txtResumeLink.Text != "" && System.IO.File.Exists(txtResumeLink.Text))
                    {
                        var uplaodFileName = UploadFile();
                        candidateDetails.ResumeLink = uplaodFileName;
                    }
                    else
                    {
                        candidateDetails.ResumeLink = txtResumeLink.Text;
                    }
                    /*End Upload Files*/


                    using (StreamReader r = new StreamReader("Details.json"))
                    {
                        string json = r.ReadToEnd();
                        mailContaint = JsonConvert.DeserializeObject<MailContaint>(json);
                        gsp = JsonConvert.DeserializeObject<GoogleSheetParameters>(json);
                        r.Close();
                    }
                    //var gsp = new GoogleSheetParameters() { RangeColumnStart = 1, RangeRowStart = 1, RangeColumnEnd = 12, RangeRowEnd = 100, FirstRowIsHeaders = true, SheetName = "sheet1" };

                    /*Color Code*/
                    candidateDetails.InterViewerColorCode = DefaultInterViewerColorCode;
                    candidateDetails.ColorCode = DefaultColorNo;
                    /*End Color Code*/




                    GoogleCalendarHelper googleCalendarHelper = new GoogleCalendarHelper(mailContaint.SpreadsheetId);

                    Event response = googleCalendarHelper.ScheduleCandidateInterview(candidateDetails);
                    candidateDetails.Summary = txtCondName.Text + " - " + txtSkills.Text + " " + candidateDetails.Location + " @ " + cmbdtpInterviewTime.Text;
                    candidateDetails.ZoomUrl = response.HangoutLink;
                    candidateDetails.GoogleMeetLink = response.HangoutLink;


                    GoogleSheetsHelper googleSheetsHelper = new GoogleSheetsHelper(mailContaint.SpreadsheetId);
                    googleSheetsHelper.AddRow(gsp, candidateDetails);



                    googleCalendarHelper.ScheduleInterViewerInterview(candidateDetails);


                    if (cmbStatus.SelectedValue.ToString() == "Selected")
                    {
                        if (candidateDetails.GoogleMeetLink != "GoogleMeetLink")
                            CopyVideo(candidateDetails.GoogleMeetLink);
                    }

                    ClearData();
                    OnShown(null, null);
                    MessageBox.Show("Data successfully save and Schedule Interview for set date and time.");
                }
                else
                {
                    MessageBox.Show("Please fill all the fields.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void dgvCandList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dataIndexNo = dgvCandList.Rows[e.RowIndex].Index.ToString();
                EditedRowId = Convert.ToInt32(dgvCandList.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCondName.Text = dgvCandList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCondMobile.Text = dgvCandList.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCandEmail.Text = dgvCandList.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSkills.Text = dgvCandList.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbLocation.SelectedItem = (cmbLocation.DataSource as List<Locations>).First(x => x.Location.Equals(dgvCandList.Rows[e.RowIndex].Cells[5].Value.ToString()));
                dtpLWD.Text = Convert.ToDateTime(dgvCandList.Rows[e.RowIndex].Cells[6].Value.ToString(), CultureInfo.InvariantCulture).ToString();
                cmbSchedulers.SelectedItem = (cmbSchedulers.DataSource as List<Schedulers>).First(x => x.Name.Equals(dgvCandList.Rows[e.RowIndex].Cells[7].Value.ToString()));
                cmbStatus.SelectedItem = (cmbStatus.DataSource as List<FinalStatus>).First(x => x.Status.Equals(dgvCandList.Rows[e.RowIndex].Cells[9].Value.ToString()));
                txtRemark.Text = dgvCandList.Rows[e.RowIndex].Cells[10].Value.ToString();
                cmbRounds.SelectedItem = (cmbRounds.DataSource as List<Template>).First(x => x.Id.Equals(dgvCandList.Rows[e.RowIndex].Cells[11].Value.ToString()));
                DateTime dt = Convert.ToDateTime(dgvCandList.Rows[e.RowIndex].Cells[12].Value.ToString(), CultureInfo.InvariantCulture); ;
                String time12 = dt.ToString("h:mm tt", CultureInfo.InvariantCulture);
                dtpInterviewDate.Text = Convert.ToDateTime(dgvCandList.Rows[e.RowIndex].Cells[12].Value.ToString().Split(' ')[0].ToString(), CultureInfo.InvariantCulture).ToString();
                cmbdtpInterviewTime.Text = time12;
                cmbInterviewerNames.SelectedItem = (cmbInterviewerNames.DataSource as List<Interviewers>).First(x => x.Name.Equals(dgvCandList.Rows[e.RowIndex].Cells[13].Value.ToString()));
                txtAttendes.Text = dgvCandList.Rows[e.RowIndex].Cells[14].Value.ToString();
                txtResumeLink.Text = dgvCandList.Rows[e.RowIndex].Cells[15].Value.ToString();
                txtFeedbackLink.Text = dgvCandList.Rows[e.RowIndex].Cells[16].Value.ToString();
                cmbDuration.Text = dgvCandList.Rows[e.RowIndex].Cells[17].Value.ToString();
                if (dgvCandList.Rows[e.RowIndex].Cells[18].Value.ToString() == "")
                {
                    txtGoogleMeetUrl.Text = "GoogleMeetLink";
                }
                else
                {
                    txtGoogleMeetUrl.Text = dgvCandList.Rows[e.RowIndex].Cells[18].Value.ToString();
                }

            }
        }

        private void ClearData()
        {
            EditedRowId = 0;
            txtCondName.Text = "";
            txtCondMobile.Text = "";
            txtCandEmail.Text = "";
            txtSkills.Text = "";
            dtpLWD.Text = DateTime.Now.ToString();
            txtRemark.Text = "";
            dtpInterviewDate.Text = DateTime.Now.ToString();
            txtAttendes.Text = "";
            txtResumeLink.Text = "";
            txtFeedbackLink.Text = "";
            txtGoogleMeetUrl.Text = "";
            txtGoogleMeetUrl.Text = "GoogleMeetLink";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CandidateDetails candidateDetails = new CandidateDetails();



            try
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;

                if (EditedRowId > 0)
                {
                    candidateDetails.Id = EditedRowId;
                    candidateDetails.RecordType = "Update";
                }
                else
                {
                    candidateDetails.Id = (dgvCandList.RowCount <= 0) ? 1 : dgvCandList.RowCount + 1;
                }
                candidateDetails.SchedulersName = ((InterViewScheduler.Schedulers)cmbSchedulers.SelectedItem).Name;
                candidateDetails.SchedulersEmail = ((InterViewScheduler.Schedulers)cmbSchedulers.SelectedItem).Email;
                candidateDetails.Name = txtCondName.Text;
                candidateDetails.Email = txtCandEmail.Text;
                candidateDetails.Mobile = txtCondMobile.Text;

                candidateDetails.FeedbackLink = txtFeedbackLink.Text;

                candidateDetails.Skills = txtSkills.Text;
                candidateDetails.Location = ((InterViewScheduler.Locations)cmbLocation.SelectedItem).Location;
                //CultureInfo culture = new CultureInfo("en-US");
                candidateDetails.LastWorkingDate = dtpLWD.Text;
                candidateDetails.InterViewRound = ((InterViewScheduler.Template)cmbRounds.SelectedItem).Id;
                candidateDetails.InterviewDateTime = dtpInterviewDate.Text + " " + cmbdtpInterviewTime.Text;//Convert.ToDateTime(dtpInterviewDate.Text + " " + cmbdtpInterviewTime.Text, CultureInfo.InvariantCulture);
                candidateDetails.InterViewerName = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).Name;
                candidateDetails.CreatedDate = DateTime.Now.ToShortDateString();
                candidateDetails.Comment = txtRemark.Text;

                candidateDetails.InterViewerEmail = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).interviewerEmail;
                candidateDetails.ZoomUrl = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).ZoomUrl;
                candidateDetails.PassCode = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).PassCode;
                candidateDetails.MeettingId = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).MeettingId;
                candidateDetails.InterViewStatus = ((InterViewScheduler.FinalStatus)cmbStatus.SelectedItem).Status;

                candidateDetails.CandidateDescription = ((InterViewScheduler.Template)cmbRounds.SelectedItem).CandidateDescription;
                candidateDetails.InterViewerDescription = ((InterViewScheduler.Template)cmbRounds.SelectedItem).InterViewerDescription;

                candidateDetails.GoogleMeetLink = txtGoogleMeetUrl.Text;

                if (candidateDetails.InterViewRound == "1st Round Interview")
                {
                    candidateDetails.Summary = "Invitation for the first round interview with WonderBiz for the " + candidateDetails.Skills;
                }
                else
                {
                    candidateDetails.Summary = "Invitation for the second round interview with WonderBiz for the " + candidateDetails.Skills;
                }
                candidateDetails.Attendes = txtAttendes.Text;
                if (!IsAnyNullOrEmpty(candidateDetails))
                {

                    if (cmbDuration.Text != "")
                    {
                        candidateDetails.Duration = Convert.ToInt32(cmbDuration.Text);
                    }
                    else
                    {
                        candidateDetails.Duration = 60;
                    }

                    /*Uplaod files*/

                    if (txtResumeLink.Text != "" && System.IO.File.Exists(txtResumeLink.Text))
                    {
                        var uplaodFileName = UploadFile();
                        candidateDetails.ResumeLink = uplaodFileName;
                    }
                    else
                    {
                        candidateDetails.ResumeLink = txtResumeLink.Text;
                    }
                    /*End Upload Files*/



                    using (StreamReader r = new StreamReader("Details.json"))
                    {
                        string json = r.ReadToEnd();
                        mailContaint = JsonConvert.DeserializeObject<MailContaint>(json);
                        gsp = JsonConvert.DeserializeObject<GoogleSheetParameters>(json);
                        r.Close();
                    }
                    //var gsp = new GoogleSheetParameters() { RangeColumnStart = 1, RangeRowStart = 1, RangeColumnEnd = 12, RangeRowEnd = 100, FirstRowIsHeaders = true, SheetName = "sheet1" };

                    GoogleSheetsHelper googleSheetsHelper = new GoogleSheetsHelper(mailContaint.SpreadsheetId);
                    googleSheetsHelper.AddRow(gsp, candidateDetails);




                    if (cmbStatus.SelectedValue.ToString() == "Selected")
                    {
                        if (candidateDetails.GoogleMeetLink != "GoogleMeetLink")
                            CopyVideo(candidateDetails.GoogleMeetLink);
                    }

                    ClearData();
                    OnShown(null, null);
                    MessageBox.Show("Data successfully save.");
                }
                else
                {
                    MessageBox.Show("Please fill all the fields.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (StreamReader r = new StreamReader("Details.json"))
            {
                string json = r.ReadToEnd();
                mailContaint = JsonConvert.DeserializeObject<MailContaint>(json);
                gsp = JsonConvert.DeserializeObject<GoogleSheetParameters>(json);
                r.Close();
            }
            GoogleSheetsHelper googleSheetsHelper = new GoogleSheetsHelper(mailContaint.SpreadsheetId);
            //var gsp = new GoogleSheetParameters() { RangeColumnStart, RangeRowStart = 1, RangeColumnEnd = 12, RangeRowEnd = 100, FirstRowIsHeaders = true, SheetName = "sheet1" };
            DataTable dt = googleSheetsHelper.ToDataTable(googleSheetsHelper.GetDataFromSheet(gsp));
            DataTable fdt = dt.Select("[Name Of Candidate] LIKE '%" + txtSearch.Text + "%' OR [Location] LIKE '%" + txtSearch.Text + "%'").CopyToDataTable();
            //DataTable fdt = new DataTable();
            //foreach (DataRow dr in drs)
            //{
            //    fdt.Rows.Add(dr);
            // }
            //fdt.AcceptChanges();
            dgvCandList.DataSource = fdt;
        }


        private void btnSingleOpenFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Resume";
            openFileDialog1.DefaultExt = ".docx";
            //openFileDialog1.InitialDirectory = @"%USERPROFILE%\Downloads";

            openFileDialog1.InitialDirectory = GetDownloadsPath();

            openFileDialog1.Filter = "docx files (*.docx)|*.docx|doc files (*.doc)|*.doc|pdf files (*.pdf)|*.pdf";

            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtResumeLink.Text = openFileDialog1.FileName;

            }
        }
        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);
        public static string GetDownloadsPath()
        {
            string path = null;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                IntPtr pathPtr;
                int hr = SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
                if (hr == 0)
                {
                    path = Marshal.PtrToStringUni(pathPtr);
                    Marshal.FreeCoTaskMem(pathPtr);
                    return path;
                }
            }
            path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            return path;
        }

        public string UploadFile()
        {
            GoogleDriveHelper googleDriveHelper = new GoogleDriveHelper();
            string candidateFolderID = "";
            string parentFolderID = "";
            string parentFolderName = "ShdInterview";
            string candidateFolderName = txtCondName.Text + "_" + txtSkills.Text;

            string filePath = txtResumeLink.Text;
            var filename = Path.GetFileName(filePath);

            FileInfo fi = new FileInfo(filePath);

            var newFileName = "resume-" + txtCondName.Text.Trim() + fi.Extension;


            parentFolderID = googleDriveHelper.FolderExists(parentFolderName);
            if (parentFolderID == "")
            {
                parentFolderID = googleDriveHelper.CreateFolder(parentFolderName);
            }

            candidateFolderID = googleDriveHelper.FolderExists(candidateFolderName, parentFolderID);

            if (candidateFolderID == "")
            {
                candidateFolderID = googleDriveHelper.CreateFolder(candidateFolderName, parentFolderID);
            }

            var fileID = googleDriveHelper.getFile(newFileName, candidateFolderID);

            if (fileID != "")
            {
                var a = googleDriveHelper.UploadFile(filePath, newFileName, candidateFolderID, "UPDATE", fileID);

                //googleDriveHelper.getSharedLink(a);
            }
            else
            {
                var a = googleDriveHelper.UploadFile(filePath, newFileName, candidateFolderID);
                //  googleDriveHelper.getSharedLink(a);
            }

            return newFileName;
        }

        public void CopyVideo(string GoogleMeetUrl)
        {


            GoogleDriveHelper googleDriveHelper = new GoogleDriveHelper();

            /*Check for parent folder*/
            string parentFolderName = "ShdInterview";
            var parentFolderID = googleDriveHelper.FolderExists(parentFolderName);
            if (parentFolderID == "")
            {
                parentFolderID = googleDriveHelper.CreateFolder(parentFolderName);
            }

            /*Check candidate folder exists*/
            string candidateFolderName = txtCondName.Text + "_" + txtSkills.Text;
            var candidateFolderID = googleDriveHelper.FolderExists(candidateFolderName, parentFolderID);

            if (candidateFolderID == "")
            {
                candidateFolderID = googleDriveHelper.CreateFolder(candidateFolderName, parentFolderID);
            }

            /*Check if video folder exists*/
            //var  currentVideoFolderID =   googleDriveHelper.FolderExists("Meet Recordings");
            var candidateVideoFileID = googleDriveHelper.getFiles(txtCondName.Text, candidateFolderID);

            /*Delete files*/
            //foreach (var fileId in candidateVideoFileID) {
            //    googleDriveHelper.DeleteFile(fileId);
            //}
            /*Copy files*/
            //CopyFiles(sourceFileID, destinationFolderID);



            /*Candidate video copy and paste*/
            var currentVideoFolderID = googleDriveHelper.FolderExists("Meet Recordings");
            var mainVideoFileID = googleDriveHelper.getFiles(GoogleMeetUrl.Split('/').Last(), currentVideoFolderID);
            foreach (var f in mainVideoFileID)
            {
                //var videFileName = "video-" + f.Value;

                var videFileName = f.Value;

                var isVideoFileExists = googleDriveHelper.getFiles(videFileName, candidateFolderID);

                if (isVideoFileExists.Count == 0)
                {
                    googleDriveHelper.CopyFiles(f.Key, candidateFolderID, videFileName);
                }


            }
        }

        private void cmbSchedulers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefaultColorNo = ((InterViewScheduler.Schedulers)cmbSchedulers.SelectedItem).ColorCode;

            //JsonOperations.ReadSchedulers().Schedulers.OrderBy(Schedulers => Schedulers.Name).ToList();
        }

        private void cmbInterviewerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefaultInterViewerColorCode = ((InterViewScheduler.Interviewers)cmbInterviewerNames.SelectedItem).InterViewerColorCode;
        }

        private void addInterviewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterviewerAdd interviewerAdd = new InterviewerAdd();
            interviewerAdd.ShowDialog();
        }
    }
}
using CalendarQuickstart;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace InterViewScheduler
{
    public class GoogleCalendarHelper
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "GoogleCalendarHelper";

        private readonly CalendarService _calService;
        private readonly string _spreadsheetId;

        public GoogleCalendarHelper(string spreadsheetId)
        {
            try
            {
                //UserCredential credential;
                //using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                //{
                //    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                //    credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart");
                //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                //        GoogleClientSecrets.Load(stream).Secrets,
                //        new[] {
                //        CalendarService.Scope.Calendar
                //        },
                //        "user",
                //        CancellationToken.None,
                //        new FileDataStore(credPath, true)).Result;
                //}

                //// Create Google SpredSheet API service.
                //_calService = new CalendarService(new BaseClientService.Initializer()
                //{
                //    HttpClientInitializer = credential,
                //    ApplicationName = ApplicationName,
                //});
                GoogleServiceHelper googleServiceHelper = new GoogleServiceHelper();
                _calService = googleServiceHelper.GetCalendarService();

                _spreadsheetId = spreadsheetId;
            }
            catch
            {
                throw;
            }
        }

        public Event ScheduleCandidateInterview(CandidateDetails candidateDetails)
        {


            if (candidateDetails.RecordType == "Update")
            {
                //List<Appointment> list = new List<Appointment>();
                //Appointment listn = GetEvents().Find(x => x.Subject.Equals(candidateDetails.Summary));
                //if (listn != null)
                //{
                //    EventsResource.DeleteRequest request1 = _calService.Events.Delete("primary", listn.Id);
                //    request1.Execute();
                //}
            }

            candidateDetails.CandidateDescription = candidateDetails.CandidateDescription.Replace("{CandName}", candidateDetails.Name).Replace("{CandPosition}", candidateDetails.Skills).Replace("{InterviewDate}", candidateDetails.InterviewDateTime.Split(' ')[0]).Replace("{InterviewTime}", candidateDetails.InterviewDateTime.Split(' ')[1]).Replace("{ZoomUrl}", candidateDetails.ZoomUrl).Replace("{MeetingId}", candidateDetails.MeettingId).Replace("{PassCode}", candidateDetails.PassCode);

            Event body = new Event();
           
            
            List<EventAttendee> attendes = new List<EventAttendee>();
            string[] str = candidateDetails.Attendes.Trim().Split(',');
            foreach (string e in str)
            {
                EventAttendee a = new EventAttendee();
                a.Email = e;
                attendes.Add(a);
            }

            body.ConferenceData = new ConferenceData
            {
                CreateRequest = new CreateConferenceRequest
                {
                    //RequestId = "1234abcdef",
                    RequestId = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"),
                    ConferenceSolutionKey = new ConferenceSolutionKey
                    {
                        Type = "hangoutsMeet"
                    },
                    Status = new ConferenceRequestStatus
                    {
                        StatusCode = "success"
                    }
                },
                EntryPoints = new List<EntryPoint>
                    {
                        new EntryPoint
                        {
                            EntryPointType = "video",
                            Uri = "",
                            Label = ""
                        }
                    },
                ConferenceSolution = new ConferenceSolution
                {
                    Key = new ConferenceSolutionKey
                    {
                        Type = "hangoutsMeet"
                    },
                    Name = "Google Meet",
                    IconUri = ""
                },
                ConferenceId = ""
            };




            EventAttendee b = new EventAttendee();
            b.Email = candidateDetails.Email.Trim();
            b.ResponseStatus = "accepted";
            attendes.Add(b);
            body.Attendees = attendes;

            /*06-12-2022/
            /*Attchment*/
            GoogleDriveHelper googleDriveHelper = new GoogleDriveHelper();
           var resumeID =   googleDriveHelper.getFile(candidateDetails.ResumeLink);
            // var resumeID = googleDriveHelper.FileExists(candidateDetails.ResumeLink);
            //FileExists

            //if (resumeID != "")
            //{
            //    body.Attachments = googleDriveHelper.AttachedGoogleDriveFile(resumeID);
            //}
            //else {
            //    //  body.Attachments = candidateDetails.ResumeLink;
            //    // if (candidateDetails.ResumeLink.Contains("edit?usp=share_link"))
            //    if (candidateDetails.ResumeLink.Trim() != "")
            //        candidateDetails.CandidateDescription += "\n\n\n\n Resume Link:\t  " + candidateDetails.ResumeLink;
                
            //}

            //if (candidateDetails.FeedbackLink != "")
            //{
            //    candidateDetails.CandidateDescription += "\n\n\n\n Feedback Link:\t  " + candidateDetails.FeedbackLink;
            //}

            /*End Attchmed*/



            EventDateTime start = new EventDateTime();
            start.DateTime = Convert.ToDateTime(candidateDetails.InterviewDateTime, CultureInfo.InvariantCulture);
            EventDateTime end = new EventDateTime();
            //end.DateTime = Convert.ToDateTime(candidateDetails.InterviewDateTime, CultureInfo.InvariantCulture).AddMinutes(60);
            end.DateTime = Convert.ToDateTime(candidateDetails.InterviewDateTime, CultureInfo.InvariantCulture).AddMinutes(candidateDetails.Duration);
            body.Start = start;
            body.End = end;
            body.Location = candidateDetails.Location;
            body.Description = candidateDetails.CandidateDescription;
            body.Summary = candidateDetails.Summary;

            //  body.ColorId = candidateDetails.ColorCode;

            body.ColorId = "7";

            //  EventsResource.InsertRequest request = new EventsResource.InsertRequest(_calService, body, candidateDetails.SchedulersEmail);
            EventsResource.InsertRequest request = new EventsResource.InsertRequest(_calService, body, "interviews@wonderbiz.in");

            Event response = null;
            try
            {
                //interviews@wonderbiz.in
                request.SendNotifications = true;
                request.ConferenceDataVersion = 1;
                request.SupportsAttachments = true;
                response = request.Execute();
            }
            catch (Exception)
            {

                throw;
            }

            return response;

           // string url = response.HangoutLink;
        }
        public void ScheduleInterViewerInterview(CandidateDetails candidateDetails)
        {
            if (candidateDetails.RecordType == "Update")
            {
                //List<Appointment> list = new List<Appointment>();
                //Appointment listn = GetEvents().Find(x => x.Subject.Equals(candidateDetails.Summary));
                //if (listn != null)
                //{
                //    EventsResource.DeleteRequest request1 = _calService.Events.Delete("primary", listn.Id);
                //    request1.Execute();
                //}
            }

            candidateDetails.InterViewerDescription = candidateDetails.InterViewerDescription.Replace("{InterviewerName}", candidateDetails.InterViewerName).Replace("{CandidateName}", candidateDetails.Name).Replace("{CandMobile}", candidateDetails.Mobile).Replace("{CandEmail}", candidateDetails.Email).Replace("{ZoomUrl}", candidateDetails.ZoomUrl).Replace("{MeetingId}", candidateDetails.MeettingId).Replace("{PassCode}", candidateDetails.PassCode).Replace("{Resume}",candidateDetails.ResumeLink).Replace("{Feedback}",candidateDetails.FeedbackLink);

            Event body = new Event();
            List<EventAttendee> attendes = new List<EventAttendee>();
            foreach (string e in candidateDetails.Attendes.Trim().Split(','))
            {
                EventAttendee a = new EventAttendee();
                a.Email = e;
                a.ResponseStatus = "accepted";
                attendes.Add(a);
            }

            EventAttendee b = new EventAttendee();
            b.Email = candidateDetails.InterViewerEmail.Trim();
            b.ResponseStatus = "accepted";
            attendes.Add(b);
            body.Attendees = attendes;


            /*06-12-2022/
           /*Attchment*/
            GoogleDriveHelper googleDriveHelper = new GoogleDriveHelper();
            var resumeID = googleDriveHelper.getFile(candidateDetails.ResumeLink);

            if (resumeID != "")
            {
                body.Attachments = googleDriveHelper.AttachedGoogleDriveFile(resumeID);
            }
            else
            {
              
                if (candidateDetails.ResumeLink.Trim() != "")
                    candidateDetails.InterViewerDescription += "\n\n\n\n Resume Link:\t  " + candidateDetails.ResumeLink;

            }

            if (candidateDetails.FeedbackLink != "")
            {
                candidateDetails.InterViewerDescription += "\n\n\n\n Feedback Link:\t  " + candidateDetails.FeedbackLink;
            }
            /*End Attchmed*/



            EventDateTime start = new EventDateTime();
            start.DateTime = Convert.ToDateTime(candidateDetails.InterviewDateTime, CultureInfo.InvariantCulture);
            EventDateTime end = new EventDateTime();
            //end.DateTime = Convert.ToDateTime(candidateDetails.InterviewDateTime, CultureInfo.InvariantCulture).AddMinutes(60);
            end.DateTime = Convert.ToDateTime(candidateDetails.InterviewDateTime, CultureInfo.InvariantCulture).AddMinutes(candidateDetails.Duration);
            body.Start = start;
            body.End = end;
            body.Location = candidateDetails.Location;
            body.Description = candidateDetails.InterViewerDescription;
            body.Summary = candidateDetails.Summary;

            //body.ColorId = candidateDetails.InterViewerColorCode;
            //body.ColorId = "#AC725E";
            body.ColorId = candidateDetails.ColorCode;


            //  EventsResource.InsertRequest request = new EventsResource.InsertRequest(_calService, body, candidateDetails.SchedulersEmail);
            EventsResource.InsertRequest request = new EventsResource.InsertRequest(_calService, body, "interviews@wonderbiz.in");

            //shaheem.shaikh@wonderbiz.in
            request.SendNotifications = true;

            request.SupportsAttachments = true;

            //interviews@wonderbiz.in
            Event response = request.Execute();
            
        }

        public List<Appointment> GetEvents()
        {
            try
            {
                EventsResource.ListRequest request = _calService.Events.List("primary");
                request.TimeMin = DateTime.Now.AddDays(-3);
                request.MaxResults = 2500;
                Events events = request.Execute();
                List<Appointment> eventDatas = new List<Appointment>();
                if (events.Items != null && events.Items.Count > 0)
                {
                    foreach (Event eventItem in events.Items)
                    {
                        if (eventItem.Start == null && eventItem.Status == "cancelled")
                        {
                            continue;
                        }
                        DateTime start;
                        DateTime end;
                        if (string.IsNullOrEmpty(eventItem.Start.Date))
                        {
                            start = (DateTime)eventItem.Start.DateTime;
                            end = (DateTime)eventItem.End.DateTime;
                        }
                        else
                        {
                            start = Convert.ToDateTime(eventItem.Start.Date);
                            end = Convert.ToDateTime(eventItem.End.Date);
                        }
                        Appointment eventData = new Appointment()
                        {
                            Id = eventItem.Id,
                            Subject = eventItem.Summary,
                            StartTime = start,
                            EndTime = end,
                            Location = eventItem.Location,
                            Description = eventItem.Description,
                            IsAllDay = !string.IsNullOrEmpty(eventItem.Start.Date)
                        };
                        eventDatas.Add(eventData);
                    }
                }
                return eventDatas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Appointment>();
            }
        }

    }
}

// [START calendar_quickstart]
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CalendarQuickstart
{
    internal class GCalendar
    {
        private CalendarService serviceCal;
        public string ApplicationName = "";

        [Obsolete]
        private CalendarService GetCalendarLogin()
        {
            try
            {
                UserCredential credential;
                using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] {
                        CalendarService.Scope.Calendar
                        },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                // Create Google SpredSheet API service.
                serviceCal = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch
            {
                throw;
            }
            return serviceCal;
        }
        //internal void CreateEvent(IList<object> interviewDetails, MailContaint mailContaint)
        //{
        //    InterviewerDetails _objInterviewer = mailContaint.interviewers.interviewerDetails.Find(x => x.interviewerName.ToLower() == interviewDetails[9].ToString().ToLower());
        //    mailContaint.MailBody = mailContaint.MailBody.Replace("{interviewrName}", _objInterviewer.interviewerName)
        //        .Replace("{nameofthecondidate}", interviewDetails[1].ToString())
        //        .Replace("{CandidateMobileNo}", interviewDetails[2].ToString())
        //        .Replace("{CandidateEmailId}", interviewDetails[4].ToString())
        //        .Replace("{interviewrMeetingLink}", _objInterviewer.interviewerUrl + " \r\n Meeting Id: " +
        //        _objInterviewer.interviewerMeettingId + " \r\n Meeting Passcode: " +
        //        _objInterviewer.interviewerPassCode);
        //    mailContaint.defaultEmails = mailContaint.defaultEmails + "," + interviewDetails[4].ToString();
        //    CalendarService _service = GetCalendarLogin();
        //    Event body = new Event();         
            
        //    List<EventAttendee> attendes = new List<EventAttendee>();
        //    foreach (string e in mailContaint.defaultEmails.Split(','))
        //    {
        //        EventAttendee a = new EventAttendee();
        //        a.Email = e;
        //        attendes.Add(a);
        //    }
        //    //attendes.Add(b);
        //    body.Attendees = attendes;
        //    EventDateTime start = new EventDateTime();
        //    start.DateTime = Convert.ToDateTime(interviewDetails[8].ToString() + " " + interviewDetails[7].ToString());
        //    EventDateTime end = new EventDateTime();
        //    end.DateTime = Convert.ToDateTime(interviewDetails[8].ToString() + " " + interviewDetails[7].ToString()).AddMinutes(60);
        //    body.Start = start;
        //    body.End = end;
        //    body.Location = "India";
        //    body.Description = mailContaint.MailBody;
        //    body.Summary = interviewDetails[1].ToString()+" - "+ interviewDetails[5].ToString() + " "+interviewDetails[6].ToString()+" @ " + interviewDetails[7].ToString();
        //    EventsResource.InsertRequest request = new EventsResource.InsertRequest(_service, body, "vinod.patil@wonderbiz.in");
        //    Event response = request.Execute();
        //}

    }
}

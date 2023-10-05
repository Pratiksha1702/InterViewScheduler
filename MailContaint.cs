using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarQuickstart
{
    
    public class MailContaint
    {
        public string SpreadsheetId { get; set; }
    }
    public class Interviewers
    {
        public List<InterviewerDetails> interviewerDetails { get; set; }
    }
    public class InterviewerDetails
    {
        public string interviewerName { get; set; }
        public string interviewerUrl { get; set; }
        public string interviewerMeettingId { get; set; }
        public string interviewerPassCode { get; set; }
        public string interviewerEmail { get; set; }
    }
}
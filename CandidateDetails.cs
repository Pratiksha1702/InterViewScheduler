using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarQuickstart
{

    public class CandidateLoops
    {
        public CandidateDetails[]? CandidateDetails { get; set; }
    }
    public class CandidateDetails
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Skills { get; set; }
        public string? Location { get; set; }
        public string? LastWorkingDate { get; set; }
        public string? SchedulersName { get; set; }
        public string? CreatedDate { get; set; }
        public string? InterViewStatus { get; set; }
        public string? Comment { get; set; }
        public string? InterViewRound { get; set; }
        public string InterviewDateTime { get; set; }
        public string? InterViewerName { get; set; }
        public string? Attendes { get; set; }
        public string? ResumeLink { get; set; } = "New Record";
        public string? FeedbackLink { get; set; } = "New Record";
        public int Duration { get; set; } = 60;
        public string GoogleMeetLink { get; set; } = "GoogleMeetLink";

        //
        public string? SchedulersEmail { get; set; }
        public string? InterViewerEmail { get; set; }
        public string? ZoomUrl { get; set; }
        public string? MeettingId { get; set; }
        public string? PassCode { get; set; }
        public string? CandidateDescription { get; set; }
        public string? InterViewerDescription { get; set; }
        public string? Summary { get; set; }
        public string? RecordType { get; set; } = "New Record";
        public string? ColorCode { get; set; } = "1";
        public string? InterViewerColorCode { get; set; } = "1";



    }
}

using CalendarQuickstart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterViewScheduler
{
    public class JsonOperations
    {
        public static LocationLoops ReadLocations() =>
            JsonConvert.DeserializeObject<LocationLoops>(File.ReadAllText("Data//Locations.json"));
        public static InterviewerLoops ReadInterviewers() =>
            JsonConvert.DeserializeObject<InterviewerLoops>(File.ReadAllText("Data//Interviewer.json"));
        public static StatusLoops ReadFinalStatus() =>
                    JsonConvert.DeserializeObject<StatusLoops>(File.ReadAllText("Data//Status.json"));
        public static SchedulersLoops ReadSchedulers() =>
                    JsonConvert.DeserializeObject<SchedulersLoops>(File.ReadAllText("Data//ScheduleBy.json"));
        public static TemplatesLoops ReadMailTemplates() =>
                    JsonConvert.DeserializeObject<TemplatesLoops>(File.ReadAllText("Data//MailTemplate.json"));
    }

    public class LocationLoops
    {
        public Locations[]? Locations { get; set; }
    }
    public class Locations
    {
        public int? Id { get; set; }
        public string? Location { get; set; }
        public override string ToString() => Location;
    }

    public class StatusLoops
    {
        public FinalStatus[]? FinalStatus { get; set; }
    }
    public class FinalStatus
    {
        public string? Id { get; set; }
        public string? Status { get; set; }
        public override string ToString() => Status;
    }

    public class InterviewerLoops
    {
        public Interviewers[]? Interviewers { get; set; }

      
    }
    public class Interviewers
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? interviewerEmail { get; set; }
        public string? ZoomUrl { get; set; }
        public string? MeettingId { get; set; }
        public string? PassCode { get; set; }
        public override string ToString() => Name;
        public string InterViewerColorCode { get; set; }
    }

    public class SchedulersLoops
    {
        public Schedulers[] Schedulers { get; set; }
    }

    public class Schedulers
    {
        public string? Name { get; set; }
        public string Email { get; set; }
      
        public override string ToString() => Name;
        public string ColorCode { get; set; }
    }


    public class TemplatesLoops
    {
        public Template[]? Template { get; set; }
    }

    public class Template
    {
        public string? Id { get; set; }
        public string? CandidateDescription { get; set; }
        public string? InterViewerDescription { get; set; }
        public override string ToString() => Id;
    }

}

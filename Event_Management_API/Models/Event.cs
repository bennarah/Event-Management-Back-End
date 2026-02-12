namespace Event_Management_API.Models
{
    public class Event
    {
        public Guid Id {get;set;}
        public string Title {get;set;}
        public string Desciription {get;set;}
        public DateTime StartDateTime {get;set;}
        public DateTime EndDateTime {get;set;}
        public string Location {get;set;}
        public int Capacity {get;set;}
    }
}
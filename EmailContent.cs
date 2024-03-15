using System.Collections.Generic;

namespace EmailManagement
{
    public class EmailContent
    {
        public string Subject { get; set; }
        public List<string> To { get; set; } = new List<string>();
        public List<string>  CC { get; set; } = new List<string> ();
        public List<string>  BCC { get; set; } = new List<string> ();
        public List<string>  Attachements { get; set; } = new List<string> ();
        public string Message { get; set; }
        public EmailContent() { }
    }
} 

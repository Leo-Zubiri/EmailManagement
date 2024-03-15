
namespace EmailManagement
{
    public class EmailClient
    {
        public string smtpClient { get; set; }
        public int port { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public bool enableSSL { get; set; } = true;

        /// <summary>
        /// enableSSL default value its true
        /// </summary>
        /// <param name="_smtpClient"></param>
        /// <param name="_port"></param>
        /// <param name="_user"></param>
        /// <param name="_password"></param>
        public EmailClient(string _smtpClient,int _port,string _user, string _password)
        {
            smtpClient = _smtpClient;
            port = _port;
            user = _user;
            password = _password;
        }

        /// <summary>
        /// You can set the enableSSL value to true/false
        /// </summary>
        /// <param name="_smtpClient"></param>
        /// <param name="_port"></param>
        /// <param name="_user"></param>
        /// <param name="_password"></param>
        public EmailClient(string _smtpClient, int _port, string _user, string _password, bool _enableSSL)
        {
            smtpClient = _smtpClient;
            port = _port;
            user = _user;
            password = _password;
            enableSSL = _enableSSL;
        }
    }
}

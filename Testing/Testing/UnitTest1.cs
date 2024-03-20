using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailManagement;
using System.Collections.Generic;
using System;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmailClient client = new EmailClient("smtp",1,"user@correo.com","pass");
            Email mail = new Email();
            mail.Subject = "Test";
            mail.To = new List<string>() {"Zubiri@correo.com"};

            string status = Email.SendEmail(client, mail);   
            if (status != Email.status_OK)
            {
                Console.WriteLine(status);
            }
        }
    }
}

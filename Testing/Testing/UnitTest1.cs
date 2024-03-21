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
            EmailClient client = new EmailClient("smtp",100,"SENDER","user@correo.com","pass");
            Email mail = new Email();
            mail.Subject = "Test";
            mail.To = new List<string>() {"Zubiri@correo.com"};
            mail.CC = new List<string>() {"Correo@correo.com"};
            mail.Attachements = new List<string>() {
                @"C:\Documents\excel.xlsx"
            };
            mail.isBodyHTML = true; // Not necessary declare, as default this value is true.
            mail.Message = "<b>Hello World!</b>";

            string status = Email.SendEmail(client, mail);   
            if (status != Email.status_OK)
            {
                Console.WriteLine(status);
            }
        }
    }
}

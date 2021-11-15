using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Assignment5
{
    public class Email
    {
        private string emailBusiness;
        public string EmailBusiness
        {
            get
            {
                return emailBusiness;
            }
        }
        private string emailPrivate;
        public string EmailPrivate
        {
            get
            {
                return emailPrivate;
            }
        }
        public Email() : this("")
        {
            emailBusiness = "";
        }

        public Email(string newEmail) : this(newEmail, "")
        {
            // TODO How to know which email to set?
            if (newEmail != null && MailAddress.TryCreate(newEmail, out var mailAddress))
            {
                emailBusiness = mailAddress.ToString();
            }
        }

        public Email(string newEmailBusiness, string newEmailPrivate)
        {
            if (newEmailBusiness != "")
            {
                // I want the e-mail addresses passed in to be correctly formatted
                if (MailAddress.TryCreate(newEmailBusiness, out var mailBusiness))
                {
                    emailBusiness = mailBusiness.ToString();
                }
                else
                {
                    // I chose to throw an exception which is handled by the caller
                    throw new ArgumentException("Business e-mail not correctly formatted!");
                }
            } else
            {
                emailBusiness = newEmailBusiness;
            }
            if (newEmailPrivate != "")
            {
                if (MailAddress.TryCreate(newEmailPrivate, out var mailPrivate))
                {
                    emailPrivate = mailPrivate.ToString();
                }
                else
                {
                    throw new ArgumentException("Private e-mail not correctly formatted!");
                }

            }
            else
            {
                emailPrivate = newEmailPrivate;
            }
        }
    }
}

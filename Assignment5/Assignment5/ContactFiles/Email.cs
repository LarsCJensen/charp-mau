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
        public Email() : this(""){}

        public Email(string newEmail) : this(newEmail, "") {}
        /// <summary>
        /// Create and validate email
        /// </summary>
        /// <param name="newEmailBusiness">Value for business e-mail</param>
        /// <param name="newEmailPrivate">Value for private e-mail</param>
        public Email(string newEmailBusiness, string newEmailPrivate)
        {
            // TryCreate will error if address is empty string.
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
                // But we allow e-mail to be empty string
                emailBusiness = newEmailBusiness;
            }
            // TryCreate will error if address is empty string.
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
                // But we allow e-mail to be empty string
                emailPrivate = newEmailPrivate;
            }
        }
    }
}

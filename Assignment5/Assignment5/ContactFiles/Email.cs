using System;
using System.Net.Mail;

namespace Assignment5
{
    /// <summary>
    /// Class which holds e-mail information
    /// </summary>
    public class Email
    {
        // Only allowed to get properties from outside of class
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
        /// <summary>
        /// Create and validate email
        /// </summary>
        /// <param name="newEmailBusiness">Value for business e-mail</param>
        /// <param name="newEmailPrivate">Value for private e-mail</param>
        // As the form always will pass in two values (albeit one or both could be empty) I will just use an overloaded constructor
        public Email(string newEmailBusiness, string newEmailPrivate)
        {
            // TryCreate will error if address is empty string, but empty string is allowed
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
            // TryCreate will error if address is empty string, but empty string is allowed
            if (newEmailPrivate != "")
            {
                if (MailAddress.TryCreate(newEmailPrivate, out var mailPrivate))
                {
                    emailPrivate = mailPrivate.ToString();
                }
                else
                {
                    // I chose to throw an exception which is handled by the caller
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

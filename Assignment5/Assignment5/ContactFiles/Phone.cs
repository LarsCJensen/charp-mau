namespace Assignment5
{
    /// <summary>
    /// Class to hold phone information
    /// </summary>
    public class Phone
    {
        // Only allowed to get properties
        private string businessPhone;
        public string BusinessPhone
        {
            get
            {
                return businessPhone;
            }            
        }

        private string privatePhone;
        public string PrivatePhone
        {
            get
            {
                return privatePhone;
            }            
        }       
        /// <summary>
        /// As phone numbers are passed in from the form through two text boxes we just have one constructor which takes two values
        /// </summary>        
        // I thought about having multiple constructors but it didn't make sense
        public Phone(string newBusinessPhone, string newPrivatePhone)
        {            
            businessPhone = newBusinessPhone;
            privatePhone = newPrivatePhone;
        }
    }
}

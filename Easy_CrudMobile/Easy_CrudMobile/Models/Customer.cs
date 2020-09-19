using System;

namespace Easy_CrudMobile.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Hire_Date { get; set; }
        public int Age { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, Surname);
            }
        }

        public string Hire_DateString
        {
            get
            {
                return Hire_Date.ToLongDateString();
            }
        }
    }
}

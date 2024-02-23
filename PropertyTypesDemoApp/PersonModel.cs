using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyTypesDemoApp
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} - {LastName}";
        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value >= 0 && value < 126)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "The age cannot be exist");
                }
            }
        }

        private string _ssn;
        //123-45-6789
        public string SSN
        {
            get
            {
                return "***-**-" + _ssn.Substring(_ssn.Length - 4);
            }
            set { _ssn = value; }
        }


    }
}

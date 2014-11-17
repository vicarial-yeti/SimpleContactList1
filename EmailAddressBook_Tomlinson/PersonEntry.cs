using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAddressBook_Tomlinson
{
    class PersonEntry
    {
        //fields
        private string _name;       //to hold name
        private string _email;      //to hold email
        private string _number;     //to hold phone number

        //constructor
        public PersonEntry()
        {
            _name = "";
            _email = "";
            _number = "";
        }

        //name property
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        //email property
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        //number property
        public string number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}

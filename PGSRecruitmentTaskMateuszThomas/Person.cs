using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PGSRecruitmentTaskMateuszThomas
{
    public class Person
    {
        /// <summary>
        /// Name of person 
        /// </summary>
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// Surname of person 
        /// </summary>
        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        /// <summary>
        /// Address of person
        /// </summary>
        private string address;

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        /// <summary>
        /// Phone number of person
        /// </summary>
        private string phoneNumber;

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public Person()
        {
            name = "";
            surname = "";
            address = "";
            phoneNumber = "";
        }
        /// <summary>
        /// Creates a description of the person based on their data.
        /// </summary>
        /// <returns>Description person</returns>
        public string DescriptionPerson()
        {
            return "Imię: " + name + "\n" + "Nazwisko: " + surname + "\n" + "Adres: " + address + "\n" + "Numer telefonu: " + phoneNumber;
        }
    }
}

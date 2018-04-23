using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PGSRecruitmentTaskMateuszThomas
{
    /// <summary>
    /// Interaction logic for WindowFormAddress.xaml
    /// </summary>
    public partial class WindowFormAddress : Window
    {
        /// <summary>
        /// The person whose data is filled out in the form.
        /// </summary>
        private Person _person;

        public WindowFormAddress(Person person)
        {
            InitializeComponent();
            _person = person;
            if (!_person.Address.Equals(""))
            {
                textBoxAddress.Text = _person.Address;
            }
        }

        /// <summary>
        /// The function of moving to the next window or displaying error information.
        /// </summary>
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (isCorrectFormatAddress(textBoxAddress.Text))
            {
                _person.Address = textBoxAddress.Text;
                WindowFormPhoneNumber fourthForm = new WindowFormPhoneNumber(_person);
                fourthForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wzór:\r\nMiasto, ul. Nazwa_ulicy numer_domu/numer_mieszkania\r\n\r\nWymagany format:\r\n- Nazwy miasta i ulicy muszą zaczynać się od wielkiej litery\r\n- Nazwy miasta i ulicy mogą składać sie z maksymalnie 100 znaków.\r\n- Numery domu i mieszkania mogą składać sie z liczb i liter.\r\n- Numery domu i mieszkania mogą składać sie z maksymalnie 4 znaków.\r\n- Numer mieszkania jest opcjonalny.", "Nieporawny format!");
            }
        }

        /// <summary>
        /// The function of moving to the previous window.
        /// </summary>
        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            WindowFormSurname secondForm = new WindowFormSurname(_person);
            secondForm.Show();
            this.Close();
        }

        /// <summary>
        /// A function that verifies the correctness of the entered address.
        /// </summary>
        /// <param name="address">Address to check</param>
        /// <returns>Information about correctness address</returns>
        private bool isCorrectFormatAddress(string address)
        {
            Regex reg = new Regex("^([A-ZĄĆĘŁŃÓŚŹŻ]{1}[A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż-]{1,99}), ul. ([A-ZĄĆĘŁŃÓŚŹŻ]{1}[A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż-]{1,99}) ([0-9A-Za-z]{1,4})(/[0-9A-Za-z]{1,4})?$");
            Match matches = reg.Match(address);
            return matches.Success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace PGSRecruitmentTaskMateuszThomas
{
    /// <summary>
    /// Interaction logic for WindowFormPhoneNumber.xaml
    /// </summary>
    public partial class WindowFormPhoneNumber : Window
    {
        /// <summary>
        /// The person whose data is filled out in the form.
        /// </summary>
        private Person _person;

        public WindowFormPhoneNumber(Person person)
        {
            InitializeComponent();
            _person = person;
            if (!_person.PhoneNumber.Equals(""))
            {
                textBoxPhoneNumber.Text = _person.PhoneNumber;
            }
        }

        /// <summary>
        /// The function of moving to the previous window.
        /// </summary>
        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            WindowFormAddress thirdForm = new WindowFormAddress(_person);
            thirdForm.Show();
            this.Close();
        }

        /// <summary>
        /// The function of transition to display the data entered in the form or displaying information about the error.
        /// </summary>
        private void buttonDisplayData_Click(object sender, RoutedEventArgs e)
        {
            if (isCorrectFormatPhoneNumber(textBoxPhoneNumber.Text))
            {
                _person.PhoneNumber = textBoxPhoneNumber.Text;
                WindowDisplayPersonData displayPersonData = new WindowDisplayPersonData(_person);
                displayPersonData.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wymagany format: \r\n- Od 9 do 15 cyfr", "Nieporawny format!");
            }
        }

        /// <summary>
        /// A function that verifies the correctness of the entered phone number.
        /// </summary>
        /// <param name="phoneNumber">phone number to check</param>
        /// <returns>Information about correctness phone number</returns>
        private bool isCorrectFormatPhoneNumber(string phoneNumber)
        {
            Regex reg = new Regex("^([0-9]{9,15})$");
            Match matches = reg.Match(phoneNumber);
            return matches.Success;
        }
    }
}

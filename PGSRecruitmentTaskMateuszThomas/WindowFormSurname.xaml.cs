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
    /// Interaction logic for WindowFormSurname.xaml
    /// </summary>
    public partial class WindowFormSurname : Window
    {
        /// <summary>
        /// The person whose data is filled out in the form.
        /// </summary>
        private Person _person;

        public WindowFormSurname(Person person)
        {
            InitializeComponent();
            _person = person;
            if (!_person.Surname.Equals(""))
            {
                textBoxSurname.Text = _person.Surname;
            }
        }

        /// <summary>
        /// The function of moving to the next window or displaying error information.
        /// </summary>
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            
            if (isCorrectFormatSurname(textBoxSurname.Text))
            {
                _person.Surname = textBoxSurname.Text;
                WindowFormAddress thirdForm = new WindowFormAddress(_person);
                thirdForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wymagany format: \r\n- Nazwisko musi zaczynać sie od wielkiej litery.\r\n- Nazwisko wieloczłonowe musi być podzielone myślnikami.\r\n- Maksymalna długość nazwiska to 100 znaków.", "Nieporawny format!");
            }
        }

        /// <summary>
        /// The function of moving to the previous window.
        /// </summary>
        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            WindowFormName firstForm = new WindowFormName(_person);
            firstForm.Show();
            this.Close();
        }

        /// <summary>
        /// A function that verifies the correctness of the entered surname.
        /// </summary>
        /// <param name="surname">Surname to check</param>
        /// <returns>Information about correctness surname</returns>
        private bool isCorrectFormatSurname(string surname)
        {
            Regex reg = new Regex("^([A-ZĄĆĘŁŃÓŚŹŻ]{1}[A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż-]{1,99})$");
            Match matches = reg.Match(surname);
            return matches.Success;
        }
    }
}

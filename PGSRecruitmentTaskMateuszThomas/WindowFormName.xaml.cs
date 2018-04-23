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
    /// Interaction logic for WindowFormName.xaml
    /// </summary>
    public partial class WindowFormName : Window
    {
        /// <summary>
        /// The person whose data is filled out in the form.
        /// </summary>
        private Person _person;

        public WindowFormName()
        {
            InitializeComponent();
            _person = new Person();
        }
        
        public WindowFormName(Person person)
        {
            InitializeComponent();
            _person = person;
            if (!_person.Name.Equals(""))
            {
                textBoxName.Text = _person.Name;
            }
        }

        /// <summary>
        /// The function of moving to the next window or displaying error information.
        /// </summary>
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (isCorrectFormatName(textBoxName.Text))
            {
                _person.Name = textBoxName.Text;
                WindowFormSurname secondForm = new WindowFormSurname(_person);
                secondForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wymagany format: \r\n- Imię musi zaczynać sie od wielkiej litery.\r\n- Maksymalna długość imienia to 100 znaków.", "Nieporawny format!");
            }
        }

        /// <summary>
        /// A function that verifies the correctness of the entered name.
        /// </summary>
        /// <param name="name">Name to check</param>
        /// <returns>Information about correctness name</returns>
        private bool isCorrectFormatName(string name)
        {
            Regex reg = new Regex("^([A-ZĄĆĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż]{1,99})$");
            Match matches = reg.Match(name);
            return matches.Success;
        }
    }
}

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

namespace PGSRecruitmentTaskMateuszThomas
{
    /// <summary>
    /// Interaction logic for WindowDisplayPersonData.xaml
    /// </summary>
    public partial class WindowDisplayPersonData : Window
    {
        /// <summary>
        /// The person whose data is filled out in the form.
        /// </summary>
        private Person _person;

        public WindowDisplayPersonData(Person person)
        {
            InitializeComponent();
            _person = person;
            textBlockDataAboutPerson.Text = _person.DescriptionPerson();
        }

        /// <summary>
        /// The function that restarts the form.
        /// </summary>
        private void buttonRestartForm_Click(object sender, RoutedEventArgs e)
        {
            WindowFormName firstWindow = new WindowFormName();
            firstWindow.Show();
            this.Close();
        }

        /// <summary>
        /// The function that ends the form.
        /// </summary>
        private void buttonEnd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

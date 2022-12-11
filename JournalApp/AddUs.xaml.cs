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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JournalApp
{
    /// <summary>
    /// Логика взаимодействия для AddUs.xaml
    /// </summary>
    public partial class AddUs : Page
    {
        JournalBDEntities context;
        public AddUs()
        {
            InitializeComponent();
            context = new JournalBDEntities();
        }

        private void AddUsButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Progress progress = new Progress()
                {
                    rating = Convert.ToDouble(ballBox.Text),
                    idstudent = Convert.ToInt32(studentBox.Text),
                    idsubject = Convert.ToInt32(subjectBox.Text)
                };
                context.Progress.Add(progress);
                context.SaveChanges();
                MessageBox.Show("Добавление успешно");
                fifthFrame.Navigate(new Page1());
            }
            catch
            {
                MessageBox.Show("Упс, что-то пошло не так");
            }
        }
    }
}

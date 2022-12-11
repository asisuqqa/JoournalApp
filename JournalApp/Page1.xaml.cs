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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        JournalBDEntities context;
        public Page1()
        {
            InitializeComponent();
            JournalBDEntities context = new JournalBDEntities();
            ltab.ItemsSource = context.Laboratory.ToList();

            var slist = context.Subject.ToList();
            slist.Insert(0, new Subject() { id = 0 });
            lbox.ItemsSource = slist;
        }

        private void AddGroup(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new AddGroupPage());
        }

        private void AddSubject(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new AddSubjectPage());
        }

        private void AddLab(object sender, RoutedEventArgs e)
        {
            SecondFrame.Navigate(new AddLabPage());
        }

        private void comb1(object sender, SelectionChangedEventArgs e)
        {
            JournalBDEntities context = new JournalBDEntities();
            Subject subject = lbox.SelectedItem as Subject;
            var listt = context.Laboratory.Where(x => x.idSubject == subject.id).ToList();
            ltab.ItemsSource = listt;
            ltab.Items.Refresh();
        }

        private void Retr(object sender, RoutedEventArgs e)
        {
            var list = MessageBox.Show("Вы действительно хотите выйти?", "Завершение работы приложения",
                MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if(list == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                SecondFrame.Navigate(new Page1());
            }
        }
    }
}

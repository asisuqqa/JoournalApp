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
            var list = context.Laboratory.Select(x => new { x.title, x.maxball, x.idSubject}).ToList();
            ltab.ItemsSource = list.ToList();
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
    }
}

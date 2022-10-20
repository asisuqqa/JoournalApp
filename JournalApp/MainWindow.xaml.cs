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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JournalBDEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new JournalBDEntities();
            List<Group> groups = context.Group.ToList(); 
            group.ItemsSource = context.Group.ToList();
            MainFrame.Navigate(new Page1());


            //context = new masterEntities1();
            //group.ItemsSource = context.Group.Select(x => x.title).ToList();
        }





        private void disciplinesMouseEnter(object sender, MouseEventArgs e)
        {
            disciplines.Visibility = Visibility.Visible;
        }

        private void disciplinesMouseLeave(object sender, MouseEventArgs e)
        {
            disciplines.Visibility = Visibility.Collapsed;
        }

        private void groupMouseEnter(object sender, MouseEventArgs e)
        {
            group.Visibility = Visibility.Visible;

        }

        private void groupMouseLeave(object sender, MouseEventArgs e)
        {
            group.Visibility = Visibility.Collapsed;
        }

        private void GoGroup(object sender, MouseButtonEventArgs e)
        {
            Group group = (sender as Grid).DataContext as Group;
            MainFrame.Navigate(new Page2(group,context));
 
        }
    }
}

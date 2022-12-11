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
using System.Media;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            group.ItemsSource = context.Group.ToList();
            disciplines.ItemsSource = context.Subject.ToList();
            MainFrame.Navigate(new Page1());
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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
        private void GoDisp(object sender, MouseButtonEventArgs e)
        {
            Subject subject = (sender as Grid).DataContext as Subject;
            MainFrame.Navigate(new DispPage(subject, context));
        }

        private void GoHome(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 1)
            {
                MainFrame.Navigate(new Page1());
            }            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Task.Factory.StartNew(() =>
            {
                var files = new string[]
                {
                    "1.wav",
                    "2.wav",
                    "3.wav",
                    "4.wav" };
                var player = new SoundPlayer();

                while (true)
                {
                    foreach (var file in files)
                    {
                        player.SoundLocation = file;
                        player.PlaySync();
                    }
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}

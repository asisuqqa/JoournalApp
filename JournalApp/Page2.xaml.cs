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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        JournalBDEntities context;
        Group group;
        public Page2(Group group, JournalBDEntities context)
        {
            InitializeComponent();
            
            this.group = group;
            this.context = context;
            double avg = context.Progress.Average(x => x.rating);
            var qlist = context.Progress.Select(x => new { x.Student.groups, x.Student.fio, x.Subject.title,x.rating}).Where(x => x.groups == group.id).ToList();
            var list = context.Attendance.Select(x => new { x.Student.groups,x.Student.fio,x.Subject.title,x.presence,x.date}).Where(x=>x.groups==group.id).ToList();
            ptab.ItemsSource = list.ToList();         
            utab.ItemsSource = qlist.ToList();           

            var slist = context.Subject.ToList();
            slist.Insert(0, new Subject() { title = "Все", id = 0 });
            sbox.ItemsSource = slist;
            sbox.ItemsSource = context.Subject.ToList();
        }

        private void DelateUs(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Progress progress = utab.SelectedItem as Progress;
                    context.Progress.Remove(progress);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        private void AddGroupClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGroupPage());
        }

        private void DelatePos(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Attendance attendance = ptab.SelectedItem as Attendance;
                    context.Attendance.Remove(attendance);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        private void AddPos(object sender, RoutedEventArgs e)
        {
            thirdFrame.Navigate(new AddPos());
        }

        private void AddUs(object sender, RoutedEventArgs e)
        {
            thirdFrame.Navigate(new AddUs());
        }

        private void EditUs(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция в разработке :C", "Подтверждение", MessageBoxButton.OK);
        }

        private void EditPos(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция в разработке :C", "Подтверждение", MessageBoxButton.OK);
        }
    } 
}
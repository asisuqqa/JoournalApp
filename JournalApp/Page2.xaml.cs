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
            var list = group.Student;
            utab.ItemsSource = list.ToList();
            ptab.ItemsSource = list.ToList();
            var qlist = context.StudenttoSubject.Select(x => new { x.Student.id, x.Student.fio, x.Student.groups, x.idsubject }).Where(y => y.idsubject == group.id).ToList();

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
                    Attendance attendance = utab.SelectedItem as Attendance;
                    context.Attendance.Remove(attendance);
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
        //public void Refreshdata()
        //{
        //    foreach (var item in qlist)
        //    {

        //    }
        //    var list = context.Subject.ToList();
        //    if (sbox.SelectedIndex > 0)
        //    {
        //        Subject c = sbox.SelectedItem as Subject;
        //        list = list.Where(x => x. == c).ToList();
        //    }
        //    utab.ItemsSource = list;
        //    ptab.ItemsSource = list;
        //}
    } 
}
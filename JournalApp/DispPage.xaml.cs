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
    /// Логика взаимодействия для DispPage.xaml
    /// </summary>
    public partial class DispPage : Page
    {
        JournalBDEntities context;
        Subject subject;
        List<AttedanceStudent> attedancestd;
        public DispPage(Subject subject, JournalBDEntities context)
        {
            InitializeComponent();
            this.subject = subject;
            this.context = context;
            var list = context.StudenttoSubject.Select(x => new { x.Student.id, x.Student.fio, x.Student.groups, x.idsubject }).Where(y => y.idsubject == subject.id).ToList();
            attedancestd = list.Select(x => new AttedanceStudent { IdStudent = x.id, IdSubject = x.idsubject, Presence = null, Date = null, Fio = x.fio }).ToList();
            utab.ItemsSource = attedancestd.ToList();

            var slist = context.Group.ToList();
            slist.Insert(0, new Group() { id = 0 });
            sbox.ItemsSource = slist;
            sbox.ItemsSource = context.Group.ToList();
    
        }

        private void Savetab(object sender, RoutedEventArgs e)
        {

            foreach (var item in utab.ItemsSource)
            {
                AttedanceStudent attedanceStudent = item as AttedanceStudent;
                Attendance attendance = new Attendance()
                {
                    idstudent = attedanceStudent.IdStudent,
                    date = (DateTime)date.SelectedDate,
                    idsubject = subject.id,
                    presence = attedanceStudent.Presence == null ? false:true,
                   
            };
                context.Attendance.Add(attendance);
            }          
            context.SaveChanges();

        }
        public void Refreshdata()
        {
            var list = context.Group.ToList();
            if (sbox.SelectedIndex > 0)
            {
                Group c = sbox.SelectedItem as Group;
                list = list.Where(x => x == c).ToList();
            }
            utab.ItemsSource = list;
        }
    }
}

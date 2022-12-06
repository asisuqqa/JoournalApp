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

            var groupList = context.Group.ToList();
            groupList.Insert(0, new Group() { id = 0 });
            groupBox.ItemsSource = groupList;

            var tlist = context.Subject.ToList();
            tlist.Insert(0, new Subject() { id = 0 });
            tbox.ItemsSource = tlist;
            tbox.ItemsSource = context.Subject.ToList();

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

        private void AddSubjectClick(object sender, RoutedEventArgs e)
        {
            Subject subject = new Subject()
            {
                title = titleSubjectBox.Text
            };
            context.Subject.Add(subject);
            context.SaveChanges();

            Subject IDSubject = context.Subject.ToList().Find(x => x.title == titleSubjectBox.Text);

            Laboratory laboratory = new Laboratory()
            {
                title = titleLaboratoryBox.Text,
                maxball = Convert.ToDouble(maxballBox.Text),
                idSubject = IDSubject.id
            };
            context.Laboratory.Add(laboratory);
            context.SaveChanges();

            Group IDgroup = context.Group.ToList().Find(x => x.title == groupBox.Text);

            List<Student> IdStudent = context.Student.Where(x => x.groups == IDgroup.id).ToList();
            foreach (var IDstudent in IdStudent)
            {
                StudenttoSubject studenttoSubject = new StudenttoSubject
                {
                    idstudent = IDstudent.id,
                    idsubject = IDSubject.id
                };
                context.StudenttoSubject.Add(studenttoSubject);
            }

            context.SaveChanges();
        }

        private void AddLabClick(object sender, RoutedEventArgs e)
        {
            Subject IDSubject = context.Subject.ToList().Find(x => x.title == sbox.Text); ;
            Laboratory laboratory = new Laboratory()
            {
                title = tbox.Text,
                maxball = Convert.ToDouble(maxballBox1.Text),
                idSubject = IDSubject.id
            };
            context.Laboratory.Add(laboratory);
            context.SaveChanges();
        }
    }
}

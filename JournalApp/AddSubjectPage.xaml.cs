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
    /// Логика взаимодействия для AddSubjectPage.xaml
    /// </summary>
    public partial class AddSubjectPage : Page
    {
        JournalBDEntities context;
        public AddSubjectPage()
        {
            InitializeComponent();
            context = new JournalBDEntities();
            var groupList = context.Group.ToList();
            groupList.Insert(0, new Group() { id = 0 });
            groupBox.ItemsSource = groupList;
        }       

        private void SaveSubject(object sender, RoutedEventArgs e)
        {
            try
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
                MessageBox.Show("Успешно");
            }
            catch
            {
                MessageBox.Show("Упс, что-то пошло не так");
            }
        }
    }
}

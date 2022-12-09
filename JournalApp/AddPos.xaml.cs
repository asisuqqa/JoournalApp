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
    /// Логика взаимодействия для AddPos.xaml
    /// </summary>
    public partial class AddPos : Page
    {
        JournalBDEntities context;
        public AddPos()
        {
            InitializeComponent();
            context = new JournalBDEntities();
            //context = cont;
            //flag = true;
        }

        //bool flag;

        private void AddPosButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Attendance attendance = new Attendance()
                {
                    date = (DateTime)datepic.SelectedDate,
                    presence = Convert.ToBoolean(posBox.Text),
                    idstudent = Convert.ToInt32(studentBox.Text),
                    idsubject = Convert.ToInt32(subjectBox.Text)
                };
                context.Attendance.Add(attendance);
                context.SaveChanges();
                fourthFrame.Navigate(new Page1());
            }
            catch
            {
                MessageBox.Show("Упс, что-то пошло не так");
            }

            //if (flag == true)
            //{
            //    Attendance attendance = new Attendance()
            //    {                    
            //        date = (DateTime)datepic.SelectedDate,
            //        presence = Convert.ToBoolean(posBox.Text),
            //        idstudent = Convert.ToInt32(studentBox.Text),
            //        idsubject = Convert.ToInt32(subjectBox.Text)                  
            //    };
            //    context.Attendance.Add(attendance);
            //    context.SaveChanges();
            //    //NavigationService.Navigate(new Page2());
            //}
            //else
            //{
            //    context.Attendance.Find(attendancemin.id).date = (DateTime)datepic.SelectedDate;
            //    context.Attendance.Find(attendancemin.id).presence = Convert.ToBoolean(posBox.Text);
            //    context.Attendance.Find(attendancemin.id).idstudent = Convert.ToInt32(studentBox.Text);
            //    context.Attendance.Find(attendancemin.id).idsubject = Convert.ToInt32(subjectBox.Text);
            //    context.SaveChanges();
            //    //NavigationService.Navigate(new Page2());
            //}
        }

        //Attendance attendancemin;

        //public AddPos(JournalBDEntities cont, Attendance attendance)
        //{
        //    InitializeComponent();
        //    context = cont;
        //    attendancemin = attendance;
        //    posBox.Text = attendance.presence.ToString;
        //}
    }
}

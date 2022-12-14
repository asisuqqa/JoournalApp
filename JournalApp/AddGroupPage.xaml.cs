using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : Page
    {
        JournalBDEntities context;
        public AddGroupPage()
        {
            InitializeComponent();
            context = new JournalBDEntities();
            flag = true;
        }

        bool flag;

        private void SaveGroup(object sender, RoutedEventArgs e)
        {            
            try
            {
                string pathfile = "C://";
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
                {
                    pathfile = Convert.ToString(ofd.FileName);
                }
                if (flag == true)
                {

                    Group group = new Group()
                    {
                        title = titleBox.Text
                    };
                    context.Group.Add(group);
                    context.SaveChanges();
                    NavigationService.Navigate(new Page1());
                }
                else
                {
                    context.Group.Find(gr.id).title = titleBox.Text;
                    context.SaveChanges();
                    NavigationService.Navigate(new Page1());
                }

                Group lastGroup = context.Group.ToList().Find(x => x.title == titleBox.Text);

                string[] lines = File.ReadAllLines(pathfile);
                int i = lines.Count();
                string[] vs = new string[i];
                string fio;
                foreach (var line in lines)
                {
                    Student student = new Student();
                    vs = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    fio = vs[0];
                    student.fio = fio;
                    student.groups = lastGroup.id;
                    context.Student.Add(student);
                }
                context.SaveChanges();
                MessageBox.Show("Успешно");
            }
            catch
            {
                MessageBox.Show("Упс, что-то пошло не так");
            }
        }
        Group gr;

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

            //OpenFileDialog ofd = new OpenFileDialog();          
            //ofd.RestoreDirectory = true;
            //ofd.Multiselect = true;
            //ofd.ShowDialog();
        }
    }
}


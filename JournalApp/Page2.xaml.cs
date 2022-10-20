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

            var slist = context.Subject.ToList();
            slist.Insert(0, new Subject() { title = "Все", id = 0 });
            sbox.ItemsSource = slist;
            sbox.ItemsSource = context.Subject.ToList();
        }
        public void Refreshdata()
        {
            var list = context.Subject.ToList();
            if (sbox.SelectedIndex > 0)
            {
                Subject c = sbox.SelectedItem as Subject;
                list = list.Where(x => x == c).ToList();
            }
        }
    } 
}
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
    /// Логика взаимодействия для AddLabPage.xaml
    /// </summary>
    public partial class AddLabPage : Page
    {
        JournalBDEntities context;
        public AddLabPage()
        {
            InitializeComponent();
            context = new JournalBDEntities();
            var slist = context.Subject.ToList();
            slist.Insert(0, new Subject() { id = 0 });
            sbox.ItemsSource = slist;
        }

        private void SaveLab(object sender, RoutedEventArgs e)
        {
            Subject IDSubject = context.Subject.ToList().Find(x => x.title == Lbox.Text); ;
            Laboratory laboratory = new Laboratory()
            {
                title = Lbox.Text,
                maxball = Convert.ToDouble(maxballBox.Text),
                idSubject = IDSubject.id
            };
            context.Laboratory.Add(laboratory);
            context.SaveChanges();
            MessageBox.Show("Успешно");
        }
    }
}

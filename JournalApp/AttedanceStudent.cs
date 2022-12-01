using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp
{
    class AttedanceStudent
    {
        public int IdSubject { get; set; }
        public int IdStudent { get; set; }
        public bool? Presence { get; set; }
        public DateTime? Date { get; set; }
        public string Fio { get; set; }
    }
}

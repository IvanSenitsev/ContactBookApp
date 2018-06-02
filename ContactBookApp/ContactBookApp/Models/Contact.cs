using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookApp.Models
{
    public class Contact
    {
        //нужен для выяснения новый или старый контакт 0 новый 1 старый
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool newContact { get; set; }

    }
}

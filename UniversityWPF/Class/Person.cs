using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityWPF.Class
{
    class Person
    {
        private int idPerson;
        public int IdPerson
        {
            get { return idPerson; }
            set { idPerson = value; }
        }

        private int idDocument;
        public int IdDocument
        {
            get { return idDocument; }
            set { idDocument = value; }
        }

        private string document;
        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        private string name1;
        public string Name1
        {
            get { return name1; }
            set { name1 = value; }
        }

        private string name2;
        public string Name2
        {
            get { return name2; }
            set { name2 = value; }
        }

        private string lastname1;
        public string Lastname1
        {
            get { return lastname1; }
            set { lastname1 = value; }
        }

        private string lastname2;
        public string Lastname2
        {
            get { return lastname2; }
            set { lastname2 = value; }
        }

        private string birthayDay;
        public string BirthayDay
        {
            get { return birthayDay; }
            set { birthayDay = value; }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public static ObservableCollection<Person> getPerson()
        {
            var person = new ObservableCollection<Person>();
            return person;
        }
    }
}

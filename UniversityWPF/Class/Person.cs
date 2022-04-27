using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public Actions Action { get; set; }
        
        public ObservableCollection<Person> getPerson(DataTable dt)
        {
            var persons = new ObservableCollection<Person>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Person per = new Person();
                per.IdPerson = Convert.ToInt32(dt.Rows[i]["idPerson"]);
                per.IdDocument = Convert.ToInt32(dt.Rows[i]["idDocumentType"]);
                per.Document = dt.Rows[i]["document"].ToString();
                per.Name1 = dt.Rows[i]["name1"].ToString();
                per.Lastname1 = dt.Rows[i]["lastname1"].ToString();

                if (dt.Rows[i]["name2"] == null )
                {
                    per.Name2 = "";
                }
                else if (dt.Rows[i]["lastname2"] == null)
                {
                    per.Lastname2 = "";
                }
                else
                {
                    per.name2 = dt.Rows[i]["name2"].ToString();
                    per.Lastname2 = dt.Rows[i]["lastname2"].ToString();

                }
                per.BirthayDay = dt.Rows[i]["birthdayDate"].ToString();
                per.IsActive = Convert.ToBoolean(dt.Rows[i]["isActive"]);

                persons.Add(per);
            }
            return persons;
        }
    }
}

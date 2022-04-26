using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityWPF.Class
{
    class Document
    {
        private int idDocument;
        public int IdDocument
        {
            get { return idDocument; }
            set { idDocument = value; }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public static ObservableCollection<Document> getDocument(int id, string cd, string name, string decrip, bool active)
        {
            var docs = new ObservableCollection<Document>();
            docs.Add(new Document() { IdDocument = id, Code = cd, Name = name, Description = decrip, IsActive = active});
            return docs;
        }

    }
}

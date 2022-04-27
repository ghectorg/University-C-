using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public Actions Action { get; set; }

        public ObservableCollection<Document> getDocument(DataTable dt)
        {
            var docs = new ObservableCollection<Document>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Document doc = new Document();
                doc.IdDocument = Convert.ToInt32(dt.Rows[i]["idDocumentType"]);
                doc.Code = dt.Rows[i]["code"].ToString();
                doc.Name = dt.Rows[i]["name"].ToString();
                if (dt.Rows[i]["description"] == null)
                {
                    doc.Description = "";
                }
                else
                {
                    doc.Description = dt.Rows[i]["description"].ToString();
                }
                doc.IsActive = Convert.ToBoolean(dt.Rows[i]["isActive"]);

                docs.Add(doc);
            }
            
            return docs;
        }

    }
}

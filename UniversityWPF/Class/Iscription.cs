using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UniversityWPF.Class
{
    class Iscription
    {
        private int idInscription;
        public int IdInscription
        {
            get { return idInscription; }
            set { idInscription = value; }
        }

        private int idMatter;
        public int IdMatter
        {
            get { return idMatter; }
            set { idMatter = value; }
        }

        private string nameMatter;
        public string NameMatter
        {
            get { return nameMatter; }
            set { nameMatter = value; }
        }

        private int idPerson;
        public int IdPerson
        {
            get { return idPerson; }
            set { idPerson = value; }
        }

        private string namePerson;
        public string NamePerson
        {
            get { return namePerson; }
            set { namePerson = value; }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Actions Action { get; set; }
        
        public ObservableCollection<Iscription> getInscription(DataTable dt)
        {
            var mat = new ObservableCollection<Iscription>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Iscription ins = new Iscription();
                ins.IdInscription = Convert.ToInt32(dt.Rows[i]["idIscription"]);
                ins.IdMatter = Convert.ToInt32(dt.Rows[i]["idMatter"]);
                ins.NameMatter = dt.Rows[i]["name"].ToString();
                ins.IdPerson = Convert.ToInt32(dt.Rows[i]["idPerson"]);
                ins.NamePerson = dt.Rows[i]["name1"].ToString();
                ins.IsActive = Convert.ToBoolean(dt.Rows[i]["isActive"]);

                mat.Add(ins);
            }

            return mat;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UniversityWPF.Class
{
    class Matter
    {
        private int idMatter;
        public int IdMatter
        {
            get { return idMatter; }
            set { idMatter = value; }
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
        
        public ObservableCollection<Matter> getMatter(DataTable dt)
        {
            var cursos = new ObservableCollection<Matter>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Matter curso = new Matter();
                curso.IdMatter = Convert.ToInt32(dt.Rows[i]["idMatter"]);
                curso.Name = dt.Rows[i]["name"].ToString();
                if (dt.Rows[i]["description"] == null)
                {
                    curso.Description = "";
                }
                else
                {
                    curso.Description = dt.Rows[i]["description"].ToString();
                }
                curso.IsActive = Convert.ToBoolean(dt.Rows[i]["isActive"]);

                cursos.Add(curso);
            }

            return cursos;
        }
    }
}

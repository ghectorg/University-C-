using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static ObservableCollection<Matter> getMatter()
        {
            var mat = new ObservableCollection<Matter>();
            return mat;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int idPerson;
        public int IdPerson
        {
            get { return idPerson; }
            set { idPerson = value; }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public static ObservableCollection<Iscription> getInscription()
        {
            var mat = new ObservableCollection<Iscription>();
            return mat;
        }
    }
}

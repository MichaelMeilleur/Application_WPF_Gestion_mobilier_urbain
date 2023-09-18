using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.Views;
using TP3.Models;

namespace TP3.Models
{
 
        #region Enumerations
    static public class MyEnums
    {

    public enum Inst_Inspect
        {
            Installation,
            Inspection
        }
    }    
        #endregion
        public class Rootobject
        {
            public string type { get; set; }
            public Crs crs { get; set; }
            public Feature[] features { get; set; }
        }

        public class Crs
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Properties
        {
            public string name { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public Properties1 properties { get; set; }
            public Geometry geometry { get; set; }
        }

        public class Properties1
        {
            public int OBJECTID { get; set; }
            public string Element { get; set; }
            public string InspectDat { get; set; }
            public string ElementDes { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public string Actif { get; set; }
            public string Ancree { get; set; }
            public string InstalDate { get; set; }
            public string Materiau { get; set; }
            public int GraRg { get; set; }
            public int GraSec { get; set; }
            public string IndexGparc { get; set; }
            public string Utilisatio { get; set; }
            public string TypeAncrag { get; set; }
            public string Modele { get; set; }
            public string Remarque { get; set; }
            public string Nom_parc { get; set; }
            public float Long { get; set; }
            public float Lat { get; set; }
            public bool CheckAll{ get; set; }
           
    }

        public class Geometry
        {
            public string type { get; set; }
            public float[] coordinates { get; set; }
        }
        public class Mobilier
        {
            public int NbItems { get; set; } = 1;
            public bool SélectionnerTout { get; set; }

        }

        public class Filtres
        {
            public bool F_Aucun { get; set; } = true;
            public bool F_ID { get; set; }
            public bool F_Type { get; set; }
            public bool F_Modèle { get; set; }
            public bool F_Description { get; set; }
            public bool F_Parc { get; set; }
            public bool F_Installation { get; set; }
            public bool F_Inspection { get; set; }
            public bool F_Descendant { get; set; }
        public string F_DescriptionFiltre { get; set; } 
            public string F_TypeElement { get; set; }
        public string F_Nom_Parc { get; set; } 
            public DateTime F_Début { get; set; } = DateTime.Today;
            public DateTime F_Fin { get; set; } = DateTime.Today;
            public string F_TypeFiltre { get; set; } 
       
    }
   public static class MaListe
    {
        static public List<Properties1> Liste { get; set; } = new List<Properties1>();
    }
    
}

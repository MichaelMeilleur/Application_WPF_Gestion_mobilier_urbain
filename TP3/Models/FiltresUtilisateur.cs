using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.Models
{
    /// <summary>
    /// Auteurs: Michael Meilleur et Mahdi Ellili
    /// Description: Classe qui contient une liste statique dans laquelle se trouve la liste après le filtrage.
    /// Date: 2022-05-09
    /// </summary>
    static public class FiltresUtilisateur
    {
        static public List<Properties1> FilteredList { get; set; } = new List<Properties1>();
    }
}

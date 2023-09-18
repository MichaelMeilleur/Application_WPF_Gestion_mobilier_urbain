using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP3.Models;
using TP3.Views;
namespace TP3.Views
{
    /// <summary>
    /// Logique d'interaction pour frmFiltres.xaml
    /// </summary>
    /// Auteurs: Mahdi Ellili et Michael Meilleur
    /// Description: Fenêtres contenant les filtres pour la liste.
    /// Date: 2022-04-20
    public partial class frmFiltres : Window
    {
        #region Évémements personnalisées

        #endregion
        MainWindow _window = new MainWindow();
        List<string> LesTypes = new List<string>();
       
        public frmFiltres()
        {
            InitializeComponent();
            cmbInstallOuInspect.ItemsSource = Enum.GetNames(typeof(MyEnums.Inst_Inspect));
            var req = from item in MaListe.Liste
                     // group item by item.Element
                     orderby item.Element 
                        select item.Element;

      
      

            LesTypes = req.Distinct().ToList();
            cmbType.ItemsSource = LesTypes;
            cmbType.Items.Refresh();
        }
        
      
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP3.Models;
using TP3.Views;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
namespace TP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Auteurs: Mahdi Ellili et Michael Meilleur
    /// Description: Fenêtre contenant la liste.
    /// Date: 2020-04-26
    public partial class MainWindow : Window
    {
        #region Constantes
        const string Nom_Fichier = "mobilierurbaingp.json";
       
        #endregion

        #region Champs
        private frmFiltres _filtres = null;
        private Mobilier _opt = new Mobilier();
        private Properties1 _prop = new Properties1();
        private Filtres _FiltresUtilisateur = new Filtres(); 
        private Rootobject _obj = new Rootobject();
        private Feature _feat = new Feature();
        #endregion

        #region Méthodes

        /// <summary>
        /// Auteurs: Mahdi Ellili et Michael Meilleur
        /// Description: Appliquer les filtres sur la liste.
        /// Date: 2022-04-28
        /// </summary>
        /// <param name="UserFilters"></param>
        public void AppliquerFiltres(Filtres UserFilters)
        {
            FiltresUtilisateur.FilteredList.Clear();
            if (UserFilters.F_Aucun)
            {
                lstDonnées.ItemsSource = FiltresUtilisateur.FilteredList;
                lstDonnées.Items.Refresh();
            }
            else
            {

                if (UserFilters.F_ID) //Filtrer avec le ID
                {

                    if (UserFilters.F_Descendant)
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.OBJECTID descending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                    else
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.OBJECTID ascending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                }
                if (UserFilters.F_Type) //Filtrer avec type
                {
                    if (UserFilters.F_Descendant)
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.Element descending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                    else
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.Element ascending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                }
                if (UserFilters.F_Modèle) //Filtrer avec le modèle
                {
                    if (UserFilters.F_Descendant)
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.Modele descending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                    else
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.Modele ascending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }

                }
                if (UserFilters.F_Description) //Filtrer avec description
                {
                    if (UserFilters.F_Descendant)
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.ElementDes descending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                    else
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.ElementDes ascending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                }
                if (UserFilters.F_Parc)  //Filtrer avec Parc
                {
                    if (UserFilters.F_Descendant)
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.Nom_parc descending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                    else
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.Nom_parc ascending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                }
                if (UserFilters.F_Installation)  //Filtrer avec la date d'installation
                {
                    if (UserFilters.F_Descendant)
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.InstalDate descending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                    else
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.InstalDate ascending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                }
                if (UserFilters.F_Inspection)  //Filtrer avec la date d'inspection
                {
                    if (UserFilters.F_Descendant)
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.InspectDat descending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                    else
                    {
                        var req = from items in MaListe.Liste
                                  orderby items.InspectDat ascending
                                  select items;
                        foreach (Properties1 line in req)
                        {
                            FiltresUtilisateur.FilteredList.Add(line);
                        }
                    }
                }
            }

            if (UserFilters.F_DescriptionFiltre != null)  //Filtrer avec descriptio (Texte)
            {
                var req = from items in MaListe.Liste
                          where items.ElementDes.Contains(UserFilters.F_DescriptionFiltre)
                          select items;
                foreach (Properties1 item in req)
                {
                    FiltresUtilisateur.FilteredList.Add(item);
                }
                lstDonnées.ItemsSource = FiltresUtilisateur.FilteredList;
                lstDonnées.Items.Refresh();
            }


            if (UserFilters.F_TypeFiltre != null && UserFilters.F_Aucun == true)  //Filtrer avec le type (à partir d'une liste) 
            {

                var req = from items in MaListe.Liste
                          where items.Element == UserFilters.F_TypeFiltre.ToString()
                          select items;
                foreach (Properties1 item in req)
                {
                    FiltresUtilisateur.FilteredList.Add(item);
                }
            }



            if (UserFilters.F_Nom_Parc != null)   //Filtrer avec le nom du parc (Texte)
            {
                var req = from items in MaListe.Liste
                          where items.Nom_parc != null && items.Nom_parc.Contains(UserFilters.F_Nom_Parc)

                          select items;

                foreach (Properties1 item in req)
                {
                    FiltresUtilisateur.FilteredList.Add(item);
                }
                lstDonnées.ItemsSource = FiltresUtilisateur.FilteredList;
                lstDonnées.Items.Refresh();
            }
            if (UserFilters.F_TypeElement != null)   // Choix du type du filtre (Liste contenant Installation ou Inspection  (dates) ) 
            {


                if (UserFilters.F_TypeElement == MyEnums.Inst_Inspect.Installation.ToString()) //Filtrer selon la date d'installation
                {
                    var req = from items in MaListe.Liste
                              where Between(Convert.ToDateTime(items.InstalDate), UserFilters.F_Début, UserFilters.F_Fin)
                              select items;
                    foreach (Properties1 item in req)
                    {
                        FiltresUtilisateur.FilteredList.Add(item);
                    }
                }
                if (UserFilters.F_TypeElement == MyEnums.Inst_Inspect.Inspection.ToString())  //Filtrer selon la date d'inspection
                {
                    var req = from items in MaListe.Liste
                              where Between(Convert.ToDateTime(items.InspectDat), UserFilters.F_Début, UserFilters.F_Fin)
                              select items;
                    foreach (Properties1 item in req)
                    {
                        FiltresUtilisateur.FilteredList.Add(item);
                    }
                }

            }

            lstDonnées.ItemsSource = FiltresUtilisateur.FilteredList;
            lstDonnées.Items.Refresh();

        }

        /// <summary>
        /// Auteurs: Michael Meilleur et Mahdi Ellili
        /// Description: Prends deux dates pour sélectionner la période de temps entre ces deux dates.
        /// Date: 2022-04-28
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Début"></param>
        /// <param name="Fin"></param>
        /// <returns>Date entre les deux</returns>
        public bool Between(DateTime Source, DateTime Début, DateTime Fin)
        {
            return (Source > Début && Source < Fin);
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Événements
        /// <summary>
        /// Auteurs: Mahdi Ellili et Micheal Meilleur
        /// Desription : Boutton qui permet de charger la liste à partrir d'un fichier JSON
        /// Date: 2022-04-08
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCharger_Click(object sender, RoutedEventArgs e)
        {
            //Variales locales 
            string sJson = "";
            StreamReader sr = null;


            //Lecture du fichier JSON
            if (File.Exists(Nom_Fichier))
            {
                sr = new StreamReader(Nom_Fichier);
                sJson = sr.ReadToEnd();

                sr.Close();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                };

                //Désérialiser le texte JSON
                _obj = JsonSerializer.Deserialize<Rootobject>(sJson);
                foreach (Feature rootobject in _obj.features)
                {

                    _feat = rootobject;
                    MaListe.Liste.Add(_feat.properties);
                }
                lstDonnées.ItemsSource = MaListe.Liste;
                lstDonnées.Items.Refresh();
                _opt.NbItems = MaListe.Liste.Count;
                grdMain.DataContext = _opt;

            }


        }



        private void btnFiltrer_Click(object sender, RoutedEventArgs e)
        {
            if (_filtres == null)
            {
                _filtres = new frmFiltres();
                _filtres.Closed += _filtres_Closed;
                _filtres.Owner = this;
                _filtres.DataContext = _FiltresUtilisateur;
                _filtres.Show();
                _filtres.btnAppliquerFiltres.Click += BtnAppliquerFiltres_Click;
            }
            else
                _filtres.Focus();

        }

        private void BtnAppliquerFiltres_Click(object sender, RoutedEventArgs e)
        {
            AppliquerFiltres((Filtres)_filtres.DataContext);


        }



        private void _filtres_Closed(object sender, EventArgs e)
        {
            _filtres = null;

        }
        #endregion

    }
}

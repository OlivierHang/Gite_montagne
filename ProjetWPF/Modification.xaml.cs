using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour Modification.xaml
    /// </summary>
    public partial class Modification : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Desktop\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Documents\AFPA\GîteDeHauteMontagne\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");

        // Variable comparaison entre données original et update
        string dateOrig;
        int dureeOrig;

        // Variable pour la Resa
        string date;
        int duree;

        // Liste d'Herbeg
        List<string> lstHeberg = new List<string>();
        List<string> lstHebergOccupe = new List<string>();
        List<string> lstHebergChoix = new List<string>();

        // Variable du Client
        string nomPersonne;

        // Liste Id Resa
        List<int> lstIdResa = new List<int>();

        // Variable pour Resa_Heberg:
        // ID Resa
        int idResa;
        // Liste ID Heberg
        List<int> lstIdHebergChoix = new List<int>();
        // Liste date
        List<string> lstDateReserver = new List<string>();

        public Modification()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region isEnabled
            datePickerArriver.IsEnabled = false;
            textBoxDuree.IsEnabled = false;
            btnConfirm.IsEnabled = false;
            comboBoxHebergement.IsEnabled = false;
            btnAjoutHebergement.IsEnabled = false;
            textBoxNomPersonne.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnAnnuler.IsEnabled = false;
            comboBoxHebergementChoix.IsEnabled = false;
            btnSupprHebergement.IsEnabled = false; 
            #endregion

            #region Ajout tout les heberg dans lstHeberg
            con.Open();

            string reqAllHeberg = "select nom from Hebergement Order by id";
            var cmdAllHeberg = new SqlCommand(reqAllHeberg, con);
            SqlDataReader rdrAllHeberg = cmdAllHeberg.ExecuteReader();

            while (rdrAllHeberg.Read())
            {
                lstHeberg.Add(rdrAllHeberg.GetString(0));
            }

            con.Close();
            #endregion

            #region Select tout les Id Reservation
            con.Open();

            string reqSelectIdResa = "select id from Reservation";

            var cmdSelectIdResa = new SqlCommand(reqSelectIdResa, con);
            SqlDataReader rdrSelectIdResa = cmdSelectIdResa.ExecuteReader();
            while (rdrSelectIdResa.Read())
            {
                lstIdResa.Add(rdrSelectIdResa.GetInt32(0));
            }

            con.Close();
            #endregion

            comboBoxIdRes.ItemsSource = lstIdResa;
        }

        private void comboBoxIdRes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idResa = (int)comboBoxIdRes.SelectedItem;

            #region Select date par rapport à un idResa
            con.Open();

            string reqSelectDateResa = $"select date_arriver from Reservation where id = {idResa}";

            var cmdSelectDateResa = new SqlCommand(reqSelectDateResa, con);
            SqlDataReader rdrSelectDateResa = cmdSelectDateResa.ExecuteReader();
            rdrSelectDateResa.Read();
            DateTime dtResa = rdrSelectDateResa.GetDateTime(0);
            dateOrig = dtResa.ToString("yyyy/MM/dd");

            con.Close();
            #endregion

            #region Select duree par rapport à un idResa
            con.Open();

            string reqSelectDureeResa = $"select duree from Reservation where id = {idResa}";

            var cmdSelectDureeResa = new SqlCommand(reqSelectDureeResa, con);
            SqlDataReader rdrSelectDureeResa = cmdSelectDureeResa.ExecuteReader();
            rdrSelectDureeResa.Read();

            dureeOrig = rdrSelectDureeResa.GetInt32(0);

            con.Close();
            #endregion

            #region Select nom client
            con.Open();

            string reqNomClient = $"select nom from Client where id_reservation = {idResa}";

            var cmdNomClient = new SqlCommand(reqNomClient, con);
            SqlDataReader rdrNomClient = cmdNomClient.ExecuteReader();
            rdrNomClient.Read();
            string nomPersonne2 = rdrNomClient.GetString(0);

            con.Close();
            #endregion

            datePickerArriver.SelectedDate = dtResa;
            textBoxDuree.Text = dureeOrig.ToString();
            comboBoxHebergementChoix.ItemsSource = lstHebergChoix;
            textBoxNomPersonne.Text = nomPersonne2;

            datePickerArriver.IsEnabled = true;
            textBoxDuree.IsEnabled = true;
            btnConfirm.IsEnabled = true;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            #region isEnabled
            comboBoxHebergement.IsEnabled = true;
            btnAjoutHebergement.IsEnabled = true;
            comboBoxHebergementChoix.IsEnabled = true;
            btnSupprHebergement.IsEnabled = true;
            textBoxNomPersonne.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnAnnuler.IsEnabled = true;

            comboBoxIdRes.IsEnabled = false;
            datePickerArriver.IsEnabled = false;
            textBoxDuree.IsEnabled = false;
            btnConfirm.IsEnabled = false; 
            #endregion

            DateTime dt = (DateTime)datePickerArriver.SelectedDate;
            date = dt.ToString("yyyy/MM/dd");
            duree = int.Parse(textBoxDuree.Text);

            #region Ajout Date dans lstDateReserver
            DateTime dt2 = (DateTime)datePickerArriver.SelectedDate;
            for (int i = 0; i < duree; i++)
            {
                lstDateReserver.Add(dt2.AddDays(i).ToString("yyyy/MM/dd"));
            }
            #endregion

            #region Ajout heberg dans lstHebergOcc
            con.Open();

            string reqHebergOcc = "select distinct nom from Hebergement inner join Reservation_Hebergement " +
                "on Hebergement.Id = Reservation_Hebergement.id_hebergement " +
                $"where date_reserver between '{date}' and dateadd(day, {duree + 1}, '{date}')";

            var cmdHeberOcc = new SqlCommand(reqHebergOcc, con);
            SqlDataReader rdrHeberOcc = cmdHeberOcc.ExecuteReader();

            while (rdrHeberOcc.Read())
            {
                lstHebergOccupe.Add(rdrHeberOcc.GetString(0));
            }

            con.Close();
            #endregion

            // Met la liste des hébergements à jour, compare lstHeberg avec lstHebergOccupe
            for (int i = 0; i < lstHeberg.Count; i++)
            {
                for (int j = 0; j < lstHebergOccupe.Count; j++)
                {
                    if (lstHeberg[i] == lstHebergOccupe[j])
                    {
                        lstHeberg.RemoveAt(i);
                    }
                }
            }

            if (dateOrig == date && dureeOrig >= duree)
            {
                #region Ajout hebergement dans lstHebergChoix
                con.Open();

                string reqSelectNomHeb = "select distinct nom from Hebergement inner join Reservation_Hebergement " +
                    "on Hebergement.Id = Reservation_Hebergement.id_hebergement " +
                    $"where id_reservation = {idResa}";

                var cmdSelectNomHeb = new SqlCommand(reqSelectNomHeb, con);
                SqlDataReader rdrNomHeb = cmdSelectNomHeb.ExecuteReader();

                while (rdrNomHeb.Read())
                {
                    lstHebergChoix.Add(rdrNomHeb.GetString(0));
                }

                con.Close();
                #endregion
            }

            comboBoxHebergement.ItemsSource = lstHeberg;
        }

        private void btnAjoutHebergement_Click(object sender, RoutedEventArgs e)
        {
            // Ajoute à la liste des hebergements choisi par Client
            lstHebergChoix.Add(comboBoxHebergement.SelectedItem.ToString());

            for (int i = 0; i < lstHeberg.Count; i++)
            {
                for (int j = 0; j < lstHebergChoix.Count; j++)
                {
                    if (lstHeberg[i] == lstHebergChoix[j])
                    {
                        lstHeberg.RemoveAt(i);
                    }
                }
            }

            //Refresh de la comboBox
            #region Refresh comboBoxHebergement et comboBoxHebergementChoix
            comboBoxHebergement.ItemsSource = null;
            comboBoxHebergement.ItemsSource = lstHeberg;
            comboBoxHebergement.SelectedIndex = -1;

            comboBoxHebergementChoix.ItemsSource = null;
            comboBoxHebergementChoix.ItemsSource = lstHebergChoix;
            comboBoxHebergementChoix.SelectedIndex = -1;
            #endregion

            textBoxNomPersonne.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnAnnuler.IsEnabled = true;
        }

        private void btnSupprHebergement_Click(object sender, RoutedEventArgs e)
        {
            lstHeberg.Add(comboBoxHebergementChoix.SelectedItem.ToString());

            for (int i = 0; i < lstHeberg.Count; i++)
            {
                for (int j = 0; j < lstHebergChoix.Count; j++)
                {
                    if (lstHeberg[i] == lstHebergChoix[j])
                    {
                        lstHebergChoix.RemoveAt(j);
                    }
                }
            }

            #region Refresh comboBoxHebergement et comboBoxHebergementChoix
            comboBoxHebergement.ItemsSource = null;
            comboBoxHebergement.ItemsSource = lstHeberg;
            comboBoxHebergement.SelectedIndex = -1;

            comboBoxHebergementChoix.ItemsSource = null;
            comboBoxHebergementChoix.ItemsSource = lstHebergChoix;
            comboBoxHebergementChoix.SelectedIndex = -1;
            #endregion

            textBoxNomPersonne.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnAnnuler.IsEnabled = true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            nomPersonne = textBoxNomPersonne.Text;

            #region Ajout Id Hebergement à dans lstIdHebergChoix
            for (int i = 0; i < lstHebergChoix.Count; i++)
            {
                con.Open();

                string reqIdHeberg = $"select id from Hebergement where nom = '{lstHebergChoix[i]}';";
                var cmdIdHeberg = new SqlCommand(reqIdHeberg, con);

                SqlDataReader rdrIdHeberg = cmdIdHeberg.ExecuteReader();
                rdrIdHeberg.Read();
                lstIdHebergChoix.Add(rdrIdHeberg.GetInt32(0));

                con.Close();
            }
            #endregion

            #region Update dans Table Reservation
            con.Open();

            string reqUpdateResa = "Update Reservation " +
                $"Set date_arriver = '{date}', duree = {duree}" +
                $"where id = {idResa}";

            var cmdInsertResa = new SqlCommand(reqUpdateResa, con);
            cmdInsertResa.ExecuteNonQuery();

            con.Close();
            #endregion

            #region Update dans Table Client
            con.Open();

            string reqUpdateClient = "Update Client " +
                $"Set nom = '{nomPersonne}' where id_reservation = {idResa}";

            var cmdInsertClient = new SqlCommand(reqUpdateClient, con);
            cmdInsertClient.ExecuteNonQuery();

            con.Close();
            #endregion

            #region Delete dans Table Reservation_Hebergement
            con.Open();

            string reqDelResHeb = $"Delete from Reservation_Hebergement where id_reservation = {idResa}";

            var cmdDelResHeb = new SqlCommand(reqDelResHeb, con);
            cmdDelResHeb.ExecuteNonQuery();

            con.Close();
            #endregion

            #region Insert dans Table Reservation_Hebergement
            for (int i = 0; i < lstIdHebergChoix.Count; i++)
            {
                for (int j = 0; j < lstDateReserver.Count; j++)
                {
                    con.Open();

                    string reqInsertResaHeberg = "insert into Reservation_Hebergement (id_reservation, id_hebergement, date_reserver) " +
                        $"values({idResa}, {lstIdHebergChoix[i]}, '{lstDateReserver[j]}')";

                    var cmdInsertResaHeberg = new SqlCommand(reqInsertResaHeberg, con);
                    cmdInsertResaHeberg.ExecuteNonQuery();

                    con.Close();
                }
            }
            #endregion

            MessageBox.Show("Modification réussi !");
            this.Close();

        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            // Reset
            datePickerArriver.SelectedDate = null;
            textBoxDuree.Clear();
            comboBoxHebergement.ItemsSource = null;
            textBoxNomPersonne.Clear();
            comboBoxHebergementChoix.ItemsSource = null;

            
            lstHebergChoix.Clear();
            lstHeberg.Clear();
            lstHebergOccupe.Clear();
            lstIdHebergChoix.Clear();
            lstDateReserver.Clear();

            #region Ajout tout les heberg dans lstHeberg
            con.Open();

            string reqAllHeberg = "select nom from Hebergement Order by id";
            var cmdAllHeberg = new SqlCommand(reqAllHeberg, con);
            SqlDataReader rdrAllHeberg = cmdAllHeberg.ExecuteReader();

            while (rdrAllHeberg.Read())
            {
                lstHeberg.Add(rdrAllHeberg.GetString(0));
            }

            con.Close();
            #endregion

            #region isEnabled
            comboBoxIdRes.IsEnabled = true;

            datePickerArriver.IsEnabled = false;
            textBoxDuree.IsEnabled = false;
            btnConfirm.IsEnabled = false;
            btnSupprHebergement.IsEnabled = false;
            comboBoxHebergementChoix.IsEnabled = false;
            comboBoxHebergement.IsEnabled = false;
            btnAjoutHebergement.IsEnabled = false;
            textBoxNomPersonne.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnAnnuler.IsEnabled = false; 
            #endregion
        }

    }
}

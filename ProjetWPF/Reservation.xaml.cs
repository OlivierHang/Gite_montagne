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
    /// Logique d'interaction pour Reservation.xaml
    /// </summary>
    public partial class Resa : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Desktop\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Documents\AFPA\GîteDeHauteMontagne\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");

        // Variable pour la Resa
        string date;
        int duree;

        // Liste d'Herbeg
        List<string> lstHeberg = new List<string>();
        List<string> lstHebergOccupe = new List<string>();
        List<string> lstHebergChoix = new List<string>();

        // Variable du Client
        string nomPersonne;

        // Variable pour Resa_Heberg:
        // ID Resa
        int idResa;
        // Liste ID Heberg
        List<int> lstIdHebergChoix = new List<int>();
        // Liste date
        List<string> lstDateReserver = new List<string>();

        public Resa()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxHebergement.IsEnabled = false;
            btnAjoutHebergement.IsEnabled = false;
            textBoxNomPersonne.IsEnabled = false;
            btnReserver.IsEnabled = false;
            btnAnnulerRes.IsEnabled = false;

            #region Ajout heberg dans lstHeberg
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
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            comboBoxHebergement.IsEnabled = true;
            btnAjoutHebergement.IsEnabled = true;

            datePickerArriver.IsEnabled = false;
            textBoxDuree.IsEnabled = false;
            btnConfirm.IsEnabled = false;

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

            comboBoxHebergement.ItemsSource = lstHeberg;
        }

        private void btnAjoutHebergement_Click(object sender, RoutedEventArgs e)
        {
            // Ajoute à la liste des hebergements choisi par Client
            lstHebergChoix.Add(comboBoxHebergement.SelectedItem.ToString());

            #region Ajout Id Hebergement à dans lstIdHebergChoix
            con.Open();

            string reqIdHeberg = $"select id from Hebergement where nom = '{comboBoxHebergement.SelectedItem.ToString()}';";
            var cmdIdHeberg = new SqlCommand(reqIdHeberg, con);

            SqlDataReader rdrIdHeberg = cmdIdHeberg.ExecuteReader();
            rdrIdHeberg.Read();
            lstIdHebergChoix.Add(rdrIdHeberg.GetInt32(0));

            con.Close();
            #endregion

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
            comboBoxHebergement.ItemsSource = null;
            comboBoxHebergement.ItemsSource = lstHeberg;
            comboBoxHebergement.SelectedIndex = -1;

            textBoxNomPersonne.IsEnabled = true;
            btnReserver.IsEnabled = true;
            btnAnnulerRes.IsEnabled = true;
        }

        private void btnReserver_Click(object sender, RoutedEventArgs e)
        {
            nomPersonne = textBoxNomPersonne.Text;

            #region Insert dans Table Reservation
            con.Open();

            string reqInsertResa = "Insert into Reservation (date_arriver, duree) " +
                $"values ('{date}', {duree} )";

            var cmdInsertResa = new SqlCommand(reqInsertResa, con);
            cmdInsertResa.ExecuteNonQuery();

            con.Close();
            #endregion

            #region Select Id Reservation
            con.Open();

            string reqSelectIdResa = "select max(id) from Reservation";

            var cmdSelectIdResa = new SqlCommand(reqSelectIdResa, con);
            SqlDataReader rdrSelectIdResa = cmdSelectIdResa.ExecuteReader();
            rdrSelectIdResa.Read();
            idResa = rdrSelectIdResa.GetInt32(0);

            con.Close();
            #endregion

            #region Insert dans Table Client
            con.Open();

            string reqInsertClient = "insert into Client (nom, id_reservation) " +
                $"values ('{nomPersonne}', {idResa})";

            var cmdInsertClient = new SqlCommand(reqInsertClient, con);
            cmdInsertClient.ExecuteNonQuery();

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

            MessageBox.Show($"Numéro de la réservation : {idResa}");
            this.Close();

        }

        private void btnAnnulerRes_Click(object sender, RoutedEventArgs e)
        {
            // Reset
            datePickerArriver.SelectedDate = null;
            textBoxDuree.Clear();
            comboBoxHebergement.ItemsSource = null;
            textBoxNomPersonne.Clear();

            lstHebergChoix.Clear();
            lstHeberg.Clear();
            lstHebergOccupe.Clear();
            lstIdHebergChoix.Clear();
            lstDateReserver.Clear();

            #region Ajout heberg dans lstHeberg
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

            datePickerArriver.IsEnabled = true;
            textBoxDuree.IsEnabled = true;
            btnConfirm.IsEnabled = true;

            comboBoxHebergement.IsEnabled = false;
            btnAjoutHebergement.IsEnabled = false;
            textBoxNomPersonne.IsEnabled = false;
            btnReserver.IsEnabled = false;
            btnAnnulerRes.IsEnabled = false;
        }
    }
}

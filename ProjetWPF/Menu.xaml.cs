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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Desktop\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Documents\AFPA\GîteDeHauteMontagne\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");
        List<Reservation> lstResa = new List<Reservation>();

        public Menu()
        {
            InitializeComponent();

            dtGridRes.IsEnabled = false;

            #region Ajout reservation dans lstResa
            con.Open();

            string reqResa = "SELECT Reservation.Id, Reservation.date_arriver, Reservation.duree, Client.nom FROM Reservation inner join Client ON Reservation.Id = Client.id_reservation ORDER BY Reservation.date_arriver asc";
            var cmdResa = new SqlCommand(reqResa, con);
            SqlDataReader rdrResa = cmdResa.ExecuteReader();

            while (rdrResa.Read())
            {
                Reservation uneResa = new Reservation(rdrResa.GetInt32(0), rdrResa.GetDateTime(1).ToString("yyyy/MM/dd"),
                    rdrResa.GetInt32(2), rdrResa.GetString(3));

                lstResa.Add(uneResa);
            }

            con.Close();
            #endregion

            // Info pour la DataGrid
            dtGridRes.ItemsSource = lstResa;

        }

        private void btnReserv_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Resa winReserv = new Resa();
            winReserv.ShowDialog();
            this.Show();

            #region Refresh dataGrid

            lstResa.Clear();

            #region Ajout reservation dans lstResa
            con.Open();

            string reqResa = "select Reservation.Id, Reservation.date_arriver, Reservation.duree, Client.nom from Reservation inner join Client on Reservation.Id = Client.id_reservation ORDER BY Reservation.date_arriver asc";
            var cmdResa = new SqlCommand(reqResa, con);
            SqlDataReader rdrResa = cmdResa.ExecuteReader();

            while (rdrResa.Read())
            {
                Reservation uneResa = new Reservation(rdrResa.GetInt32(0), rdrResa.GetDateTime(1).ToString("yyyy/MM/dd"),
                    rdrResa.GetInt32(2), rdrResa.GetString(3));

                lstResa.Add(uneResa);
            }

            con.Close();
            #endregion

            dtGridRes.ItemsSource = null;
            dtGridRes.ItemsSource = lstResa;
            #endregion
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Modification winModif = new Modification();
            winModif.ShowDialog();
            this.Show();

            #region Refresh dataGrid

            lstResa.Clear();

            #region Ajout reservation dans lstResa
            con.Open();

            string reqResa = "select Reservation.Id, Reservation.date_arriver, Reservation.duree, Client.nom from Reservation inner join Client on Reservation.Id = Client.id_reservation ORDER BY Reservation.date_arriver asc";
            var cmdResa = new SqlCommand(reqResa, con);
            SqlDataReader rdrResa = cmdResa.ExecuteReader();

            while (rdrResa.Read())
            {
                Reservation uneResa = new Reservation(rdrResa.GetInt32(0), rdrResa.GetDateTime(1).ToString("yyyy/MM/dd"),
                    rdrResa.GetInt32(2), rdrResa.GetString(3));

                lstResa.Add(uneResa);
            }

            con.Close();
            #endregion

            dtGridRes.ItemsSource = null;
            dtGridRes.ItemsSource = lstResa;
            #endregion
        }

        private void btnAnnul_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Annulation winAnnul = new Annulation();
            winAnnul.ShowDialog();
            this.Show();

            #region Refresh dataGrid

            lstResa.Clear();

            #region Ajout reservation dans lstResa
            con.Open();

            string reqResa = "select Reservation.Id, Reservation.date_arriver, Reservation.duree, Client.nom from Reservation inner join Client on Reservation.Id = Client.id_reservation ORDER BY Reservation.date_arriver asc";
            var cmdResa = new SqlCommand(reqResa, con);
            SqlDataReader rdrResa = cmdResa.ExecuteReader();

            while (rdrResa.Read())
            {
                Reservation uneResa = new Reservation(rdrResa.GetInt32(0), rdrResa.GetDateTime(1).ToString("yyyy/MM/dd"),
                    rdrResa.GetInt32(2), rdrResa.GetString(3));

                lstResa.Add(uneResa);
            }

            con.Close();
            #endregion

            dtGridRes.ItemsSource = null;
            dtGridRes.ItemsSource = lstResa;
            #endregion
        }
    }
}

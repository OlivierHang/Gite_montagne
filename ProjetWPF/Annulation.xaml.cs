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
    /// Logique d'interaction pour Annulation.xaml
    /// </summary>
    public partial class Annulation : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Desktop\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Documents\AFPA\GîteDeHauteMontagne\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");

        public Annulation()
        {
            InitializeComponent();
        }

        private void btnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            con.Open();

            string reqConfirm = $"Select Count(*) from Reservation where id = {textBoxNumResa.Text}";
            var cmdConfirm = new SqlCommand(reqConfirm, con);

            SqlDataReader rdr = cmdConfirm.ExecuteReader();
            rdr.Read();
            int resultCmtConfirm = rdr.GetInt32(0);
            con.Close();

            if (resultCmtConfirm == 0)
            {
                MessageBox.Show("N'existe pas !");
                textBoxNumResa.Clear();
            }
            else
            {
                con.Open();
                string req = $"Delete from Reservation Where id = {textBoxNumResa.Text}";
                var cmd = new SqlCommand(req, con);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Delete Effectué !");
                textBoxNumResa.Clear();
            }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Desktop\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\hangs\Documents\AFPA\GîteDeHauteMontagne\GîteDeHauteMontagne\ProjetWPF\gîte.mdf;Integrated Security = True; Connect Timeout = 30");
        public MainWindow()
        {
            InitializeComponent();
            textBoxLogin.Text = "1";
            textBoxMdp.Text = "1";
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            string mdpEntrer = textBoxMdp.Text;
            string mdpBd;

            #region Recup password
            con.Open();

            string req = $"select password from Employe where id = {textBoxLogin.Text}";
            var cmd = new SqlCommand(req, con);

            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            mdpBd = rdr.GetString(0);

            con.Close();
            #endregion

            if (mdpEntrer == mdpBd)
            {
                this.Hide();
                Menu winMenu = new Menu();
                winMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mauvaise Login/Mot de passe");
                textBoxLogin.Clear();
                textBoxMdp.Clear();
            }

        }
    }
}

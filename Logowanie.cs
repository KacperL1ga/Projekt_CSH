using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            this.StartPosition = FormStartPosition.CenterScreen; // Ustawienie pozycji okna na srodek ekranu
            InitializeComponent();
        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = loginBox.Text;    // Pobieramy nazwe uzytkownika z Boxa
            string password = passwdBox.Text;   // Pobieramy haslo uzytkownika z Boxa

            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username = @username AND password = @password";   // Zapytanie SQL do bazy danych

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);     // Dodajemy parametr do zapytania
                    cmd.Parameters.AddWithValue("@password", password);     // Dodajemy parametr do zapytania
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())      // Sprawdzamy czy istnieje taki uzytkownik w bazie danych
                        {
                            int Id = reader.GetInt32(reader.GetOrdinal("id"));  // Pobieramy ID uzytkownika z bazy danych
                            MessageBox.Show("Zalogowano pomyślnie!");   // Informacja o pomyslnym zalogowaniu
                            this.Hide();    // Ukrywamy okno logowania
                            Main mainForm = new Main(Id); // Tworzymy nowe okno glowne
                            mainForm.Show();    // Pokazujemy okno glowne
                        }
                        else
                        {
                            MessageBox.Show("Błędna nazwa użytkownika lub hasło!");     // Informacja o blednych danych logowania
                        }
                    }
                }
            }
        }

        private void RejestracjaBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rejestracja rejestracjaForm = new Rejestracja(); // Tworzymy nowe okno rejestracji
            rejestracjaForm.Show(); // Pokazujemy okno rejestracji
            
        }
    }
}

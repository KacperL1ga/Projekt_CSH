using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
    public partial class SavingKonto : Form
    {
        private int _id;
        public SavingKonto(int Id)
        {
            this.StartPosition = FormStartPosition.CenterScreen; // Ustawienie pozycji formularza na środku ekranu
            _id = Id; // Przechowywanie identyfikatora użytkownika
            InitializeComponent();
        }

        private void SavingKonto_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close(); // Zamknięcie bieżącego formularza
            Main mainForm = new Main(_id); // Tworzenie nowego obiektu Main z przekazanym identyfikatorem użytkownika
            mainForm.Show(); // Wyświetlenie formularza Main
            this.Hide(); // Ukrycie bieżącego formularza
        }

        private void RandomNumber_Click(object sender, EventArgs e)
        {
            int randomNumber;
            bool exist;
            var rand = new Random();

            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();
                do
                {
                    randomNumber = rand.Next(10000, 100000);
                    string checkQuery = "SELECT COUNT(*) FROM accounts WHERE AccountNumber = @number";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@number", randomNumber);
                        exist = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                } while (exist);
            }
            accnumerBox.Text = randomNumber.ToString();
            MessageBox.Show("Wygenerowano nowy numer konta: " + randomNumber);
        }

        private void MakeSaveAccBtn_Click(object sender, EventArgs e)
        {
            int userId = _id; // Pobranie identyfikatora użytkownika
            int accountNumber;
            if (!int.TryParse(accnumerBox.Text, out accountNumber) || accountNumber <= 10000)
            {
                MessageBox.Show("Nieprawidłowy numer konta!");
                return;
            }

            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();
                string insertQuery = "INSERT INTO accounts (UserId, AccountNumber, Balance, AccountType) VALUES (@userId, @accountNumber, 0, 'Saving')";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    try
                    {
                        cmd.ExecuteNonQuery(); // Wykonanie zapytania wstawiającego
                        MessageBox.Show("Konto oszczędnościowe zostało utworzone pomyślnie!");
                        this.Hide(); // Ukrycie bieżącego formularza
                        Main mainForm = new Main(_id); // Tworzenie nowego obiektu Main z przekazanym identyfikatorem użytkownika
                        mainForm.Show(); // Wyświetlenie formularza Main
                        this.Hide(); // Ukrycie bieżącego formularza
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Wystąpił błąd podczas tworzenia konta oszczędnościowego: {ex.Message}");
                    }
                }
            }
        }
    }
}

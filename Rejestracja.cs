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
    public partial class Rejestracja : Form
    {
        public Rejestracja()
        {
            this.StartPosition = FormStartPosition.CenterScreen; // Ustawienie pozycji okna na srodek ekranu
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = NewloginBox.Text.Trim();  // Pobranie nazwy użytkownika z pola tekstowego
            string password = NewpasswdBox.Text.Trim(); // Pobranie hasła z pola tekstowego
            int accountNumber = int.Parse(accnumerBox.Text.Trim()); // Pobranie numeru konta z pola tekstowego
            int balance = int.Parse(Balance.Text.Trim());   // Pobranie salda z pola tekstowego

            if (accountNumber == 0) // Sprawdzanie czy pole z numerem konta nie jest puste
            {
                MessageBox.Show("Nieprawidłowy numer konta!");
                return;
            }

            if(balance <= 0)    // Sprawdzanie czy kwota jest prawidłowa, większa od zera
            {
                MessageBox.Show("Nieprawidłowa kwota początkowa");
                return;
            }

            // Sprawdzenie, czy wszystkie pola są wypełnione i czy wartości są poprawne
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || accountNumber <= 10000)
            {
                MessageBox.Show("Wszystkie pola są wymagane");
                return;
            }

            using (var conn = DatabaseContex.GetConnection()) // Łączenie z bazą danych
            {                 
                conn.Open(); // Otwarcie połączenia z bazą danych

                // Sprawdzenie, czy użytkownik o podanej nazwie już istnieje
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                using (var checkCmd = new MySql.Data.MySqlClient.MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (userExists > 0)
                    {
                        MessageBox.Show("Użytkownik o takiej nazwie już istnieje!");
                        return;
                    }
                }

                string checkAccNum = "SELECT COUNT(*) FROM accounts WHERE AccountNumber = @number";
                using (var checkAccCmd = new MySql.Data.MySqlClient.MySqlCommand(checkAccNum, conn))
                {
                    checkAccCmd.Parameters.AddWithValue("@number", accountNumber);
                    if (Convert.ToInt32(checkAccCmd.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("Ten numer jest juz zajęty. Wygeneruj nowy.");
                        return;
                    }
                }

                // Wstawienie nowego użytkownika do tabeli 'users'
                string query1 = "INSERT INTO users (username, password) VALUES (@username, @password)";
                using (var cmd1 = new MySql.Data.MySqlClient.MySqlCommand(query1, conn))
                {
                    cmd1.Parameters.AddWithValue("@username", username); // Dodanie parametru username do zapytania
                    cmd1.Parameters.AddWithValue("@password", password); // Dodanie parametru password do zapytania
                    try
                    {
                        cmd1.ExecuteNonQuery(); // Wykonanie zapytania wstawiającego nowego użytkownika
                    }
                    catch (Exception ex) // Obsługa błędów podczas wstawiania użytkownika
                    {
                        MessageBox.Show($"Wystąpił błąd podczas rejestracji użytkownika: {ex.Message}");
                        return;
                    }
                }

                int userID; // Zmienna do przechowywania ID użytkownika
                using (var getID = new MySql.Data.MySqlClient.MySqlCommand("SELECT LAST_INSERT_ID()", conn))    // Zapytanie do bazy o ostatnio wstawione ID
                {
                    userID = Convert.ToInt32(getID.ExecuteScalar()); // Wykonanie zapytania i przypisanie ID do zmiennej
                }
                // Wstawienie nowego konta do tabeli 'account' z użyciem pozostałych danych
                string query2 = "INSERT INTO accounts (AccountNumber, Balance, AccountType, UserId) VALUES (@accountNumber, @balance, 'Main', @userID)";
                using (var cmd2 = new MySql.Data.MySqlClient.MySqlCommand(query2, conn)) // Przygotowanie zapytania do wstawienia pozostałych danych konta
                { 
                    cmd2.Parameters.AddWithValue("@accountNumber", accountNumber); // Dodanie parametru accountNumber do zapytania
                    cmd2.Parameters.AddWithValue("@balance", balance); // Dodanie parametru balance do zapytania
                    cmd2.Parameters.AddWithValue("@userID", userID); // Dodanie parametru userID do zapytania
                    try // Obsługa błędów podczas wstawiania konta
                    {
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Rejestracja zakończona sukcesem!");
                        this.Hide(); // Zamknięcie formularza rejestracji
                        Logowanie loginForm = new Logowanie(); // Utworzenie nowego formularza logowania
                        loginForm.Show(); // Wyświetlenie formularza logowania
                        this.Close(); // Zamknięcie formularza rejestracji
                    }
                    catch (Exception ex) // Wyświetlanie komunikatu o błędzie
                    {
                        MessageBox.Show($"Wystąpił błąd podczas rejestracji: {ex.Message}");
                    }
                }
            }
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
        

        private void Rejestracja_Load(object sender, EventArgs e)
        {

        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ukrycie okna głównego
            Logowanie loginForm = new Logowanie(); // Tworzenie nowego okna logowania
            loginForm.Show(); // Pokazanie okna logowania
            this.Close(); // Zamknięcie okna głównego
        }
    }
}

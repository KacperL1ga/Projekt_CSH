using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankApp
{
    public partial class WithdrawCash : Form
    {
        private int _id; // Identyfikator użytkownika, który będzie używany do operacji na koncie

        public WithdrawCash(int Id)
        {
            this.StartPosition = FormStartPosition.CenterScreen; // Ustawienie pozycji formularza na środku ekranu
            _id = Id;
            InitializeComponent();
            LoadUserAccounts(Id); // Ładowanie kont użytkownika przy inicjalizacji formularza

            var selected = SendKontoBox.SelectedItem as KontoInfo; // Pobieranie wybranego konta z ComboBox
            if (selected != null && selected.AccountType == "Saving")
            {
                TitleOption.Enabled = false; // Wyłączenie wyboru tytułu, jeśli wybrane konto jest oszczędnościowe
                TitleOption.SelectedItem = null; // Czyszczenie wyboru tytułu
            }
            else
            {
                TitleOption.Enabled = true; // Włączenie wyboru tytułu, jeśli wybrane konto nie jest oszczędnościowe
                TitleOption.Items.Clear(); // Czyszczenie listy tytułów
                TitleOption.Items.Add("Wypłata"); // Dodawanie domyślnego tytułu "Wypłata"
                TitleOption.Items.Add("Wypłata w bankomacie"); // Dodawanie tytułu
                TitleOption.Items.Add("BLIK"); // Dodawanie tytułu
                TitleOption.SelectedIndex = 0; // Ustawienie domyślnego tytułu na pierwszy element listy
            }
        }

        private class KontoInfo
        {
            public int AccountId { get; set; }  // Identyfikator konta
            public string AccountType { get; set; } // Typ konta
            public int AccountNumber { get; set; } // Numer konta
            public decimal Balance { get; set; } // Saldo konta
            public override string ToString()
            {
                return $"{AccountType} | {AccountNumber} | {Balance:C}"; // Formatowanie wyświetlania konta
            }
        }

        private void LoadUserAccounts(int Id) // Metoda do załadowania kont użytkownika
        {
            var konta = new List<KontoInfo>(); // Lista kont użytkownika
            using (var conn = DatabaseContex.GetConnection())   // Połączenia z bazą danych
            {
                conn.Open();    // Otwieranie połączenia
                // Zapytanie SQL do pobrania informacji o kontach użytkownika
                string query = "SELECT Id, AccountType, AccountNumber, Balance FROM Accounts WHERE UserId = @UserId";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))  // Tworzenie polecenia SQL
                {
                    cmd.Parameters.AddWithValue("@UserId", Id); // Dodawanie parametru do zapytania
                    using (var reader = cmd.ExecuteReader())    // Wykonywanie zapytania i czytanie wyników
                    {
                        while (reader.Read())   // Przechodzenie przez wyniki zapytania
                        {
                            var konto = new KontoInfo   // Tworzenie obiektu KontoInfo z danymi konta
                            {
                                AccountId = reader.GetInt32("Id"), // Pobieranie identyfikatora konta
                                AccountType = reader.GetString("AccountType"),  // Pobieranie typu konta
                                AccountNumber = reader.GetInt32("AccountNumber"),   // Pobieranie numeru konta
                                Balance = reader.GetDecimal("Balance")  // Pobieranie salda konta
                            };
                            konta.Add(konto);   // Dodawanie konta do listy
                        }
                    }
                }
            }
            SendKontoBox.DataSource = konta; // Ustawienie źródła danych dla ComboBox
            SendKontoBox.DisplayMember = null; // Ustawienie, co ma być wyświetlane w ComboBox

        }
        private void SendKontoBox_Selected(object sender, EventArgs e) // Metoda wywoływana po wybraniu konta oszczednosciowego
        {
            
        }

        private void LoadMainAccount(int Id)
        {
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();    // Otwieranie połączenia z bazą danych
                string query = "SELECT Id, AccountType, AccountNumber, Balance FROM Accounts WHERE UserId = @UserId AND AccountType = 'Main'";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))  // Tworzenie polecenia SQL
                {
                    cmd.Parameters.AddWithValue("@UserId", Id); // Dodawanie parametru do zapytania
                    using (var reader = cmd.ExecuteReader())    // Wykonywanie zapytania i czytanie wyników
                    {
                        if (reader.Read())   // Przechodzenie przez wyniki zapytania
                        {
                            var konto = new KontoInfo   // Tworzenie obiektu KontoInfo z danymi konta
                            {
                                AccountId = reader.GetInt32("Id"), // Pobieranie identyfikatora konta
                                AccountType = reader.GetString("AccountType"),  // Pobieranie typu konta
                                AccountNumber = reader.GetInt32("AccountNumber"),   // Pobieranie numeru konta
                                Balance = reader.GetDecimal("Balance")  // Pobieranie salda konta
                            };
                            ClaimKontoBox.DataSource = new List<KontoInfo> { konto }; // Ustawienie źródła danych dla ClaimKontoBox
                            ClaimKontoBox.DisplayMember = "ToString"; // Ustawienie, co ma być wyświetlane w ClaimKontoBox
                        }
                    }
                }
            }
        }
        private void AcceptTransfer_Click(object sender, EventArgs e)    // Obsługa kliknięcia przycisku akceptacji transferu 
        {
            var selectedAccount = SendKontoBox.SelectedItem as KontoInfo; // Pobieranie wybranego konta z ComboBox
            if (selectedAccount == null)
            {
                MessageBox.Show("Proszę wybrać konto do wypłaty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string title;   // Tytuł transferu
            if (selectedAccount.AccountType == "Saving")
            {
                title = "Wypłata z konta oszczędnościowego"; // Tytuł dla konta oszczędnościowego
            }
            else
            {
                title = TitleOption.SelectedItem?.ToString() ?? "Wypłata";  // Tytuł dla innych kont, domyślnie "Wypłata"
            }
            decimal kwota = BalanceAmount.Value; // Pobieranie kwoty wypłaty
            if (selectedAccount.AccountType == "Saving" && ClaimKontoBox.Visible)   // Jeśli wybrane było konto oszczednościowe zmienia się miejsce zapisu w bazie
            {
                LoadMainAccount(_id);
                var mainAccount = ClaimKontoBox.SelectedItem as KontoInfo; // Pobieranie głównego konta z ClaimKontoBox
                if (mainAccount == null) return; // Jeśli nie wybrano głównego konta, kończymy metodę

                // Zapis transferu w tabeli transfer
                using (var conn = DatabaseContex.GetConnection())
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction()) // Rozpoczęcie transakcji
                    {
                        try
                        {   // Zapis transferu w tabeli transfers
                            string save = "INSERT INTO transfers (send_account, claim_account, amount, Title, transfer_date) VALUES (@sender, @claimer, @amount, @title, NOW())";
                            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(save, conn, trans))  // Tworzenie polecenia SQL
                            {
                                cmd.Parameters.AddWithValue("@sender", selectedAccount.AccountId);  // Dodawanie identyfikatora konta oszczędnościowego jako nadawcy
                                cmd.Parameters.AddWithValue("@claimer", mainAccount.AccountId); // Dodawanie identyfikatora głównego konta jako odbiorcy
                                cmd.Parameters.AddWithValue("@amount", kwota);  // Dodawanie kwoty wypłaty
                                cmd.Parameters.AddWithValue("@title", title);   // Dodawanie tytułu transferu
                                cmd.ExecuteNonQuery();  // Wykonanie polecenia SQL
                            }   
                            
                            // Aktualizacja salda na koncie oszczędnościowym
                            string updateSaving = "UPDATE accounts SET Balance = Balance - @amount WHERE Id = @id";   //Aktualizacja balanus na koncie głownym
                            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(updateSaving, conn))  // Tworzenie polecenia SQL
                            {
                                cmd.Parameters.AddWithValue("@amount", kwota);  // Dodawanie kwoty wypłaty
                                cmd.Parameters.AddWithValue("@id", selectedAccount.AccountId); // Dodawanie identyfikatora głównego konta
                                cmd.ExecuteNonQuery();  // Wykonanie polecenia SQL
                            }

                            // Aktualizacja salda na koncie głównym
                            string updateMain = "UPDATE accounts SET Balance = Balance + @amount WHERE Id = @id";   //Aktualizacja balanus na koncie oszczędnościowym
                            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(updateMain, conn))  // Tworzenie polecenia SQL
                            {
                                cmd.Parameters.AddWithValue("@amount", kwota);  // Dodawanie kwoty wypłaty
                                cmd.Parameters.AddWithValue("@id", mainAccount.AccountId); // Dodawanie identyfikatora konta oszczędnościowego
                                cmd.ExecuteNonQuery();  // Wykonanie polecenia SQL
                            }

                            trans.Commit(); // Zatwierdzenie transakcji
                            MessageBox.Show("Transfer został pomyślnie zrealizowany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback(); // Wycofanie transakcji w przypadku błędu
                            MessageBox.Show($"Wystąpił błąd podczas realizacji transferu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                var mainAccount = selectedAccount; // Jeśli nie wybrano konta oszczędnościowego, używamy wybranego konta jako głównego
                if (mainAccount == null) return;

                // Zapis transferu w tabeli transactions
                using (var conn = DatabaseContex.GetConnection())
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction()) //Rozpoczęcie transakcji
                    {
                        try
                        {
                            // Zapis transferu w tabeli trascations
                            string query = "INSERT INTO transactions (Amount, Date, Description, AccountId) VALUES (@amount, NOW(), @title, @accountId)";
                            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))  // Tworzenie polecenia SQL
                            {
                                cmd.Parameters.AddWithValue("@accountId", mainAccount.AccountId);   // Dodawanie identyfikatora konta jako odbiorcy
                                cmd.Parameters.AddWithValue("@title", title);   // Dodawanie tytułu transferu
                                cmd.Parameters.AddWithValue("@amount", kwota);  // Dodawanie kwoty wypłaty
                                cmd.ExecuteNonQuery(); // Wykonanie polecenia SQL
                            }

                            // Aktualizacja salda na koncie głównym
                            string updateMain = "UPDATE accounts SET Balance = Balance - @amount WHERE Id = @id";   //Aktualizacja balanus na koncie oszczędnościowym
                            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(updateMain, conn))  // Tworzenie polecenia SQL
                            {
                                cmd.Parameters.AddWithValue("@amount", kwota);  // Dodawanie kwoty wypłaty
                                cmd.Parameters.AddWithValue("@id", selectedAccount.AccountId); // Dodawanie identyfikatora konta oszczędnościowego
                                cmd.ExecuteNonQuery();  // Wykonanie polecenia SQL
                            }
                            trans.Commit(); // Zatwierdzenie transakcji
                            MessageBox.Show("Transfer został pomyślnie zrealizowany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback(); // Wycofanie transakcji w przypadku błędu
                            MessageBox.Show($"Wystąpił błąd podczas realizacji transferu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close(); // Zamknięcie formularza po naciśnięciu przycisku "Back"
            Main main = new Main(_id); // Tworzenie nowego obiektu Main z identyfikatorem użytkownika
            main.Show(); // Wyświetlenie formularza Main
            this.Hide(); // Ukrycie bieżącego formularza
        }

        private void KontoBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BalanceAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DescriptionTransfer_TextChanged(object sender, EventArgs e)
        {

        }

        private void SendKontoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = SendKontoBox.SelectedItem as KontoInfo; // Pobieranie wybranego konta z ComboBox
            if (selected != null && selected.AccountType == "Saving")
            {
                LoadMainAccount(_id); // Ładowanie głównego konta, jeśli wybrane konto jest oszczędnościowe
                claimlbl.Visible = true; // Ustawienie widoczności etykiety claimlbl na true
                ClaimKontoBox.Visible = true; // Ustawienie widoczności ClaimKontoBox na true
            }
            else
            {
                claimlbl.Visible = false; // Ukrywanie etykiety claimlbl, jeśli wybrane konto nie jest oszczędnościowe
                ClaimKontoBox.Visible = false; // Ukrywanie ClaimKontoBox, jeśli wybrane konto nie jest oszczędnościowe
            }
        }

        private void TitleOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ClaimKontoBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WithdrawCash_Load(object sender, EventArgs e)
        {

        }
    }
}

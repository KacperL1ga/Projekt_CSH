using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankApp
{
    public partial class DepositCash : Form
    {
        private int _id; // Identyfikator użytkownika, który będzie używany do operacji na koncie
        public DepositCash(int Id)
        {
            this.StartPosition = FormStartPosition.CenterScreen; // Ustawienie pozycji formularza na środku ekranu
            _id = Id;
            InitializeComponent();
            LoadMainAccount(Id);

            // Inicjalizacja opcji tytułu
            TitleOption.Items.Clear();
            TitleOption.Items.Add("Wpłata");
            TitleOption.Items.Add("Wpłata w bankomacie");
            TitleOption.SelectedIndex = 0;
        }

        private class KontoInfo
        {
            public int AccountId { get; set; }  // Identyfikator konta
            public string AccountType { get; set; } // Typ konta
            public int AccountNumber { get; set; }  // Numer konta
            public decimal Balance { get; set; }    // Saldo konta
            public override string ToString()
            {
                return $"{AccountType} | {AccountNumber} | {Balance:C}"; //Formatowanie wyświetlania konta
            }
        }

        
        private void LoadMainAccount(int Id)    // Ładowanie konta głównego użytkownika
        {
            var konto = new List<KontoInfo>();  // Lista kont użytkownika
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();    // Otwiera połaczenie
                string query = "SELECT Id, AccountType, AccountNumber, Balance FROM accounts WHERE UserId = @UserID AND AccountType = 'Main'";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))  // Tworzenia polecenia SQL
                {
                    cmd.Parameters.AddWithValue("@UserId", Id); // Dodawanie parametry do zapytania
                    using (var reader = cmd.ExecuteReader())    // Wykonanie zapytania i czytanie wyników
                    {
                        while (reader.Read())   // Przechodzenie przez wyniki zapytania
                        {
                            konto.Add(new KontoInfo // Tworzenie obiektu KontoInfo z danymi konta
                            {
                                AccountId = reader.GetInt32("Id"),  // Pobieranie identyfikatora konta
                                AccountType = reader.GetString("AccountType"), // Pobieranie typu konta
                                AccountNumber = reader.GetInt32("AccountNumber"),   // Pobieranie numeru konta
                                Balance = reader.GetDecimal("Balance")  // Pobieranie salda konta
                            });
                        }
                    }
                }
            }
            ClaimKontoBox.DataSource = konto;   // Ustawienie źródła danych dla ComboBox
            ClaimKontoBox.DisplayMember = null;   // Ustawienie, co ma być wyświetlane w ComboBox
        }

        
        private void AcceptTransfer_Click(object sender, EventArgs e)    // Obsługa kliknięcia przycisku akceptacji transferu
        {
            var mainAccount = ClaimKontoBox.SelectedItem as KontoInfo;  // Pobranie info o koncie
            if (mainAccount == null)    // Obsługa błędów, gdyby konto nie zostało wybrane
            { 
                MessageBox.Show("Wybierz konto główne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal kwota = BalanceAmount.Value;    // Pobranie wartości kwoty z kontrolki BalanceAmount
            if (kwota <= 0) // Sprawdzanie czy liczba jest większ od zera
            {
                MessageBox.Show("Kwota musi być większa od zera.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string title = TitleOption.SelectedItem?.ToString() ?? "Wypłata";   // Przypisanie tytułowi wpłaty wartości domyślnej w przypadku nie wydrania

            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();    // Otwarcie połączenia z bazą danych
                using (var trans = conn.BeginTransaction()) //Rozpoczęcie transakcji
                {
                    try
                    {
                        //Zapisywanie transakcji do tabeli transaction
                        string save = "INSERT INTO transactions (Amount, Date, Description, AccountId) VALUES (@amount, NOW(), @title, @accountId)";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(save, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@amount", kwota);  // Dodanie parametru kwoty
                            cmd.Parameters.AddWithValue("@title", title);   // Dodanie tytułu przelewu
                            cmd.Parameters.AddWithValue("@accountId", mainAccount.AccountId);   // Dodanie identyfikatorta konta głównego
                            cmd.ExecuteNonQuery();  // Wykonanie zapytania w celu zapisania przelewu
                        }

                        //Dodawanie srodków na konto główne użytkownika
                        string update = "UPDATE accounts SET Balance = Balance + @amount Where Id = @id";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(update, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@amount", kwota);  // Dodanie parametru kwoty przelewu
                            cmd.Parameters.AddWithValue("@id", mainAccount.AccountId);  // Dodanie identyfikator konta głównego użytkowniak
                            cmd.ExecuteNonQuery();  // Wykonanie zapytania w celu dokonania aktualizacji salda
                        }

                        // Przelewanie 10% transakcji na konto oszczednościowe
                        int? savingAccountId = null; // Inicjalizacja zmiennej dla konta oszczędnościowego;
                        string extra = "SELECT Id FROM accounts WHERE UserId = @UserId AND AccountType = 'Saving'";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(extra, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", _id); // Dodanie parametru identyfikujacego konto oszczednosiowe
                            var result = cmd.ExecuteScalar(); // Wykonanie zapytania i pobranie identyfikatora konta oszczędnościowego
                            if (result != null && result != DBNull.Value) // Sprawdzenie czy konto oszczędnościowe istnieje
                            {
                                savingAccountId = Convert.ToInt32(result); // Przypisanie identyfikatora konta oszczędnościowego
                            }
                        }

                        if (savingAccountId.HasValue) // Sprawdzenie czy konto oszczędnościowe istnieje
                        {
                            decimal savingAmount = Math.Round(kwota * 0.10m, 2); // Obliczanie kwoty z 10% od transakcji
                            if (savingAmount > 0)   // Sprawdzanie czy został obliczony jakiś procent
                            {
                                string updateSaving = "UPDATE accounts SET Balance = Balance + @amount WHERE Id = @Id"; // Zapytanie do bazy danych
                                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(updateSaving, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@amount", savingAmount);   // Dodanie parametru kwoty dodatniej do salda konta
                                    cmd.Parameters.AddWithValue("@Id", savingAccountId.Value);  // Dodanie parametry identyfikatowa konta oszczednosciowego
                                    cmd.ExecuteNonQuery (); // Wykonanie zapytania w celu aktualizacji konta
                                }
                                string saveSaving = "INSERT INTO transactions (Amount, Date, Description, AccountId) VALUES (@amount, NOW(), @title, @accountId)";
                                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(saveSaving, conn, trans))
                                {
                                    cmd.Parameters.AddWithValue("@amount", savingAmount);
                                    cmd.Parameters.AddWithValue("@title", "Autooszczedzanie 10%");
                                    cmd.Parameters.AddWithValue("@accountId", savingAccountId.Value);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        trans.Commit(); // Zatwierdzenie transakcji, jeśli wszystkie operacje zakończyły się pomyślnie
                        MessageBox.Show("Wpłata zakończona sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();    // Ukrycie formularza DepositCash po zakończeniu operacji
                        Main main = new Main(_id);  // Tworzenie nowego okna Main z identyfikatorem użytkownika
                        main.Show();    // Wyświetlenie okna Main
                        this.Close();   // Zakmnięte formularza TransferCash
                    }
                    catch (Exception ex)    // Obsługa wyjątów w przypadku błędów podczas przelewu
                    {
                        trans.Rollback();   // Wycofanie transakcji w przypadku błędu
                        MessageBox.Show("Błąd podczas wpłaty: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main(_id);
            main.Show();
            this.Close();
        }

        private void ClaimKontoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BalanceAmount_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TitleOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

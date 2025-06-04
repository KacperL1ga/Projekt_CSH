using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankApp
{
    public partial class TransferCash : Form
    {
        private int _id; // Identyfikator użytkownika, który będzie używany do operacji na koncie
        public TransferCash(int Id)
        {
            this.StartPosition = FormStartPosition.CenterScreen; // Ustawienie pozycji formularza na środku ekranu
            _id = Id;
            InitializeComponent();
            LoadUserAccounts(Id); // Ładowanie kont użytkownika na podstawie jego identyfikatora
            LoadOtherAccounts(Id); // Ładowanie kont innych użytkowników na podstawie identyfikatora
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
        
        private void LoadUserAccounts(int userId)   // Ładowanie kont zalogowanego użytkownika do SendKontoBox
        {
            var konta = new List<KontoInfo>();  // Lista do przechowywania informacji o kontach
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();    // Otwarcie połączenia z bazą danych
                string query = "SELECT Id, AccountType, AccountNumber, Balance FROM Accounts WHERE UserId = @UserId";   // Zapytanie SQL do pobrania kont użytkownika
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))  // Utworzenie polecenia SQL
                {
                    cmd.Parameters.AddWithValue("@UserId", userId); // Dodanie parametru do zapytania
                    using (var reader = cmd.ExecuteReader())    // Wykonanie zapytania i odczytanie wyników
                    {
                        while (reader.Read())   // Iteracja przez wyniki zapytania  
                        {
                            konta.Add(new KontoInfo // Dodanie informacji o koncie do listy
                            {
                                AccountId = reader.GetInt32("Id"),  // Pobranie identyfikatora konta
                                AccountType = reader.GetString("AccountType"),  // Pobranie typu konta
                                AccountNumber = reader.GetInt32("AccountNumber"),   // Pobranie numeru konta
                                Balance = reader.GetDecimal("Balance")  // Pobranie salda konta
                            });
                        }
                    }
                }
            }
            SendKontoBox.DataSource = konta;    // Ustawienie źródła danych dla SendKontoBox
            SendKontoBox.DisplayMember = "ToString";    // Ustawienie wyświetlanej wartości w SendKontoBox
        }

        private void LoadOtherAccounts(int userId)  // Ładowanie kont innych użytkowników do ClaimKontoBox
        {
            var konta = new List<KontoInfo>();  // Lista do przechowywania informacji o kontach
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();    // Otwarcie połączenia z bazą danych
                string query = "SELECT Id, AccountType, AccountNumber, Balance FROM Accounts WHERE UserId <> @UserId";  // Zapytanie SQL do pobrania kont innych użytkowników   
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))  // Utworzenie polecenia SQL
                {
                    cmd.Parameters.AddWithValue("@UserId", userId); // Dodanie parametru do zapytania
                    using (var reader = cmd.ExecuteReader())    // Wykonanie zapytania i odczytanie wyników
                    {
                        while (reader.Read())   // Iteracja przez wyniki zapytania
                        {
                            konta.Add(new KontoInfo // Dodanie informacji o koncie do listy
                            {
                                AccountId = reader.GetInt32("Id"),  // Pobranie identyfikatora konta
                                AccountType = reader.GetString("AccountType"),  // Pobranie typu konta
                                AccountNumber = reader.GetInt32("AccountNumber"),   // Pobranie numeru konta
                                Balance = reader.GetDecimal("Balance")  // Pobranie salda konta
                            }); 
                        }
                    }
                }
            }
            ClaimKontoBox.DataSource = konta;   // Ustawienie źródła danych dla ClaimKontoBox
            ClaimKontoBox.DisplayMember = "ToString";   // Ustawienie wyświetlanej wartości w ClaimKontoBox
            
        }
        private void AcceptTransfer_Click(object sender, EventArgs e)   // Obsługa kliknięcia przycisku akceptacji transferu
        {
            var senderAccount = SendKontoBox.SelectedItem as KontoInfo; // Pobranie wybranego konta nadawcy z SendKontoBox  
            var receiverAccount = ClaimKontoBox.SelectedItem as KontoInfo;  // Pobranie wybranego konta odbiorcy z ClaimKontoBox
            decimal kwota = BalanceAmount.Value;    // Pobranie wartości kwoty z kontrolki BalanceAmount
            string opis = DescriptionTransfer.Text.Trim();  // Pobranie opisu transferu z kontrolki DescriptionTransfer

            if (senderAccount == null)  // Sprawdzenie, czy konto nadawcy zostało wybrane
            {
                MessageBox.Show("Wybierz konto nadawcy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (receiverAccount == null)    // Sprawdzenie, czy konto odbiorcy zostało wybrane
            {
                MessageBox.Show("Wybierz konto odbiorcy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kwota <= 0) // Sprawdzenie, czy kwota jest większa od zera  
            {
                MessageBox.Show("Kwota musi być większa od zera.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (senderAccount.Balance < kwota)  // Sprawdzenie, czy saldo konta nadawcy jest wystarczające do wykonania transferu
            {
                MessageBox.Show("Brak wystarczających środków na koncie nadawcy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (senderAccount.AccountId == receiverAccount.AccountId)   // Sprawdzenie, czy konto nadawcy i odbiorcy są takie same
            {
                MessageBox.Show("Nie można przelać środków na to samo konto.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();    // Otwarcie połączenia z bazą danych
                using (var trans = conn.BeginTransaction()) // Rozpoczęcie transakcji
                {   
                    try
                    {
                        // Zapis transferu do bazy transfers
                        string insert = "INSERT INTO transfers (send_account, claim_account, amount, Title, transfer_date) VALUES (@sender, @receiver, @amount, @title, NOW())";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(insert, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@sender", senderAccount.AccountId);    // Dodanie identyfikatora konta nadawcy
                            cmd.Parameters.AddWithValue("@receiver", receiverAccount.AccountId);    // Dodanie identyfikatora konta odbiorcy
                            cmd.Parameters.AddWithValue("@amount", kwota);  // Dodanie kwoty transferu
                            cmd.Parameters.AddWithValue("@title", opis);    // Dodanie tytułu transferu
                            cmd.ExecuteNonQuery();  // Wykonanie zapytania w celu zapisania transferu
                        }

                        // Odejmowanie kwoty z konta nadawcy
                        string updateSender = "UPDATE accounts SET Balance = Balance - @amount WHERE Id = @id"; 
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(updateSender, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@amount", kwota);  // Dodanie kwoty do odjęcia
                            cmd.Parameters.AddWithValue("@id", senderAccount.AccountId);    // Dodanie identyfikatora konta nadawcy
                            cmd.ExecuteNonQuery();  // Wykonanie zapytania w celu aktualizacji salda konta nadawcy
                        }

                        // Dodawanie kwoty do konta odbiorcy
                        string updateReceiver = "UPDATE accounts SET Balance = Balance + @amount WHERE Id = @id";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(updateReceiver, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@amount", kwota);  // Dodanie kwoty do dodania
                            cmd.Parameters.AddWithValue("@id", receiverAccount.AccountId);  // Dodanie identyfikatora konta odbiorcy
                            cmd.ExecuteNonQuery();  // Wykonanie zapytania w celu aktualizacji salda konta odbiorcy
                        }

                        trans.Commit(); // Zatwierdzenie transakcji, jeśli wszystkie operacje zakończyły się pomyślnie
                        MessageBox.Show("Transfer zakończony sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); // Ukrycie formularza TransferCash po pomyślnym zakończeniu transferu
                        Main main = new Main(_id); // Tworzenie nowego obiektu Main z identyfikatorem użytkownika
                        main.Show(); // Wyświetlenie okna Main
                        this.Close();   // Zamknięcie formularza TransferCash po pomyślnym zakończeniu transferu
                    }
                    catch (Exception ex)    // Obsługa wyjątków w przypadku błędów podczas transferu    
                    {
                        trans.Rollback();   // Wycofanie transakcji w przypadku błędu
                        MessageBox.Show("Błąd podczas transferu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close(); // Zamknięcie formularza TransferCash i powrót do poprzedniego okna
            Main main = new Main(_id); // Tworzenie nowego obiektu Main z identyfikatorem użytkownika
            main.Show(); // Wyświetlenie okna Main
            this.Close(); // Zamknięcie bieżącego formularza   
        }

        private void BalanceAmount_ValueChanged(object sender, EventArgs e)
        {
        }

        private void DescriptionTransfer_TextChanged(object sender, EventArgs e)
        {

        }

        private void KontoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClaimKontoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}

using System;
using System.Windows.Forms;

namespace BankApp
{
    public partial class Main : Form
    {
        private int _id;

        public Main(int Id)
        {
            this.StartPosition = FormStartPosition.CenterScreen; // Ustawienie pozycji okna na środek ekranu
            _id = Id;
            InitializeComponent(); // Inicjalizacja komponentów okna głównego
            LoadMainAccountData(); // Wczytanie danych konta głównego
            LoadSavingAccountData(); // Wczytanie danych konta oszczędnościowego
            this.Activated += (sender, e) => // Obsługa zdarzenia aktywacji okna
            {
                LoadTransactionHistory("", ""); // Wczytanie historii transakcji
                LoadTransferHistory("",""); // Wczytanie historii przelewów
                LoadSavingAccountData(); // Wczytanie danych konta oszczędnościowego
            };
        }

        private void LoadMainAccountData()
        {
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();
                string query = "SELECT balance FROM accounts WHERE UserId = @id AND AccountType ='Main'"; // Zapytanie SQL do bazy o kwotę konta głownego
                
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _id); // Dodawanie parametru do zapytania
                    object result = cmd.ExecuteScalar(); // Wykonanie zapytania i odczytanie danych, pobranie pojedynczen wartosci (salda)
                    if (result != null && result != DBNull.Value) // Sprawdzenie czy wynik nie jest pusty
                    {
                        lblBalance.Text = $"{result} zł"; // Ustawienie tekstu przycisku z kwotą konta głównego
                    }
                    else
                    {
                        lblBalance.Text = "Brak danych lub 0zl"; // Ustawienie domyślnej wartości jeśli konto jest puste
                    }
                }
            }
        }

        private void LoadSavingAccountData()
        {
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();
                string query = "SELECT balance FROM accounts WHERE UserId = @id AND AccountType ='Saving'"; // Zapytanie SQL do bazy o kwotę konta głownego

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _id); // Dodawanie parametru do zapytania
                    object result = cmd.ExecuteScalar(); // Wykonanie zapytania i odczytanie danych, pobranie pojedynczen wartosci (salda)
                    if (result != null && result != DBNull.Value) // Sprawdzenie czy wynik nie jest pusty
                    {
                        lblBalance.Text = $"{result} zł"; // Ustawienie tekstu przycisku z kwotą konta głównego
                        SavingAccBtn.Enabled = false; // Wyłączenie przycisku konta oszczędnościowego, jeśli konto jest już aktywne
                        toolTip1.SetToolTip(SavingAccBtn, "Konto oszczędnościowe jest już aktywne"); // Ustawienie podpowiedzi dla przycisku konta oszczędnościowego
                    }
                    else
                    {
                        lblBalance.Text = "Brak danych lub 0zl"; // Ustawienie domyślnej wartości jeśli konto jest puste
                        SavingAccBtn.Enabled = true; // Włączenie przycisku konta oszczędnościowego, jeśli konto nie jest aktywne
                    }
                }
            }
        }

        private void LoadTransactionHistory(string amountFilter, string dateFilter) // Metoda do wczytywania historii transakcji
        {
            amountFilter = amountFilter.Trim(); // Usunięcie białych znaków z początku i końca filtru kwoty
            dateFilter = dateFilter.Trim(); // Usunięcie białych znaków z początku i końca filtru daty
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();
                string query = @"
                        SELECT 
                            a.AccountType AS 'Konto',
                            t.Description AS 'Opis',
                            t.Amount AS 'Kwota',
                            t.Date AS 'Data'
                        FROM transactions t
                        JOIN accounts a ON t.AccountId = a.Id
                        WHERE a.UserId = @id";

                if (!string.IsNullOrEmpty(amountFilter))
                {
                    query += " AND t.Amount = @amount";
                }
                if (!string.IsNullOrEmpty(dateFilter))
                {
                    query += " AND DATE(t.Date) = @date";
                }

                query += " ORDER BY t.Date DESC";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _id);

                    if (!string.IsNullOrEmpty(amountFilter))
                    {
                        cmd.Parameters.AddWithValue("@amount", decimal.Parse(amountFilter));
                    }
                    if (!string.IsNullOrEmpty(dateFilter))
                    {
                        cmd.Parameters.AddWithValue("@date", dateFilter);
                    }

                    var adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable); // Wypełnienie DataTable danymi z bazy

                    TransactionView.AutoGenerateColumns = true; // Automatyczne generowanie kolumn w DataGridView
                    TransactionView.DataSource = dataTable; // Ustawienie DataSource dla DataGridView
                }
            }
        }

        private void LoadTransferHistory(string amountFilter, string dateFilter) // Metoda do wczytywania historii przelewów
        {
            amountFilter = amountFilter.Trim(); // Usunięcie białych znaków z początku i końca filtru kwoty
            dateFilter = dateFilter.Trim(); // Usunięcie białych znaków z początku i końca filtru daty
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open();
                string query = @"
                        SELECT 
                            sender.Username AS 'Od',
                            receiver.Username AS 'Do',
                            tr.Title AS 'Tytuł',
                            tr.Amount AS 'Kwota',
                            tr.transfer_date AS 'Data'
                        FROM transfers tr
                        JOIN accounts sa ON tr.send_account = sa.Id
                        JOIN users sender ON sa.UserId = sender.Id
                        JOIN accounts ca ON tr.claim_account = ca.Id
                        JOIN users receiver ON ca.UserId = receiver.Id
                        WHERE (sa.UserId = @id OR ca.UserId = @id)";

                if (!string.IsNullOrEmpty(amountFilter))
                {
                    query += " AND tr.Amount = @amount";
                }
                if (!string.IsNullOrEmpty(dateFilter))
                {
                    query += " AND DATE(tr.transfer_date) = @date";
                }

                query += " ORDER BY tr.transfer_date DESC";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _id);

                    if (!string.IsNullOrEmpty(amountFilter))
                    {
                        cmd.Parameters.AddWithValue("@amount", decimal.Parse(amountFilter));
                    }
                    if (!string.IsNullOrEmpty(dateFilter))
                    {
                        cmd.Parameters.AddWithValue("@date", dateFilter);
                    }

                    var adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable); // Wypełnienie DataTable danymi z bazy
                    TransactionView.AutoGenerateColumns = true; // Automatyczne generowanie kolumn w DataGridView
                    TransferView.DataSource = dataTable; // Ustawienie DataSource dla DataGridView
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TransferBalance_Click(object sender, EventArgs e)
        {
            this.Hide();
            TransferCash transferCash = new TransferCash(_id);
            transferCash.Show();
            this.Close();
        }

        private void MoneyHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void MainAButton_Click(object sender, EventArgs e)
        {
            string amountFilter = AmountFiltr.Text.Trim(); // Pobranie wartości filtru kwoty
            string dateFilter = DateFiltr.Text.Trim(); // Pobranie wartości filtru daty
            LoadMainAccountData(); // Ponowne wczytanie danych konta głównego po kliknięciu przycisku
            MainAButton.BackColor = System.Drawing.Color.LightGreen; // Zmiana koloru przycisku na zielony po kliknięciu
            SavingAButton.BackColor = System.Drawing.Color.LightGray; // Przywrócenie koloru przycisku konta oszczędnościowego na szary
            LoadTransactionHistory(amountFilter, dateFilter); // Wczytanie historii transakcji po kliknięciu przycisku
            LoadTransferHistory(amountFilter,dateFilter); // Wczytanie historii przelewów po kliknięciu przycisku
        }

        private void SavingAButton_Click(object sender, EventArgs e)
        {
            string amountFilter = AmountFiltr.Text.Trim(); // Pobranie wartości filtru kwoty
            string dateFilter = DateFiltr.Text.Trim(); // Pobranie wartości filtru daty
            LoadSavingAccountData(); // Ponowne wczytanie danych konta oszczędnościowego po kliknięciu przycisku
            SavingAButton.BackColor = System.Drawing.Color.LightGreen; // Zmiana koloru przycisku na zielony po kliknięciu
            MainAButton.BackColor = System.Drawing.Color.LightGray; // Przywrócenie koloru przycisku konta głównego na szary
            LoadTransactionHistory(amountFilter, dateFilter); // Wczytanie historii transakcji po kliknięciu przycisku
            LoadTransferHistory(amountFilter, dateFilter); // Wczytanie historii przelewów po kliknięciu przycisku
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ukrycie okna głównego
            Logowanie loginForm = new Logowanie(); // Tworzenie nowego okna logowania
            loginForm.Show(); // Pokazanie okna logowania
            MessageBox.Show("Zostałeś wylogowany!"); // Informacja o wylogowaniu
            this.Close(); // Zamknięcie okna głównego
        }

        private void AddBalance_Click(object sender, EventArgs e)
        {
            this.Hide();
            DepositCash depositCash = new DepositCash(_id);
            depositCash.Show();
            this.Close();
        }

        private void WithdrawBalance_Click(object sender, EventArgs e)
        {
            this.Hide();
            WithdrawCash withdrawCash = new WithdrawCash(_id);
            withdrawCash.Show();
            this.Close();
        }

        private void SavingAccBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SavingKonto savingKonto = new SavingKonto(_id);
            savingKonto.Show(); 
            this.Close();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void FiltrBtn_Click(object sender, EventArgs e)
        {
            string amountFilter = AmountFiltr.Text.Trim(); // Pobranie wartości filtru kwoty
            string dateFilter = DateFiltr.Text.Trim(); // Pobranie wartości filtru daty

            if (!string.IsNullOrEmpty(dateFilter) && !DateTime.TryParse(dateFilter, out _)) // Sprawdzenie poprawności formatu daty
            {
                MessageBox.Show("Nieprawidłowy format daty. Użyj formatu RRRR-MM-DD."); // Komunikat o błędzie formatu daty
                return; // Zakończenie działania metody, jeśli format daty jest niepoprawny
            }
            LoadTransactionHistory(amountFilter, dateFilter);
            LoadTransferHistory(amountFilter, dateFilter);
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            AmountFiltr.Text = "";
            DateFiltr.Text = "";
            LoadTransactionHistory("", "");
            LoadTransferHistory("", "");
        }

        private void AmountFiltr_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateFiltr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

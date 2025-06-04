using MySql.Data.MySqlClient;
using System;

namespace BankApp
{
    public static class DataBaseBankSeeder
    {
        public static void Seed()
        {
            using (var conn = DatabaseContex.GetConnection())
            {
                conn.Open(); // Otwieramy połączenie z bazą danych

                try
                {
                    SeedUsers(conn); // Metoda do seedowania użytkowników

                    SeedAccounts(conn); // Metoda do seedowania kont użytkowników

                    SeedTransactions(conn); // Metoda do seedowania transakcji  

                    Console.WriteLine("Database seeded zaimplementowany!.");
                }
                catch (Exception ex) // Obsługa wyjątków, jeśli coś pójdzie nie tak
                {
                    Console.WriteLine($"Błąd podczas implementacaji seedera bazy danych: {ex.Message}");
                }
            }
        }
        private static void SeedUsers(MySqlConnection conn) // Metoda do seedowania użytkowników
        {
            // Zapytanie SQL do wstawienia użytkowników do tabeli Users
            string query = @"   
            INSERT INTO Users (Username, Password) 
                VALUES 
                ('user1', 'psswd1'), -- hasło: psswrd1
                ('user2', 'psswd2'); -- hasło: psswrd1";

            new MySqlCommand(query, conn).ExecuteNonQuery(); // Wykonujemy zapytanie SQL
        }

        private static void SeedAccounts(MySqlConnection conn) // Metoda do seedowania kont użytkowników
        {
            // Zapytanie SQL do wstawienia kont użytkowników do tabeli Accounts
            string query = @"
            INSERT INTO Accounts (AccountNumber, Balance, AccountType, UserId) 
                VALUES
                ('12345', 1500.00, 'Main', 1),
                ('56789', 5000.00, 'Saving', 1),
                ('11223', 3000.00, 'Main', 2),
                ('33445', 2000.00, 'Saving', 2)";

            new MySqlCommand(query, conn).ExecuteNonQuery(); // Wykonujemy zapytanie SQL
        }

        private static void SeedTransactions(MySqlConnection conn) // Metoda do seedowania transakcji
        {
            // Zapytanie SQL do wstawienia transakcji do tabeli Transactions
            string query = @"
            INSERT INTO Transactions (Amount, Date, Description, AccountId) 
                VALUES
                (100.00, '2023-01-01', 'Wplata', 1),
                (50.00, '2023-01-02', 'Wyplata z bankomatu', 1)";
            new MySqlCommand(query, conn).ExecuteNonQuery(); // Wykonujemy zapytanie SQL
        }
    }
}

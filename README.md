# BankApp - Aplikacja Bankowa

Aplikacja bankowa napisana w C# przy użyciu Windows Forms i Entity Framework z bazą danych MySQL.

## 📋 Spis treści

- [Opis projektu](#opis-projektu)
- [Funkcjonalności](#funkcjonalności)
- [Wymagania techniczne](#wymagania-techniczne)
- [Instalacja](#instalacja)
- [Konfiguracja bazy danych](#konfiguracja-bazy-danych)
- [Uruchomienie](#uruchomienie)
- [Użytkowanie](#użytkowanie)
- [Autor](#autor)
- [Uwagi techniczne](#uwagi-techniczne)


## 🏦 Opis projektu

BankApp to aplikacja desktopowa symulująca podstawowe operacje bankowe. Umożliwia tworzenie kont użytkowników, otwieranie kont oszczędnościowych, wykonywanie transakcji finansowych oraz monitorowanie historii operacji.

## ✨ Funkcjonalności

### Zarządzanie użytkownikami
- **Rejestracja** - tworzenie nowego użytkownika z kontem głównym
- **Logowanie** - autoryzacja użytkownika
- **Generowanie numerów kont** - automatyczne generowanie unikalnych numerów

### Zarządzanie kontami
- **Konto główne (Main)** - podstawowe konto użytkownika
- **Konto oszczędnościowe (Saving)** - dodatkowe konto z automatycznym oszczędzaniem
- **Otwieranie konta oszczednościowego** - zakładanie konta dla oszczedności
- **Wyświetlanie salda** - podgląd aktualnego stanu konta

### Operacje finansowe
- **Wpłaty** - dodawanie środków na konto
- **Wypłaty** - pobieranie środków z konta lub bankomatu
- **Przelewy** - transfery między użytkownikami
- **Autooszczędzanie** - automatyczne przekazywanie 10% wpłat na konto oszczędnościowe

### Historia i monitoring
- **Historia transakcji** - wszystkie wpłaty i wypłaty
- **Historia przelewów** - transfery między kontami
- **Podział na karty** - przejrzysta prezentacja danych

## 🔧 Wymagania techniczne

### Środowisko
- **.NET Framework 4.8**
- **Visual Studio 2017** lub nowszy
- **MySQL Server** (lokalny lub zdalny)

### Pakiety NuGet
```xml
- MySql.Data (9.3.0)
- Microsoft.EntityFrameworkCore (3.1.32)
- System.Configuration.ConfigurationManager (8.0.0)
- BouncyCastle.Cryptography (2.5.1)
```

## 📦 Instalacja

### 1. Klonowanie repozytorium
```bash
git clone https://github.com/KacperL1ga/Projekt_CSH.git
cd Projekt_CSH
```

### 2. Przywracanie pakietów
```bash
# W Visual Studio
Tools -> NuGet Package Manager -> Package Manager Console
Update-Package
```

### 3. Konfiguracja połączenia z bazą danych
Edytuj plik `App.config` dodając poniższą składnie wewnątrz <configuration>:
```xml
<connectionStrings>
    <add name="BankAppConnection"
         connectionString="server=localhost;port=3306;database=bankapp;user id=root;password=;SslMode=None;"
         providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```

## 🗄️ Konfiguracja bazy danych

### 1. Utworzenie bazy danych
Wykonaj skrypt SQL z pliku `DatabaseBank.sql` (testowanie na MySql) w celu zaimplementowania tabel niezbętnych do działania programu:

```sql
CREATE DATABASE BankApp;
USE BankApp;

-- Tabela użytkowników
CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL
);

-- Tabela kont
CREATE TABLE Accounts (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    AccountNumber VARCHAR(5) NOT NULL UNIQUE,
    Balance DECIMAL(10,2) NOT NULL,
    AccountType ENUM('Main', 'Saving') NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Tabela transakcji
CREATE TABLE Transactions (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Amount DECIMAL(10,2) NOT NULL,
    Date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Description VARCHAR(100),
    AccountId INT NOT NULL,
    FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
);

-- Tabela transferów
CREATE TABLE transfers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    send_account INT NOT NULL,
    claim_account INT NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    Title VARCHAR(100) NOT NULL,
    transfer_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (send_account) REFERENCES Accounts(id),
    FOREIGN KEY (claim_account) REFERENCES Accounts(id)
);
```

### 2. Inicjalizacja danych testowych (opcjonalne)
W pliku `Program.cs` odkomentuj linię (jeśli jest zakomentowana:
```csharp
DataBaseBankSeeder.Seed(); // Usuń komentarz przy pierwszym uruchomieniu
```
**Ważne! - po pierwszym wywołaniu programu konieczne jest ponowne zakomentowanie powyższej linijki w celu nienadpisywania kont i danych z seedera!**

## 🚀 Uruchomienie

1. **Upewnij się, że MySQL jest uruchomiony**
2. **Skonfiguruj połączenie w App.config**
3. **Uruchom aplikację w Visual Studio (F5)**
4. **Przy pierwszym uruchomieniu** - odkomentuj seeder w Program.cs

## 👥 Użytkowanie

### Pierwsze kroki
1. **Uruchom aplikację**
2. **Zarejestruj nowego użytkownika** - możliwość zakładania nowych kont w banku
   
   ![image](https://github.com/user-attachments/assets/b7e4a597-1e8f-4f3d-994e-ac907f1c8f5a)

Rejestracja kont nie należy do skomplikowanych, nowy klient proszony jest o podanie nazwy użytkownika, hasła do konta oraz wygenrowania dla swojego głównego konta unikalnego numeru. Jeśli program napotka po drodze rejestracji błędy, zostaną one przedstawione w komunikatach.

**Logowanie zarejestrowanych użytkowników**:
   - Login: `user1`, Hasło: `psswd1`
   - Login: `user2`, Hasło: `psswd2`

![image](https://github.com/user-attachments/assets/5f6ef899-1a09-42ce-aa72-1a78dfccb6d3)

Po wprowadzeniu jednej z dwóch opcji logowania, program powiadomi nas o pomyślnym zalogowaniu i uruchomi panel główny lub przedstawi w czym tkwi problem uniemożliwiający zalogowanie do banku.

### Operacje podstawowe
1. **Przełączanie między kontami** - przyciski "Konto główne" / "Konto oszczędnościowe"
   
   ![image](https://github.com/user-attachments/assets/d07e5a65-8758-4660-9bfb-c99b866c84b7)

   Pozwalają one na podgląd aktualnego salda zaznaczonego konta, aktualizowanego po każdej operacji na nim przeprowadzonej. Po prawej stronie znajduje się również przycisk odpowiadający za otwarcie konta oszczędnościowego w sytuacji gdy użytkownik jeszcze go nie posiada. Po założeniu przycisk jest niemożliwy do użycia.

2. **Otwarcie konta oszczędnościowego**  - przycisk "Dodaj konto oszczednościowe"
 
    ![image](https://github.com/user-attachments/assets/dc8f028f-409c-4a8e-8959-bb9e9dff8d6b)
   
    Nowo zarejestrowani i zalogowani użytkownicy mają możliwość założenia sobie konta oszczednościowego poprzez odpowieni, przycisk na panelu głównym. Zostaną przeniesieni na specjalny panel w którym będą w stanie wygenerować sobie numer danego konta, potwierdzony komunikatem. Od tej chwili aktywuje się również autooszczedzanie i możliwość podglądu stanu salda na nowym kocie.

5. **Wpłata środków** - przycisk "Wpłata środków" - przekierowuje do formularza wpłaty pieniędzy
   
   ![image](https://github.com/user-attachments/assets/b081bdc6-e286-4739-be72-daf79baabb28)

   Formularz ten pozwala nam na wpłacenie określonej kwoty na konto główne z podanie z jakiego źródła otrzymaliśmy wpłatę (wpłata, wpłata w bankomacie). Dodanie pieniędzy na konto główne uruchamia system autooszczedzania dodający 10% od wpłaty do konta oszczędnościowego.
    
6. **Wypłata środków** - przycisk "Wypłata środków" - przekierowuje do formularza wypłaty pieniędzy
   
   ![image](https://github.com/user-attachments/assets/26a56170-da75-49f5-ba61-9fb64999b1de) ![image](https://github.com/user-attachments/assets/c085e310-e427-43f4-8868-a718ec4af74b)
   
   Formularz wypłat działa bardzo podobnie co system wpłat. Tutaj pozbywamy się pieniędzy z konta. W sytuacji gdy wybierzemy konto oszczednościowe, jako to z którego chcemy wypłacić pieniądze, pojawia nam się opcja z kontem głównym. Wypłacanie oszczędności jest możliwe tylko na konto główne. W tym przypadku również możemy wybrać rodzaj transakcji oraz ilość gotówki jaką chcemy wypłacić.

7. **Przelewy** - przycisk "Przelew" - przekierowuje do formularza wykonywania przelewów między kontami
   ![image](https://github.com/user-attachments/assets/9524e87b-c764-4792-8827-802784f7b643)

   Formularz przelewów zajmuje się wykonywaniem przelewów pomiędzy kontami użytkowników. Ich wybór jest możliwy w dwóch pierwszych OptionBox'ach. W opcjach widoczne są konta zapisane jako "Typ konta", "Numer konta", "Balans". Idąc dalej należy wpisać kwotę przelewu oraz tytuł/opis.
   
8. **Historia** - karty "Przelewy" i "Transakcje" - przedstawia ostatnie działania na koncie
    ![image](https://github.com/user-attachments/assets/845b2ac9-993d-4d0f-8dfa-3a85a3377e16)

   Ten fragment panelu głównego odpowiada za wyświetlanie wszystkcich operacji na koncie, czyli modyfikacji sald kont użytkownika. W sytuscji gdy wpłacimy/wypłacimy pieniądze lub wykonamy przelew zostanie on zarejestrowany na kartach historii działań na koncie, wraz z szczegółami transakcji.

    ![image](https://github.com/user-attachments/assets/39389fab-1571-4558-af01-1e3bd042591b)
   Zaimplementowane zostało również filtrowanie przelewów oraz transakcji na podstawie podanej daty lub kwoty przelewu. Użytkownik może wyświetlić operacje tylko z podanymi kryteriami po użyciu przycisku "Filtruj". Jest też opcja wyczyszczenia wyników poprzez "Resetuj" co przywróci pierwotny stan historii.

### Funkcje specjalne
- **Autooszczędzanie** - 10% każdej wpłaty trafia na konto oszczędnościowe
- **Wypłata z konta oszczędnościowego** - środki trafiają na konto główne
- **Generowanie numerów kont** - automatyczne przy rejestracji
- **Wyświetlanie historii działań na kocie** - automatyczna aktualizacja historii po powrocie do panelu głównego

## 👨‍💻 Autor

- **KacperL1ga** - [GitHub](https://github.com/KacperL1ga)

## 🔍 Uwagi techniczne

- **Walidacja danych** - wszystkie formularze zawierają walidację
- **Bezpieczeństwo** - hasła przechowywane w plain text (tylko do celów edukacyjnych)
- **Baza danych** - MySQL z automatycznym generowaniem ID

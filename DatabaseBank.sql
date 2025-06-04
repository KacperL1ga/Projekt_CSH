CREATE DATABASE BankApp;
USE BankApp;

-- Tabela użytkowników (logowanie)
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

-- Tabela transferow
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

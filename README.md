# cloudyLib

## 1. Opis aplikacji

`cloudyLib` to aplikacja okienkowa w technologii C# służąca do zarządzania biblioteką. System umożliwia użytkownikom (czytelnikom) przeglądanie, wyszukiwanie, wypożyczanie i zwracanie książek, a także zarządzanie ich danymi kontaktowymi. Aplikacja wyróżnia dwie główne role: Administratora i Czytelnika, z różnymi poziomami uprawnień. Baza danych aplikacji jest zbudowana na platformie Docker, wykorzystując PostgreSQL jako system zarządzania bazą danych. System wykorzystuje ORM Entity Framework Core.

### Główne funkcjonalności:

* **Role użytkowników**: System posiada dwie role: Administrator i Czytelnik.
* **Funkcjonalności Administratora**:
    * Dodawanie, edytowanie i usuwanie książek z walidacją (czy książka nie jest aktualnie wypożyczona).
    * Przypisywanie autorów i gatunków do książek.
    * Przeglądanie listy aktywnych wypożyczeń i recenzji.
    * Zarządzanie użytkownikami.
* **Funkcjonalności Czytelnika**:
    * Przeglądanie dostępnych książek.
    * Filtrowanie książek według tytułu i gatunku.
    * Możliwość oceny książki (skala 1–5 gwiazdek).
    * Dodawanie krótkiej recenzji tekstowej.
    * Możliwość sortowania wyników (np. najnowsze, najpopularniejsze).
    * Wypożyczanie książek (o ile jest dostępna, z zapisem daty wypożyczenia i planowanej daty zwrotu). Walidacja – brak możliwości wypożyczenia książki, jeśli jest niedostępna.
    * Przeglądanie historii swoich wypożyczeń.
    * Edytowanie swoich danych kontaktowych.
* **Inne funkcje**:
    * Automatyczne oznaczanie książek jako „Nowość” (na podstawie daty dodania).
    * Oznaczenie książek jako „Popularne” (na podstawie liczby wypożyczeń).
    * Rejestracja i logowanie z bezpiecznym haszowaniem haseł.
    * Walidacja danych użytkownika (e-mail unikalny i poprawny format, telefon min. 9 cyfr).
    * Formularze z odpowiednimi typami pól (data, dropdown, checkbox).
    * Obsługa ról i autoryzacji.
    * Możliwość zmiany połączenia do bazy w czasie działania (np. przez UI).
    * Seedowanie przykładowych danych (książki, użytkownicy, wypożyczenia).
    * Migracje bazy danych (automatyczne tworzenie schematu).

## 2. Opis bazy danych

Aplikacja `cloudyLib` wykorzystuje relacyjną bazę danych **PostgreSQL**, zarządzaną za pośrednictwem **Entity Framework Core**. Struktura bazy danych jest zdefiniowana przez modele C# i migracje.

### Modele (tabele) w bazie danych:

* **`Author`**: Przechowuje informacje o autorach książek.
* **`Book`**: Przechowuje szczegóły dotyczące książek (tytuł, ISBN, liczba dostępnych kopii, rok wydania, data dodania).
* **`BookAuthor`**: Tabela łącząca wiele-do-wielu pomiędzy `Book` i `Author`, umożliwiająca przypisanie wielu autorów do jednej książki i jednego autora do wielu książek.
* **`BookGenre`**: Tabela łącząca wiele-do-wielu pomiędzy `Book` i `Genre`, umożliwiająca przypisanie wielu gatunków do jednej książki i jednego gatunku do wielu książek.
* **`BookLoan`**: Przechowuje informacje o wypożyczeniach książek (data wypożyczenia, planowana data zwrotu, faktyczna data zwrotu).
* **`Genre`**: Przechowuje listę gatunków książek.
* **`Rate`**: Przechowuje oceny książek wystawione przez użytkowników (skala 1-5 gwiazdek).
* **`Review`**: Przechowuje recenzje tekstowe książek dodane przez użytkowników.
* **`User`**: Przechowuje informacje o użytkownikach systemu (imię, nazwisko, email, numer telefonu, hasło, rola).

#### Diagram ERD
![diagramERD-C#](https://github.com/user-attachments/assets/efd8dc70-bd8d-4dfe-9314-1bdc6c503698)


### Konfiguracja połączenia z bazą danych:

Połączenie z bazą danych jest zdefiniowane w pliku `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=librarydb;Username=postgres;Password=admin123;"
  }
}
```
### Seedowanie danych:
Początkowe dane do bazy danych są seedowane bezpośrednio w metodzie SeedData() klasy LibraryDbContext.cs. Metoda ta dodaje przykładowych użytkowników (w tym administratora z hasłem **AdminPassword!1** \ i czytelników), autorów, gatunki, książki, powiązania książek z autorami i gatunkami, recenzje, oceny oraz fikcyjne wypożyczenia. Hasła użytkowników są bezpiecznie haszowane przy użyciu BCrypt.Net.


## 3. Konfiguracja i uruchomienie aplikacji
Aplikacja jest projektem C# WinForms, który wymaga środowiska .NET 9.0 i Visual Studio 2022. Baza danych PostgreSQL jest uruchamiana w kontenerach Docker.

### Wymagania wstępne:
* Docker Desktop: Należy mieć zainstalowany i uruchomiony Docker Desktop.
* Visual Studio 2022: Środowisko deweloperskie Visual Studio 2022.
* .NET 9.0 SDK: Zapewnia środowisko uruchomieniowe i narzędzia do kompilacji projektu.

### Kroki uruchomienia:
1. Przejdź do katalogu głównego projektu, gdzie znajduje się plik `docker-compose.yml`.
2. Otwórz terminal i wykonaj komendę, aby zbudować i uruchomić kontenery:
```bash
docker-compose up -d
```
Ta komenda uruchomi dwa serwisy:
 - **postgres**: Kontener z bazą danych PostgreSQL dostępny na porcie 5432. Nazwa bazy danych to librarydb, użytkownik postgres, hasło admin123.
 - **pgadmin**: Narzędzie do zarządzania bazami danych PostgreSQL, dostępne pod adresem `http://localhost:5050`. Domyślne dane logowania to e-mail: admin@example.com i hasło: admin123.
Jeśli kontenery już istnieją i chcesz je odbudować, użyj:
```bash
docker-compose up -d --build
```

3. Otworzenie projektu w Visual Studio:
Otwórz plik rozwiązania `cloudyLib.sln` w Visual Studio 2022.
4. Zastosowanie migracji bazy danych:
Aplikacja wykorzystuje Entity Framework Core Migrations. Aby upewnić się, że schemat bazy danych jest aktualny i zgodny z modelami, wykonaj następujące kroki w konsoli Menedżera Pakietów (Package Manager Console) w Visual Studio:
```PowerShell
Update-Database
```
Ta komenda zastosuje wszelkie oczekujące migracje do bazy danych librarydb w kontenerze PostgreSQL.
5. Uruchomienie aplikacji:
Po zastosowaniu migracji i upewnieniu się, że kontenery Docker są uruchomione, możesz uruchomić aplikację z poziomu Visual Studio, naciskając klawisz F5 lub klikając przycisk "Start".

#### Konfiguracja połączenia z bazą danych w trakcie działania:
Aplikacja posiada również funkcjonalność umożliwiającą zmianę połączenia z bazą danych w czasie działania, prawdopodobnie poprzez interfejs użytkownika, co pozwala na elastyczną adaptację do różnych środowisk bazodanowych bez konieczności modyfikacji kodu.

## 4.Przykładowe dane logowania (z seeder'a)
Po pierwszym uruchomieniu i zastosowaniu migracji, baza danych zostanie wypełniona przykładowymi danymi:

* **Administrator:**
    * Email: admin@cloudylib.com
    * Hasło: AdminPassword!1
* **Czytelnik (przykładowy)**:
    * Email: bartek@example.com
    * Hasło: Czytelnik1!.

## 5. Technologie
* **Język Programowania**: C#
* **Framework Aplikacji**: .NET 9.0 (WinForms)
* **Baza Danych**: PostgreSQL
* **ORM**: Entity Framework Core 9.0.5
* **Konteneryzacja**: Docker
* **Haszowanie haseł**: BCrypt.Net
* **Generowanie danych testowych (seedowanie)**: Bogus

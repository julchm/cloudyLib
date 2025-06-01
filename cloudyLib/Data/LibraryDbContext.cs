using Microsoft.EntityFrameworkCore;
using cloudyLib.Models;
using Bogus;
using BCrypt.Net;

namespace cloudyLib.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            // BookAuthor - composite key
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId }); 

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId); 

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId); 

            // BookGenre - composite key
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId }); 

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId); 

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId); 

            // Rate - composite key
            modelBuilder.Entity<Rate>()
                .HasKey(r => new { r.UserId, r.BookId }); 

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rates)
                .HasForeignKey(r => r.UserId); 

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Rates)
                .HasForeignKey(r => r.BookId); 

            // Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId); 

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId); 

            // BookLoan
            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.BookLoans)
                .HasForeignKey(bl => bl.BookId); 

            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.User)
                .WithMany(u => u.BookLoans)
                .HasForeignKey(bl => bl.UserId); 


            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public void SeedData()
        {
            if (Users.Any() || Books.Any() || Authors.Any() || Genres.Any())
            {
                Console.WriteLine("Database already contains data. Skipping seeding.");
                return;
            }

            Console.WriteLine("Seeding initial data with predefined values (with hashed passwords)...");

            // 1. Użytkownicy 
            var user1_admin = new User
            {
                FirstName = "Anna",
                LastName = "Administrator",
                Email = "admin@cloudylib.com",
                PhoneNumber = "111222333",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("AdminPassword!1"), 
                Role = "Administrator"
            };
            var user2 = new User { FirstName = "Bartek", LastName = "Czytelnik", Email = "bartek@example.com", PhoneNumber = "222333444", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Czytelnik1!"), Role = "Reader" };
            var user3 = new User { FirstName = "Celina", LastName = "Ksiazkowska", Email = "celina@example.com", PhoneNumber = "333444555", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Czytelnik2!"), Role = "Reader" };
            var user4 = new User { FirstName = "Damian", LastName = "Literat", Email = "damian@example.com", PhoneNumber = "444555666", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Czytelnik3!"), Role = "Reader" };
            var user5 = new User { FirstName = "Ewa", LastName = "Molksiazkowy", Email = "ewa@example.com", PhoneNumber = "555666777", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Czytelnik4!"), Role = "Reader" };
            var user6 = new User { FirstName = "Filip", LastName = "Bibliofil", Email = "filip@example.com", PhoneNumber = "666777888", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Czytelnik5!"), Role = "Reader" };
            var user7 = new User { FirstName = "Grażyna", LastName = "Zaczytana", Email = "grazyna@example.com", PhoneNumber = "777888999", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Czytelnik6!"), Role = "Reader" };
            var user8 = new User { FirstName = "Hubert", LastName = "Obejrzany", Email = "hubert@example.com", PhoneNumber = "888999000", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Czytelnik7!"), Role = "Reader" };

            Users.AddRange(user1_admin, user2, user3, user4, user5, user6, user7, user8);
            SaveChanges(); 


            // 2. Autorzy 
            var author1 = new Author { FirstName = "Henryk", LastName = "Sienkiewicz" };
            var author2 = new Author { FirstName = "Adam", LastName = "Mickiewicz" };
            var author3 = new Author { FirstName = "Olga", LastName = "Tokarczuk" };
            var author4 = new Author { FirstName = "Stephen", LastName = "King" };
            var author5 = new Author { FirstName = "Joanna", LastName = "Chmielewska" };
            var author6 = new Author { FirstName = "Terry", LastName = "Pratchett" };
            var author7 = new Author { FirstName = "J.R.R.", LastName = "Tolkien" };
            var author8 = new Author { FirstName = "Agatha", LastName = "Christie" };
            var author9 = new Author { FirstName = "Juliusz", LastName = "Verne" };
            var author10 = new Author { FirstName = "Stanisław", LastName = "Lem" };
            var author11 = new Author { FirstName = "George", LastName = "Orwell" };
            var author12 = new Author { FirstName = "Jane", LastName = "Austen" };
            var author13 = new Author { FirstName = "Gabriel Garcia", LastName = "Marquez" };
            var author14 = new Author { FirstName = "Ursula K.", LastName = "Le Guin" };
            var author15 = new Author { FirstName = "Wisława", LastName = "Szymborska" };

            Authors.AddRange(author1, author2, author3, author4, author5, author6, author7, author8, author9, author10, author11, author12, author13, author14, author15);
            SaveChanges(); 

            // 3. Gatunki 
            var genre1 = new Genre { Name = "Powieść historyczna" };
            var genre2 = new Genre { Name = "Epika" };
            var genre3 = new Genre { Name = "Fantasy" };
            var genre4 = new Genre { Name = "Horror" };
            var genre5 = new Genre { Name = "Kryminał" };
            var genre6 = new Genre { Name = "Science Fiction" };
            var genre7 = new Genre { Name = "Literatura piękna" };

            Genres.AddRange(genre1, genre2, genre3, genre4, genre5, genre6, genre7);
            SaveChanges(); 

            // 4. Książki 
            var book1 = new Book { Title = "Quo Vadis", ISBN = "978-83-731-9003-2", AvailableCopies = 3, YearOfRelease = 1896, DateAdded = DateTime.UtcNow.AddYears(-2) };
            var book2 = new Book { Title = "Pan Tadeusz", ISBN = "978-83-893-7910-0", AvailableCopies = 2, YearOfRelease = 1834, DateAdded = DateTime.UtcNow.AddYears(-1) };
            var book3 = new Book { Title = "Księgi Jakubowe", ISBN = "978-83-080-6000-0", AvailableCopies = 1, YearOfRelease = 2014, DateAdded = DateTime.UtcNow.AddDays(-100) };
            var book4 = new Book { Title = "IT", ISBN = "978-83-820-2500-0", AvailableCopies = 4, YearOfRelease = 1986, DateAdded = DateTime.UtcNow.AddDays(-50)};
            var book5 = new Book { Title = "Lalka", ISBN = "978-83-732-7000-1", AvailableCopies = 2, YearOfRelease = 1890, DateAdded = DateTime.UtcNow.AddDays(-40)};
            var book6 = new Book { Title = "Mały Książę", ISBN = "978-83-811-0000-1", AvailableCopies = 5, YearOfRelease = 1943, DateAdded = DateTime.UtcNow.AddDays(-30)};
            var book7 = new Book { Title = "Władca Pierścieni", ISBN = "978-83-240-0000-1", AvailableCopies = 3, YearOfRelease = 1954, DateAdded = DateTime.UtcNow.AddDays(-20) };
            var book8 = new Book { Title = "Zbrodnia i kara", ISBN = "978-83-080-0000-1", AvailableCopies = 2, YearOfRelease = 1866, DateAdded = DateTime.UtcNow.AddDays(-15) };
            var book9 = new Book { Title = "Paragraf 22", ISBN = "978-83-800-0000-1", AvailableCopies = 1, YearOfRelease = 1961, DateAdded = DateTime.UtcNow.AddDays(-10) };
            var book10 = new Book { Title = "Dziady", ISBN = "978-83-080-0001-1", AvailableCopies = 2, YearOfRelease = 1823, DateAdded = DateTime.UtcNow.AddDays(-5) };
            var book11 = new Book { Title = "W pustyni i w puszczy", ISBN = "978-83-731-9004-9", AvailableCopies = 4, YearOfRelease = 1911, DateAdded = DateTime.UtcNow.AddDays(-3)};
            var book12 = new Book { Title = "Nieznośna lekkość bytu", ISBN = "978-83-080-6001-7", AvailableCopies = 1, YearOfRelease = 1984, DateAdded = DateTime.UtcNow.AddDays(-2) };
            var book13 = new Book { Title = "Diuna", ISBN = "978-83-731-0001-7", AvailableCopies = 3, YearOfRelease = 1965, DateAdded = DateTime.UtcNow.AddDays(-1) };
            var book14 = new Book { Title = "Blade Runner", ISBN = "978-83-080-6002-4", AvailableCopies = 2, YearOfRelease = 1968, DateAdded = DateTime.UtcNow.AddHours(-12) };
            var book15 = new Book { Title = "Solaris", ISBN = "978-83-080-0003-5", AvailableCopies = 2, YearOfRelease = 1961, DateAdded = DateTime.UtcNow.AddHours(-6) };
            var book16 = new Book { Title = "Rok 1984", ISBN = "978-83-287-0001-1", AvailableCopies = 3, YearOfRelease = 1949, DateAdded = DateTime.UtcNow.AddHours(-3) };
            var book17 = new Book { Title = "Duma i uprzedzenie", ISBN = "978-83-731-0002-4", AvailableCopies = 2, YearOfRelease = 1813, DateAdded = DateTime.UtcNow.AddHours(-1) };
            var book18 = new Book { Title = "Sto lat samotności", ISBN = "978-83-287-0002-8", AvailableCopies = 1, YearOfRelease = 1967, DateAdded = DateTime.UtcNow.AddMinutes(-30)};
            var book19 = new Book { Title = "Lewa ręka ciemności", ISBN = "978-83-287-0003-5", AvailableCopies = 2, YearOfRelease = 1969, DateAdded = DateTime.UtcNow.AddMinutes(-10) };
            var book20 = new Book { Title = "Pamięć absolutna", ISBN = "978-83-800-0001-8", AvailableCopies = 1, YearOfRelease = 2011, DateAdded = DateTime.UtcNow.AddMinutes(-5)};

            Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14, book15, book16, book17, book18, book19, book20);
            SaveChanges(); 

            // 5. BookAuthor 
            var bookAuthors = new List<BookAuthor>
            {
                new BookAuthor { BookId = book1.BookId, AuthorId = author1.AuthorId }, // Quo Vadis - Sienkiewicz
                new BookAuthor { BookId = book2.BookId, AuthorId = author2.AuthorId }, // Pan Tadeusz - Mickiewicz
                new BookAuthor { BookId = book3.BookId, AuthorId = author3.AuthorId }, // Księgi Jakubowe - Tokarczuk
                new BookAuthor { BookId = book4.BookId, AuthorId = author4.AuthorId }, // IT - King
                new BookAuthor { BookId = book5.BookId, AuthorId = author1.AuthorId }, // Lalka - Sienkiewicz
                new BookAuthor { BookId = book6.BookId, AuthorId = author6.AuthorId }, // Mały Książę - Pratchett (przykładowo)
                new BookAuthor { BookId = book7.BookId, AuthorId = author7.AuthorId }, // Władca Pierścieni - Tolkien
                new BookAuthor { BookId = book8.BookId, AuthorId = author1.AuthorId }, // Zbrodnia i kara - Sienkiewicz (przykładowo)
                new BookAuthor { BookId = book9.BookId, AuthorId = author5.AuthorId }, // Paragraf 22 - Chmielewska (przykładowo)
                new BookAuthor { BookId = book10.BookId, AuthorId = author2.AuthorId }, // Dziady - Mickiewicz
                new BookAuthor { BookId = book11.BookId, AuthorId = author1.AuthorId }, // W pustyni i w puszczy - Sienkiewicz
                new BookAuthor { BookId = book12.BookId, AuthorId = author3.AuthorId }, // Nieznośna lekkość bytu - Tokarczuk (przykładowo)
                new BookAuthor { BookId = book13.BookId, AuthorId = author6.AuthorId }, // Diuna - Pratchett (przykładowo)
                new BookAuthor { BookId = book14.BookId, AuthorId = author10.AuthorId },// Blade Runner - Lem (przykładowo)
                new BookAuthor { BookId = book15.BookId, AuthorId = author10.AuthorId },// Solaris - Lem
                new BookAuthor { BookId = book16.BookId, AuthorId = author11.AuthorId },// Rok 1984 - Orwell
                new BookAuthor { BookId = book17.BookId, AuthorId = author12.AuthorId },// Duma i uprzedzenie - Austen
                new BookAuthor { BookId = book18.BookId, AuthorId = author13.AuthorId },// Sto lat samotności - Marquez
                new BookAuthor { BookId = book19.BookId, AuthorId = author14.AuthorId },// Lewa ręka ciemności - Le Guin
                new BookAuthor { BookId = book20.BookId, AuthorId = author4.AuthorId }  // Pamięć absolutna - King (przykładowo)
            };
            BookAuthors.AddRange(bookAuthors);
            SaveChanges();

            // 6. BookGenre
            var bookGenres = new List<BookGenre>
            {
                new BookGenre { BookId = book1.BookId, GenreId = genre1.GenreId }, // Quo Vadis - Powieść historyczna
                new BookGenre { BookId = book1.BookId, GenreId = genre7.GenreId }, // Quo Vadis - Literatura piękna
                new BookGenre { BookId = book2.BookId, GenreId = genre2.GenreId }, // Pan Tadeusz - Epika
                new BookGenre { BookId = book3.BookId, GenreId = genre7.GenreId }, // Księgi Jakubowe - Literatura piękna
                new BookGenre { BookId = book4.BookId, GenreId = genre4.GenreId }, // IT - Horror
                new BookGenre { BookId = book4.BookId, GenreId = genre3.GenreId }, // IT - Fantasy
                new BookGenre { BookId = book5.BookId, GenreId = genre7.GenreId }, // Lalka - Literatura piękna
                new BookGenre { BookId = book6.BookId, GenreId = genre3.GenreId }, // Mały Książę - Fantasy
                new BookGenre { BookId = book7.BookId, GenreId = genre3.GenreId }, // Władca Pierścieni - Fantasy
                new BookGenre { BookId = book8.BookId, GenreId = genre7.GenreId }, // Zbrodnia i kara - Literatura piękna
                new BookGenre { BookId = book9.BookId, GenreId = genre7.GenreId }, // Paragraf 22 - Literatura piękna
                new BookGenre { BookId = book10.BookId, GenreId = genre2.GenreId },// Dziady - Epika
                new BookGenre { BookId = book11.BookId, GenreId = genre1.GenreId },// W pustyni i w puszczy - Powieść historyczna
                new BookGenre { BookId = book12.BookId, GenreId = genre7.GenreId },// Nieznośna lekkość bytu - Literatura piękna
                new BookGenre { BookId = book13.BookId, GenreId = genre6.GenreId },// Diuna - Science Fiction
                new BookGenre { BookId = book14.BookId, GenreId = genre6.GenreId },// Blade Runner - Science Fiction
                new BookGenre { BookId = book15.BookId, GenreId = genre6.GenreId },// Solaris - Science Fiction
                new BookGenre { BookId = book16.BookId, GenreId = genre6.GenreId },// Rok 1984 - Science Fiction
                new BookGenre { BookId = book17.BookId, GenreId = genre7.GenreId },// Duma i uprzedzenie - Literatura piękna
                new BookGenre { BookId = book18.BookId, GenreId = genre7.GenreId },// Sto lat samotności - Literatura piękna
                new BookGenre { BookId = book19.BookId, GenreId = genre6.GenreId },// Lewa ręka ciemności - Science Fiction
                new BookGenre { BookId = book20.BookId, GenreId = genre6.GenreId } // Pamięć absolutna - Science Fiction
            };
            BookGenres.AddRange(bookGenres);
            SaveChanges();

            // 7. Recenzje
            var review1 = new Review { BookId = book1.BookId, UserId = user2.UserId, Contents = "Bardzo wciągająca lektura. Klasyka polskiej literatury.", DateAdded = DateTime.UtcNow.AddDays(-20) };
            var review2 = new Review { BookId = book4.BookId, UserId = user3.UserId, Contents = "Przerażająca i trzymająca w napięciu. Król horroru w najlepszej formie.", DateAdded = DateTime.UtcNow.AddDays(-10) };
            var review3 = new Review { BookId = book1.BookId, UserId = user3.UserId, Contents = "Arcydzieło! Niezapomniana podróż do starożytnego Rzymu.", DateAdded = DateTime.UtcNow.AddDays(-5) };
            var review4 = new Review { BookId = book7.BookId, UserId = user4.UserId, Contents = "Niesamowita podróż do Śródziemia. Pozycja obowiązkowa dla fanów fantasy.", DateAdded = DateTime.UtcNow.AddDays(-15) };
            var review5 = new Review { BookId = book16.BookId, UserId = user5.UserId, Contents = "Klasyka dystopii. Aktualna do dziś.", DateAdded = DateTime.UtcNow.AddDays(-8) };
            var review6 = new Review { BookId = book3.BookId, UserId = user6.UserId, Contents = "Wymagająca, ale bardzo satysfakcjonująca lektura. Tokarczuk w formie.", DateAdded = DateTime.UtcNow.AddDays(-2) };
            var review7 = new Review { BookId = book13.BookId, UserId = user7.UserId, Contents = "Klasyk sci-fi. Budowanie świata jest genialne.", DateAdded = DateTime.UtcNow.AddDays(-7) };
            var review8 = new Review { BookId = book5.BookId, UserId = user8.UserId, Contents = "Obowiązkowa lektura szkolna, ale nadal aktualna.", DateAdded = DateTime.UtcNow.AddDays(-4) };
            var review9 = new Review { BookId = book11.BookId, UserId = user2.UserId, Contents = "Ciekawa podróż dla młodzieży i dorosłych.", DateAdded = DateTime.UtcNow.AddDays(-1) };
            var review10 = new Review { BookId = book17.BookId, UserId = user3.UserId, Contents = "Romantyczna opowieść, która nigdy się nie starzeje.", DateAdded = DateTime.UtcNow.AddHours(-12) };
            var review11 = new Review { BookId = book18.BookId, UserId = user4.UserId, Contents = "Magiczny realizm w najlepszym wydaniu. Genialne!", DateAdded = DateTime.UtcNow.AddHours(-6) };
            var review12 = new Review { BookId = book6.BookId, UserId = user5.UserId, Contents = "Krótka, ale głęboka historia o sensie życia.", DateAdded = DateTime.UtcNow.AddHours(-3) };
            var review13 = new Review { BookId = book15.BookId, UserId = user6.UserId, Contents = "Filozoficzna opowieść o kontakcie z obcymi. Niezwykła.", DateAdded = DateTime.UtcNow.AddHours(-1) };
            var review14 = new Review { BookId = book20.BookId, UserId = user7.UserId, Contents = "Interesujący science-fiction, choć momentami trudny.", DateAdded = DateTime.UtcNow.AddMinutes(-30) };
            var review15 = new Review { BookId = book9.BookId, UserId = user8.UserId, Contents = "Satyryczne i zabawne spojrzenie na wojnę. Ponadczasowe.", DateAdded = DateTime.UtcNow.AddMinutes(-10) };
            
            Reviews.AddRange(review1, review2, review3, review4, review5, review6, review7, review8, review9, review10, review11, review12, review13, review14, review15);
            SaveChanges();

            // 8. Oceny (20 ocen)
            var rate1 = new Rate { UserId = user1_admin.UserId, BookId = book1.BookId, RateValue = 5 };
            var rate2 = new Rate { UserId = user2.UserId, BookId = book4.BookId, RateValue = 4 };
            var rate3 = new Rate { UserId = user3.UserId, BookId = book2.BookId, RateValue = 5 };
            var rate4 = new Rate { UserId = user4.UserId, BookId = book1.BookId, RateValue = 4 };
            var rate5 = new Rate { UserId = user5.UserId, BookId = book7.BookId, RateValue = 5 };
            var rate6 = new Rate { UserId = user6.UserId, BookId = book16.BookId, RateValue = 5 };
            var rate7 = new Rate { UserId = user7.UserId, BookId = book3.BookId, RateValue = 4 };
            var rate8 = new Rate { UserId = user8.UserId, BookId = book13.BookId, RateValue = 5 };
            var rate9 = new Rate { UserId = user1_admin.UserId, BookId = book5.BookId, RateValue = 4 };
            var rate10 = new Rate { UserId = user2.UserId, BookId = book11.BookId, RateValue = 3 };
            var rate11 = new Rate { UserId = user3.UserId, BookId = book17.BookId, RateValue = 5 };
            var rate12 = new Rate { UserId = user4.UserId, BookId = book18.BookId, RateValue = 5 };
            var rate13 = new Rate { UserId = user5.UserId, BookId = book6.BookId, RateValue = 5 };
            var rate14 = new Rate { UserId = user6.UserId, BookId = book15.BookId, RateValue = 4 };
            var rate15 = new Rate { UserId = user7.UserId, BookId = book20.BookId, RateValue = 3 };
            var rate16 = new Rate { UserId = user8.UserId, BookId = book9.BookId, RateValue = 4 };
            var rate17 = new Rate { UserId = user2.UserId, BookId = book10.BookId, RateValue = 4 };
            var rate18 = new Rate { UserId = user3.UserId, BookId = book14.BookId, RateValue = 3 };
            var rate19 = new Rate { UserId = user4.UserId, BookId = book19.BookId, RateValue = 4 };
            var rate20 = new Rate { UserId = user5.UserId, BookId = book12.BookId, RateValue = 3 };

            Rates.AddRange(rate1, rate2, rate3, rate4, rate5, rate6, rate7, rate8, rate9, rate10, rate11, rate12, rate13, rate14, rate15, rate16, rate17, rate18, rate19, rate20);
            SaveChanges();

            // 9. Wypożyczenia (50 wypożyczeń)
            var bookLoans = new List<BookLoan>();
            // Przykładowe 50 wypożyczeń
            var allUsers = new List<User> { user1_admin, user2, user3, user4, user5, user6, user7, user8 };
            var allBooks = new List<Book> { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14, book15, book16, book17, book18, book19, book20 };

            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                var randomUser = allUsers[rnd.Next(allUsers.Count)];
                var randomBook = allBooks[rnd.Next(allBooks.Count)];

                var loanDate = DateTime.UtcNow.AddDays(-rnd.Next(1, 180));
                var plannedReturnDate = loanDate.AddDays(14);

                DateTime? returnDate = null;
                if (rnd.NextDouble() < 0.7)
                {
                    returnDate = plannedReturnDate.AddDays(rnd.Next(-5, 10));
                    if (returnDate > DateTime.UtcNow)
                    {
                        returnDate = null;
                    }
                }

                bookLoans.Add(new BookLoan
                {
                    BookId = randomBook.BookId,
                    UserId = randomUser.UserId,
                    LoanDate = loanDate,
                    PlannedReturnDate = plannedReturnDate,
                    ReturnDate = returnDate
                });
            }

            BookLoans.AddRange(bookLoans);
            SaveChanges();

            Console.WriteLine("Initial data seeding completed with predefined values (without Adress).");

        }
    }
}
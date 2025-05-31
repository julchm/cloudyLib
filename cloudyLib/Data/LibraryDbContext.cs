using Microsoft.EntityFrameworkCore;
using cloudyLib.Models;
using Bogus;

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
                .HasKey(ba => new { ba.Book_id, ba.Author_id });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.Book_id);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.Author_id);

            // BookGenre - composite key
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.Book_id, bg.Genre_id });

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.Book_id);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.Genre_id);

            // Rate - composite key
            modelBuilder.Entity<Rate>()
                .HasKey(r => new { r.User_id, r.Book_id });

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rates)
                .HasForeignKey(r => r.User_id);

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Rates)
                .HasForeignKey(r => r.Book_id);

            // Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.User_id);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.Book_id);

            // BookLoan
            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.BookLoans)
                .HasForeignKey(bl => bl.Book_id);

            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.User)
                .WithMany(u => u.BookLoans)
                .HasForeignKey(bl => bl.User_id);

            // Book - Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.Author_id)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void SeedData()
        {
            if (Users.Any()) return; 

            var faker = new Faker("pl");



            // 1. Użytkownicy
            var users = new Faker<User>()
                .RuleFor(u => u.First_Name, f => f.Name.FirstName())
                .RuleFor(u => u.Last_Name, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Phone_number, f => f.Phone.PhoneNumber("###-###-###"))
                .RuleFor(u => u.Password, f => f.Internet.Password(8, true, @"!@#$%^&*"))
                .RuleFor(u => u.Role, f => f.PickRandom(new[] { "reader", "admin" }))
                .Generate(20);

            Users.AddRange(users);
            SaveChanges();

            // 2. Autorzy
            var authors = new Faker<Author>()
                .RuleFor(a => a.First_name, f => f.Name.FirstName())
                .RuleFor(a => a.Last_name, f => f.Name.LastName())
                .Generate(10);

            Authors.AddRange(authors);
            SaveChanges();

            // 3. Gatunki
            var genres = new[]
            {
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Science Fiction" },
                new Genre { Name = "History" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Biography" }
            };
            Genres.AddRange(genres);
            SaveChanges();

            // 4. Książki
            var books = new Faker<Book>()
                .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
                .RuleFor(b => b.ISBN, f => f.Random.Replace("###-#-##-######-#"))
                .RuleFor(b => b.Availability, f => f.Random.Bool(0.7f))
                .RuleFor(b => b.Date_added, f => f.Date.Past(2))
                .RuleFor(b => b.Year_of_release, f => (short)f.Date.Past(20).Year)
                .RuleFor(b => b.Number_of_loans, f => f.Random.Int(0, 20))
                .RuleFor(b => b.Author_id, f => f.PickRandom(authors).Author_id)
                .Generate(30);

            Books.AddRange(books);
            SaveChanges();

            // 5. BookAuthor (wielu autorów na książkę)
            var bookAuthors = books
                .SelectMany(b => authors.OrderBy(_ => Guid.NewGuid()).Take(2), (book, author) => new BookAuthor
                {
                    Book_id = book.Book_id,
                    Author_id = author.Author_id
                })
                .Distinct()
                .ToList();

            BookAuthors.AddRange(bookAuthors);
            SaveChanges();

            // 6. BookGenre (każda książka ma 1-2 gatunki)
            var bookGenres = books
                .SelectMany(b => genres.OrderBy(_ => Guid.NewGuid()).Take(2), (book, genre) => new BookGenre
                {
                    Book_id = book.Book_id,
                    Genre_id = genre.Genre_id
                })
                .Distinct()
                .ToList();

            BookGenres.AddRange(bookGenres);
            SaveChanges();

            // 7. Recenzje
            var reviews = new Faker<Review>()
                .RuleFor(r => r.Book_id, f => f.PickRandom(books).Book_id)
                .RuleFor(r => r.User_id, f => f.PickRandom(users).User_id)
                .RuleFor(r => r.Contents, f => f.Lorem.Paragraph())
                .RuleFor(r => r.Date_added, f => f.Date.Past())
                .Generate(50);

            Reviews.AddRange(reviews);
            SaveChanges();

            // 8. Oceny
            var rates = users.SelectMany(u => books.OrderBy(_ => Guid.NewGuid()).Take(5).Select(b => new Rate
            {
                User_id = u.User_id,
                Book_id = b.Book_id,
                Rate_value = (int)faker.Random.Int(1, 5)
            })).ToList();

            Rates.AddRange(rates);
            SaveChanges();

            // 9. Wypożyczenia
            var bookLoans = new Faker<BookLoan>()
                .RuleFor(l => l.Book_id, f => f.PickRandom(books).Book_id)
                .RuleFor(l => l.User_id, f => f.PickRandom(users).User_id)
                .RuleFor(l => l.Loan_date, f => f.Date.Past(1))
                .RuleFor(l => l.Planned_return_date, (f, l) => l.Loan_date.AddDays(14))
                .RuleFor(l => l.Return_date, (f, l) =>
                {
                    if (f.Random.Bool(0.7f)) 
                    {
                        return l.Planned_return_date?.AddDays(f.Random.Int(-3, 10)); 
                    }
                    return null; 
                })
                .Generate(40);

            BookLoans.AddRange(bookLoans);
            SaveChanges();
        }


    }
}

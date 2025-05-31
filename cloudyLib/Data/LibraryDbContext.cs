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
            if (Users.Any()) return;

            var faker = new Faker("pl");

            // 1. Użytkownicy
            var users = new Faker<User>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName()) 
                .RuleFor(u => u.LastName, f => f.Name.LastName())   
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber("###-###-###")) 
                .RuleFor(u => u.Password, f => f.Internet.Password(8, true, @"!@#$%^&*"))
                .RuleFor(u => u.Role, f => f.PickRandom(new[] { "Reader", "Administrator" })) 
                .Generate(20);

            Users.AddRange(users);
            SaveChanges();

            // 2. Autorzy
            var authors = new Faker<Author>()
                .RuleFor(a => a.FirstName, f => f.Name.FirstName()) 
                .RuleFor(a => a.LastName, f => f.Name.LastName())   
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
                .RuleFor(b => b.AvailableCopies, f => f.Random.Int(1, 5)) 
                .RuleFor(b => b.DateAdded, f => f.Date.Past(2))          
                .RuleFor(b => b.YearOfRelease, f => (short)f.Date.Past(20).Year) 
                .Generate(30);

            Books.AddRange(books);
            SaveChanges();

            // 5. BookAuthor (wielu autorów na książkę)
            var bookAuthors = books
                .SelectMany(b => authors.OrderBy(_ => Guid.NewGuid()).Take(2), (book, author) => new BookAuthor
                {
                    BookId = book.BookId,     
                    AuthorId = author.AuthorId 
                })
                .Distinct()
                .ToList();

            BookAuthors.AddRange(bookAuthors);
            SaveChanges();

            // 6. BookGenre (każda książka ma 1-2 gatunki)
            var bookGenres = books
                .SelectMany(b => genres.OrderBy(_ => Guid.NewGuid()).Take(2), (book, genre) => new BookGenre
                {
                    BookId = book.BookId,     
                    GenreId = genre.GenreId   
                })
                .Distinct()
                .ToList();

            BookGenres.AddRange(bookGenres);
            SaveChanges();

            // 7. Recenzje
            var reviews = new Faker<Review>()
                .RuleFor(r => r.BookId, f => f.PickRandom(books).BookId)   
                .RuleFor(r => r.UserId, f => f.PickRandom(users).UserId)  
                .RuleFor(r => r.Contents, f => f.Lorem.Paragraph())
                .RuleFor(r => r.DateAdded, f => f.Date.Past())             
                .Generate(50);

            Reviews.AddRange(reviews);
            SaveChanges();

            // 8. Oceny
            var rates = users.SelectMany(u => books.OrderBy(_ => Guid.NewGuid()).Take(5).Select(b => new Rate
            {
                UserId = u.UserId,     
                BookId = b.BookId,      
                RateValue = (int)faker.Random.Int(1, 5)
            })).ToList();

            Rates.AddRange(rates);
            SaveChanges();

            // 9. Wypożyczenia
            var bookLoans = new Faker<BookLoan>()
                .RuleFor(l => l.BookId, f => f.PickRandom(books).BookId)     
                .RuleFor(l => l.UserId, f => f.PickRandom(users).UserId)     
                .RuleFor(l => l.LoanDate, f => f.Date.Past(1))               
                .RuleFor(l => l.PlannedReturnDate, (f, l) => l.LoanDate.AddDays(14)) 
                .RuleFor(l => l.ReturnDate, (f, l) =>                        
                {
                    if (f.Random.Bool(0.7f))
                    {
                        return l.PlannedReturnDate?.AddDays(f.Random.Int(-3, 10));
                    }
                    return null;
                })
                .Generate(40);

            BookLoans.AddRange(bookLoans);
            SaveChanges();
        }
    }
}
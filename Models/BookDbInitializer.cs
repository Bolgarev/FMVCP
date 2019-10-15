using System.Data.Entity;

namespace FMVCP.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Author = "Гитлер", Name = "Моя борьба", Price = 1488 });
            db.Books.Add(new Book { Author = "Муссолини", Name = "Его борьба", Price = 1337 });
            db.Books.Add(new Book { Author = "Пиначет", Name = "Мое дело будет жить", Price = 666 });

            base.Seed(db);
        }
    }
}
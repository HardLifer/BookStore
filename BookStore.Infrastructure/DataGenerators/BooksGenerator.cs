using Bogus;
using BookStore.Core.Models;

namespace BookStore.Infrastructure.DataGenerators
{
    class BookFaker : Faker<Book>
    {
        public BookFaker()
        {
            RuleFor(ent => ent.Id, f => f.Random.Guid());
            RuleFor(ent => ent.Title, f => f.Random.String(5));
            RuleFor(ent => ent.Author, f => string.Join(' ', f.Person.UserName, f.Person.LastName));
            RuleFor(ent => ent.Published, f => f.Date.Between(new DateTime(1500, 1, 1), DateTime.UtcNow));
        }
    }

    public static class BooksGenerator
    {
        public static List<Book> GenerateBooks(int count = 2)
        {
            var faker = new BookFaker();
            return faker.Generate(count);
        }
    }
}

using Hipages.Tradies.Domain.Entities;
using Hipages.Tradies.Domain.Enums;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(TradiesDbContext context)
        {
            context.Jobs.Add(new Job
            {
                Status = JobStatus.Accepted,
                Category = new Category
                {
                    Id = 1,
                    Name = "Plumbing",
                    ParentCategoryId = 0
                },
                Contact = new Contact("Luke Skywalker", "0412345678", "luke@mailinator.com"),
                CreatedAt = DateTime.UtcNow,
                Description = "",
                Id = 1,
                Suburb = new Suburb
                {
                    Id = 4,
                    Name = "Surry Hills",
                    Postcode = "2010"
                },
                Price = 20,
                UpdatedAt = DateTime.UtcNow
            });

            context.Jobs.Add(new Job
            {
                Status = JobStatus.Declined,
                Category = new Category
                {
                    Id = 2,
                    Name = "Electrical",
                    ParentCategoryId = 0
                },
                Contact = new Contact("Darth Vader", "0422223333", "darth@mailinator.com"),
                CreatedAt = DateTime.UtcNow,
                Description = "",
                Id = 2,
                Suburb = new Suburb
                {
                    Id = 5,
                    Name = "Newtown",
                    Postcode = "2042"
                },
                Price = 30,
                UpdatedAt = DateTime.UtcNow
            });

            context.Jobs.Add(new Job
            {
                Status = JobStatus.New,
                Category = new Category
                {
                    Id = 3,
                    Name = "Carpentry",
                    ParentCategoryId = 0
                },
                Contact = new Contact("Han Solo", "0498765432", "han@mailinator.com"),
                CreatedAt = DateTime.UtcNow,
                Description = "",
                Id = 3,
                Suburb = new Suburb
                {
                    Id = 6,
                    Name = "Newtown",
                    Postcode = "2042"
                },
                Price = 40,
                UpdatedAt = DateTime.UtcNow
            });

            context.SaveChanges();
        }
    }
}

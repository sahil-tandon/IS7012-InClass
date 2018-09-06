using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HealthDeptApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                if (context.Establishment.Any()) {
                    return; // DB HAS BEEN SEEDED
                }

                var italianCategory = new Category { Name = "Italian" };
                var mexicanCategory = new Category { Name = "Mexican" };
                var americanCategory = new Category { Name = "American" };
                var indianCategory = new Category { Name = "Indian" };

                context.Category.AddRange(
                    italianCategory,
                    mexicanCategory,
                    americanCategory,
                    indianCategory
                );

                context.Establishment.AddRange(
                    new Establishment {
                        Name = "Olive Garden",
                        Score = 70.5m,
                        HasLiquorLicense = true,
                        OpenDate = new DateTime(2010,3,5),
                        ClosedDate = null,
                        Category = italianCategory
                    },
                    new Establishment {
                        Name = "Chipotle",
                        Score = 68.8m,
                        HasLiquorLicense = false,
                        OpenDate = new DateTime(2014,6,14),
                        ClosedDate = null,
                        Category = mexicanCategory
                    },
                    new Establishment {
                        Name = "Royal Taj",
                        Score = 81.2m,
                        HasLiquorLicense = true,
                        OpenDate = new DateTime(2017,10,22),
                        ClosedDate = null,
                        Category = indianCategory
                    },
                    new Establishment {
                        Name = "Ihop",
                        Score = 52.7m,
                        HasLiquorLicense = false,
                        OpenDate = new DateTime(2010,5,12),
                        ClosedDate = new DateTime(2016,10,31),
                        Category = americanCategory
                    },
                    new Establishment {
                        Name = "Nicolas",
                        Score = 91.7m,
                        HasLiquorLicense = true,
                        OpenDate = new DateTime(2003,5,12),
                        ClosedDate = null,
                        Category = italianCategory
                    }
                );

                context.SaveChanges();

                // GATTUSMP: SAMPLE OF A SEED FILE THAT FIRST LOOKS FOR A DATABASE WITH DATA
                //           IF NO DATA FOUND THEN DATA IS ADDED TO THE DATABASE
                // // Look for any movies.
                // if (context.Movie.Any())
                // {
                //     return;   // DB has been seeded
                // }

                // context.Movie.AddRange(
                //     new Movie
                //     {
                //         Title = "When Harry Met Sally",
                //         ReleaseDate = DateTime.Parse("1989-2-12"),
                //         Genre = "Romantic Comedy",
                //         Price = 7.99M
                //     },

                //     new Movie
                //     {
                //         Title = "Ghostbusters",
                //         ReleaseDate = DateTime.Parse("1984-3-13"),
                //         Genre = "Comedy",
                //         Price = 8.99M
                //     },

                //     new Movie
                //     {
                //         Title = "Ghostbusters 2",
                //         ReleaseDate = DateTime.Parse("1986-2-23"),
                //         Genre = "Comedy",
                //         Price = 9.99M
                //     },

                //     new Movie
                //     {
                //         Title = "Rio Bravo",
                //         ReleaseDate = DateTime.Parse("1959-4-15"),
                //         Genre = "Western",
                //         Price = 3.99M
                //     }
                // );
                //context.SaveChanges();
            }
        }
    }
}
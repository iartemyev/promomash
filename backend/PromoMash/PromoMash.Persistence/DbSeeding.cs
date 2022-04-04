using Microsoft.EntityFrameworkCore;
using PromoMash.Domain.Core;

namespace PromoMash.Persistence;

public static class DbSeeding
{
    public static void Seed(ModelBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var country1 = new CountryEntity("Country-1");
        var country2 = new CountryEntity("Country-2");

        var province1 = new ProvinceEntity("Province-1.1", country1);
        var province2 = new ProvinceEntity("Province-1.2", country1);
        var province3 = new ProvinceEntity("Province-2.1", country2);
        var province4 = new ProvinceEntity("Province-2.2", country2);

        builder.Entity<CountryEntity>().HasData(
            new
            {
                country1.Id,
                country1.CreatedAt,
                country1.UpdatedAt,
                country1.Name,
            },
            new
            {
                country2.Id,
                country2.CreatedAt,
                country2.UpdatedAt,
                country2.Name,
            });

        builder.Entity<ProvinceEntity>().HasData(
            new
            {
                province1.Id,
                province1.CreatedAt,
                province1.UpdatedAt,
                province1.Name,
                CountryId = province1.Country.Id,
            },
            new
            {
                province2.Id,
                province2.CreatedAt,
                province2.UpdatedAt,
                province2.Name,
                CountryId = province2.Country.Id,
            },
            new
            {
                province3.Id,
                province3.CreatedAt,
                province3.UpdatedAt,
                province3.Name,
                CountryId = province3.Country.Id,
            },
            new
            {
                province4.Id,
                province4.CreatedAt,
                province4.UpdatedAt,
                province4.Name,
                CountryId = province4.Country.Id,
            });
    }
}
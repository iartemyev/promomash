using System;
using Microsoft.EntityFrameworkCore;
using PromoMash.Domain.Core;
using PromoMash.Persistence;

namespace PromoMash.UnitTest.Common;

public static class PromoMashContextFactory
{
    public static readonly string IdForDelete = Guid.NewGuid().ToString("N");
    public static readonly string IdForUpdate = Guid.NewGuid().ToString("N");

    public static PromoMashDbContext Create()
    {
        var options = new DbContextOptionsBuilder<PromoMashDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new PromoMashDbContext(options);
        context.Database.EnsureCreated();
        context.Countries.AddRange(
            new CountryEntity("Country1"){ Id = "A6BB65BB-5AC2-4AFA-8A28-2616F675B825" },
            new CountryEntity("Country2"){ Id = "909F7C29-891B-4BE1-8504-21F84F262084" },
            new CountryEntity("Country3"){ Id = IdForDelete },
            new CountryEntity("Country4"){ Id = IdForUpdate }
        );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(PromoMashDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
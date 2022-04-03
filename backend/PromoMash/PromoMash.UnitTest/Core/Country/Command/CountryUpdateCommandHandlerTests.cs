using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Common.Exception;
using PromoMash.Application.Core.Country.Command.Update;
using PromoMash.UnitTest.Common;
using Xunit;

namespace PromoMash.UnitTest.Core.Country.Command;

public class CountryUpdateCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CountryUpdateCommandHandler_Success()
    {
        // Arrange
        var handler = new CountryUpdateCommandHandler(Context);
        var name = "Country new title";

        // Act
        await handler.Handle(new CountryUpdateCommand {Id = PromoMashContextFactory.IdForUpdate, Name = name},
            CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Countries.SingleOrDefaultAsync(entity =>
            entity.Id == PromoMashContextFactory.IdForUpdate && entity.Name == name));
    }

    [Fact]
    public async Task CountryUpdateCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new CountryUpdateCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<PromoMashNotFoundException>(async () =>
            await handler.Handle(new CountryUpdateCommand {Id = Guid.NewGuid().ToString("N")}, CancellationToken.None));
    }
}
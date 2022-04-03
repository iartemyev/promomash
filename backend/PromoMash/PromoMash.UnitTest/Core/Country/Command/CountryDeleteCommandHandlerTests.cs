using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Common.Exception;
using PromoMash.Application.Core.Country.Command.Delete;
using PromoMash.UnitTest.Common;
using Xunit;

namespace PromoMash.UnitTest.Core.Country.Command;

public class CountryDeleteCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CountryDeleteCommandHandler_Success()
    {
        // Arrange
        var handler = new CountryDeleteCommandHandler(Context);

        // Act
        await handler.Handle(new CountryDeleteCommand(PromoMashContextFactory.IdForDelete), CancellationToken.None);

        // Assert
        Assert.Null(await Context.Countries.SingleOrDefaultAsync(entity => entity.Id == PromoMashContextFactory.IdForDelete));
    }

    [Fact]
    public async Task CountryDeleteCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new CountryDeleteCommandHandler(Context);

        // Act
        // Assert
        await Assert.ThrowsAsync<PromoMashNotFoundException>(async () =>
            await handler.Handle(new CountryDeleteCommand(Guid.NewGuid().ToString("N")), CancellationToken.None));
    }
}
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Core.Country.Command.Create;
using PromoMash.UnitTest.Common;
using Xunit;

namespace PromoMash.UnitTest.Core.Country.Command;

public class CountryCreateCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CountryCreateCommandHandler_Success()
    {
        // Arrange
        var handler = new CountryCreateCommandHandler(Context);
        var name = "Country name";

        // Act
        var id = await handler.Handle(new CountryCreateCommand {Name = name}, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Countries.SingleOrDefaultAsync(entity => entity.Id == id && entity.Name == name));
    }
}
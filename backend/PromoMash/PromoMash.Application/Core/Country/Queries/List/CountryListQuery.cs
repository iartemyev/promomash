using MediatR;

namespace PromoMash.Application.Core.Country.Queries.List;

public class CountryListQuery : IRequest<CountryListVm>
{
    public string Text { get; set; }

    public CountryListQuery(string text)
    {
        Text = text;
    }
}
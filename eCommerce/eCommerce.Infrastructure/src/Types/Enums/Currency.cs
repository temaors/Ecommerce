
using eCommerce.Extensions.EnumExtensions;

namespace eCommerce.Infrastructure.Types.Enums;

public enum Currency
{
    [Caption("BYN")]
    Byn,
    [Caption("RUB")]
    Rub,
    [Caption("USD")]
    Usd,
    [Caption("EUR")]
    Eur,
    [Caption("KZT")]
    Kzt,
    [Caption("UAH")]
    Uah,
}
using Gconnect.Application.Common.Interfaces;

namespace Gconnect.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}

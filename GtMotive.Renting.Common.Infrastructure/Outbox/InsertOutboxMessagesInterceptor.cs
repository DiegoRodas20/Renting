using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GtMotive.Renting.Common.Infrastructure.Outbox;

public sealed class InsertOutboxMessagesInterceptor : SaveChangesInterceptor
{
}

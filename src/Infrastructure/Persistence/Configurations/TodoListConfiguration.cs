using Gconnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gconnect.Infrastructure.Persistence.Configurations;

public class TodoListConfiguration 
{
    public void Configure(EntityTypeBuilder builder)
    {

        //builder
        //    .OwnsOne(b => b.Colour);
    }
}

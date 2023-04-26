using Heimdall.Data;
using Heimdall.Logic.WorkInstructions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Heimdall.Data.EntityConfigurations
{
    /// <summary>
    /// Configuration for the <see cref="Item"/>
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
        }
    }
}

using Heimdall.Data;
using Heimdall.Logic.WorkInstructions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Heimdall.Data.EntityConfigurations
{
    /// <summary>
    /// Configuration for the <see cref="InstructionItem"/>
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class InstructionItemConfiguration : IEntityTypeConfiguration<InstructionItem>
    {
        public void Configure(EntityTypeBuilder<InstructionItem> builder)
        {
            builder.HasKey(x => new {x.InstructionId, x.ItemId});

            builder.Property(x => x.ItemQuantity);

            builder
                .HasOne<Instruction>()
                .WithMany(x => x.ItemList)
                .HasForeignKey(x => x.InstructionId)
                .IsRequired();

            builder
                .HasOne<Item>()
                .WithMany()
                .HasForeignKey(x => x.ItemId)
                .IsRequired();
        }
    }
}

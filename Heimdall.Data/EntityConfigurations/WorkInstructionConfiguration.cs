using Heimdall.Data;
using Heimdall.Logic.WorkInstructions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heimdall.Data.EntityConfigurations
{
    /// <summary>
    /// Configuration for the <see cref="WorkInstruction"/>
    /// </summary>
    /// <remarks>
    /// RLP - I'd encourage using the full name of the entity element that this extends (e.g., it's a configuration)
    /// </remarks>
    public class WorkInstructionConfiguration : IEntityTypeConfiguration<WorkInstruction>
    {
        public void Configure(EntityTypeBuilder<WorkInstruction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(20);
            //I just wanted to see if this worked, i get response 500 errors when the title is too long; so it does.

            builder.Property(x => x.Description);

            builder.Property(x => x.InstructionObject);
        }
    }
}

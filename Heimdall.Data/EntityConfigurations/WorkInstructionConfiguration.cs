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
                .IsRequired();

            builder.Property(x => x.Description);

            // turns out that InstructionList cant be configured as a property since its apparently configured as a "navigation"
        }
    }
}
using Heimdall.Data;
using Heimdall.Logic.WorkInstructions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Heimdall.Data.EntityConfigurations
{
    /// <summary>
    /// Configuration for the <see cref="Instruction"/>
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder.HasKey(x => x.InstructionId);

            builder.Property(x => x.InstructionText);

            builder.Property(x => x.InstructionImage);

            builder.Property(x => x.InstructionCordinates);

            builder
                .HasOne<WorkInstruction>() //This broke evrything when i had it set as (x => x.)
                .WithMany(x => x.InstructionList)
                .HasForeignKey(x => x.InstructionForeignKey)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Is this a good idea????
                
        }
    }
}

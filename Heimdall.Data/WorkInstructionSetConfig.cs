using Heimdall.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace heimdall_web_api.Configs
{
    public class WorkInstructionSetConfig : IEntityTypeConfiguration<WorkInstructionSet>
    {
        public void Configure(EntityTypeBuilder<WorkInstructionSet> builder)
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

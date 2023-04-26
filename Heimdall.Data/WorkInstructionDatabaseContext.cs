using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Logic.WorkInstructions.Entities;
using System.Reflection;

namespace Heimdall.Data
{
    public class WorkInstructionDatabaseContext : DbContext
    {
        public WorkInstructionDatabaseContext(DbContextOptions<WorkInstructionDatabaseContext> options) : base(options)
        {
        }

        // RLP - use PascalCasing for entities. The word "Set" isn't needed to define a set.
        public DbSet<WorkInstruction> WorkInstructions { get; set; }

        public DbSet<Instruction> Instructions { get; set; }

        public DbSet<InstructionItem> InstructionItems { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RLP - There way will load all configurations in the entire assembly without having to specify them individually.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

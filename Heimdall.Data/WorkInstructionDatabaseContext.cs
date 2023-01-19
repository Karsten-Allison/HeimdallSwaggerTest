using Microsoft.EntityFrameworkCore;
using heimdall_web_api.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Data
{
    public class WorkInstructionDatabaseContext : DbContext
    {
        public WorkInstructionDatabaseContext(DbContextOptions<WorkInstructionDatabaseContext> options) : base(options)
        {
        }
        public DbSet<WorkInstructionSet> workInstructionSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new WorkInstructionSetConfig().Configure(modelBuilder.Entity<WorkInstructionSet>());
            //now using IEntityTypeConfiguration to setup data accsess in a organized way
        }
    }
}

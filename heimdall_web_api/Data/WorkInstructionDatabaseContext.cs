using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using heimdall_web_api;

namespace heimdall_web_api.Data
{
    public class WorkInstructionDatabaseContext : DbContext
    {
        public WorkInstructionDatabaseContext(DbContextOptions<WorkInstructionDatabaseContext> options) : base(options)
        {
        }


        public DbSet<WorkInstructionSet> workInstructionSets { get; set; }
    }
}

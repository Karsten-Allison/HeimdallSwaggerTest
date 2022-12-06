using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using heimdall_web_api;

namespace heimdall_web_api.Data
{
    public class WorkInstructionSet
    {
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }

        public string Description { get; set; }

        public string InstructionObject { get; set; }
    }

}

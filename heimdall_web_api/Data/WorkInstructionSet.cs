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
        [Key][Required] 
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Instruction> InstructionList { get; set; }
    }

    public class Instruction
    {
        [Key][Required] 
        public Guid Id { get; set;}

        public string Text { get; set; }


    }
}

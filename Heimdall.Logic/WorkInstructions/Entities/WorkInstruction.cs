using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Entities
{
    public class WorkInstruction
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string InstructionObject { get; set; } = string.Empty;
        //This will probably be replaced with List of objects/strings/something as seen fit
        
        // RLP - also, by setting the entity framework relationships correctly, the entire
        // tree of objects can be retrieved, edited, and saved all as if it were a transparent
        // data structure! :)
    }
}

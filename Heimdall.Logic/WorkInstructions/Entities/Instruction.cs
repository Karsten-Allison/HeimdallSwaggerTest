using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Entities
{
    public class Instruction
    {
        public int InstructionId { get; set; }

        public string InstructionText { get; set; } = string.Empty;
        // Instruction text, self explanatory

        public string InstructionImage { get; set; } = string.Empty;
        // Instruction "image", potentially image converted to base64 

        public string InstructionCordinates { get; set; } = string.Empty;
        // Instruction "cordinates", potentially a sort of ([x,y,xsize,ysize] scaled to 0-1 ) sort of thing

        public ICollection<InstructionItem>? ItemList { get; set; }

        //------------------------
        public int InstructionForeignKey { get; set; } 
    }
}

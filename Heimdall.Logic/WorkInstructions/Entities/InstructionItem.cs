using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.WorkInstructions.Entities
{
    public class InstructionItem
    {
        public int ItemId { get; set; }
        public int InstructionId { get; set; }

        public double ItemQuantity { get; set; }
        public Item? Item { get; set; }
    }
}

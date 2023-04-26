using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Logic.Core;
using Heimdall.Logic.WorkInstructions.Entities;

namespace Heimdall.Logic.WorkInstructions.Commands
{
    /// <summary>
    /// A command object to create a instruction item
    /// </summary>
    /// <param name="ItemId"></param>
    /// <param name="InstructionId"></param>
    /// <param name="ItemQuantity"></param>
    /// <param name="Item"></param>
    public record UpdateInstructionItem(int ItemId, int InstructionId, double? ItemQuantity, Item? Item) : ICommand;
}

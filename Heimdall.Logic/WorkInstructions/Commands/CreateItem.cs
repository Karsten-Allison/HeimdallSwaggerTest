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
    /// A command object to create an item
    /// </summary>
    /// <param name="Name"></param>
    public record CreateItem(string Name) : ICommand;
}

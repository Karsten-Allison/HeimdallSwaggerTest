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
    /// A command object to update a item
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    public record UpdateItem(int Id, string? Name) : ICommand;
}

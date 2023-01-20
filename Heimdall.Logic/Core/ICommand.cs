using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic.Core
{
    /// <summary>
    /// Commands are objects that represent actions that a user can take.
    /// </summary>
    /// <remarks>
    /// RLP - these should always be of the form of  "Action Entity Attribute", like "SetWorkInstructionAuthor".
    /// They are always present tense - business logic behaviors that are happening right now.
    /// </remarks>
    public interface ICommand
    {
    }
}

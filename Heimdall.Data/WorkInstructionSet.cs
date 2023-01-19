using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Data
{
    public class WorkInstructionSet
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string InstructionObject { get; set; }
        //This will probably be replaced with List of objects/strings/something as seen fit
    }

}

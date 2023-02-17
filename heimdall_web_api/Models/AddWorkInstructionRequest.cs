using Heimdall.Data;
using Heimdall.Logic.WorkInstructions.Entities;
using Microsoft.AspNetCore.Mvc;

namespace heimdall_web_api.Models
{
    public record AddWorkInstructionRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<Instruction> InstructionList { get; set; }
    }
}

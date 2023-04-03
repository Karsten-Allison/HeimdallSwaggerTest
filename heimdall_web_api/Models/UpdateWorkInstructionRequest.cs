using Heimdall.Data;
using Heimdall.Logic.WorkInstructions.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace heimdall_web_api.Models
{
    public record UpdateWorkInstructionRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<Instruction> InstructionList { get; set; }
    }
}

using Heimdall.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace heimdall_web_api.Models
{
    public record UpdateWorkInstructionRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string InstructionObject { get; set; }
    }
}

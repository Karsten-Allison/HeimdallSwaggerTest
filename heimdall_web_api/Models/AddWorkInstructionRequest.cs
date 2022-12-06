using heimdall_web_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace heimdall_web_api.Models
{
    public class AddWorkInstructionRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string InstructionObject { get; set; }
    }
}

using heimdall_web_api.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace heimdall_web_api.Models
{
    public class UpdateWorkInstructionListRequest
    {
        public List<Instruction> InstructionList { get; set; }
    }
}

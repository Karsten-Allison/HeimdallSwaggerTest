using Heimdall.Logic.WorkInstructions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Logic
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// This lets your business logic decide what it makes available to dependency injection
    /// without mucking up the Program.cs file.
    /// </remarks>
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddHeimdallLogic(this IServiceCollection services)
        {
            services.AddScoped<IWorkInstructionLogic, WorkInstructionLogic>();

            return services;
        }
    }
}

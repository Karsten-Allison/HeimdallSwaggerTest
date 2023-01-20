using Heimdall.Data.Accessors;
using Heimdall.Logic.WorkInstructions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Data
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
        public static IServiceCollection AddHeimdallData(this IServiceCollection services)
        {
            services.AddScoped<IWorkInstructionAccessor, WorkInstructionAccessor>();

            return services;
        }
    }
}

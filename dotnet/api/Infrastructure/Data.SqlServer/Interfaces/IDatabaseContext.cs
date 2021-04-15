using AndcultureCode.CSharp.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Data.SqlServer.Interfaces
{
    /// <summary>
    /// Database specific context
    /// </summary>
    public interface IDatabaseContext : IContext
    {
        /// <summary>
        /// Provides access to database related information and operations for this context.
        /// /// </summary>
        /// <value></value>
        DatabaseFacade Database { get; }
    }
}

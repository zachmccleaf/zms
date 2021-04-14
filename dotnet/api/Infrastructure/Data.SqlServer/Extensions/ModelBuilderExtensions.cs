using Rws.Api.Infrastructure.Data.SqlServer.Maps;
using Microsoft.EntityFrameworkCore;
using AndcultureCode.CSharp.Core.Models;
using System.Linq.Expressions;
using System;
using AndcultureCode.CSharp.Extensions;

namespace Rws.Api.Infrastructure.Data.SqlServer.Extensions
{
    /// <summary>
    /// Extensions for Entity Framework ModelBuilder
    /// </summary>

    // TODO: This could be moved into the AndcultureCode.CSharp.Extensions project
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Add mapping for the given entity type
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builder"></param>
        /// <param name="map"></param>
        public static void AddMapping<TEntity>(this ModelBuilder builder, Map<TEntity> map)
            where TEntity : class
        {
            builder.Entity<TEntity>(map.Configure);
        }

        /// <summary>
        /// Adds a global query filter to prevent soft-deleted entities from repository results by
        /// default. Optionally, you can pass in an additional filter expression to be applied.
        ///
        /// As of right now, you can't call `HasQueryFilter()` multiple times - it will only take
        /// the last filter that it was called with. Once this functionality is implemented, we
        /// might want to revisit this extension method and remove the `additionalFilter` param.
        /// See https://github.com/dotnet/efcore/issues/10275
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="additionalFilter">(Optional) An additional filter expression to be chained
        /// with the 'DeletedOn' filter.</param>
        /// <typeparam name="TEntity"></typeparam>
        public static void AddSoftDeletionQueryFilter<TEntity>(this ModelBuilder builder, Expression<Func<TEntity, bool>> additionalFilter = null)
            where TEntity : Auditable
        {
            // Set up the base soft-deletion filter (determined by having a value in the 'DeletedOn' column)
            Expression<Func<TEntity, bool>> softDeletionFilter = (e) => EF.Property<DateTimeOffset?>(e, "DeletedOn") == null;

            // If an additional filter expression was provided, chain it on here. For now, we
            // probably only need to support AndAlso chains. Hopefully we aren't going too wild
            // in global query filter logic.
            if (additionalFilter != null)
            {
                softDeletionFilter = softDeletionFilter.AndAlso(additionalFilter);
            }

            builder.Entity<TEntity>().HasQueryFilter(softDeletionFilter);
        }
    }
}
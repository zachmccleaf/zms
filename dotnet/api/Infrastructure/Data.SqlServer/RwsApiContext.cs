using Rws.Api.Infrastructure.Data.SqlServer;
using Rws.Api.Business.Core.Interfaces.Data;
using Rws.Api.Business.Core.Utilities.Configuration;
using Microsoft.Extensions.Logging;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Rws.Api.Infrastructure.Data.SqlServer.Extensions;
using Data.SqlServer.Maps.ShopItems;
using Rws.Api.Core.Models.Entities;

namespace Rws.Api.Data.SqlServer
{
    public class RwsApiContext : Context, IRwsApiContext
    {
        #region Properties

        public DbSet<ShopItem> ShopItems { get; set; }

        #endregion Properties

        #region Constructor

        public RwsApiContext()
        : base(Configuration.GetConnectionString(), null)
        {
            // Uncomment for debugging purposes only
            // Console.WriteLine($"RwsApiContext () => {Configuration.GetConnectionString()}");
        }

        public RwsApiContext(string connectionString, ILoggerFactory loggerFactory)
        : base(connectionString, loggerFactory)
        {
            // Uncomment for debugging purposes only
            // Console.WriteLine($"RwsApiContext () => {Configuration.GetConnectionString()}");
        }

        public RwsApiContext(IConnection connection, ILoggerFactory loggerFactory)
            : base(connection.ToString(), loggerFactory)
        {
            // Uncomment for debugging purposes only
            // Console.WriteLine($"RwsApiContext (IConnection connection) => {connection.ToString()}");
        }

        #endregion Constructor

        #region IRwsApiContextImplementation

        IQueryable<ShopItem> IRwsApiContext.ShopItems => ShopItems;

        #endregion IRwsApiContextImplementation

        #region Public Methods

        public override void ConfigureMappings(ModelBuilder modelBuilder)
        {
            //Acls
            modelBuilder.AddMapping(new ShopItemMap());

            base.ConfigureMappings(modelBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddSoftDeletionQueryFilter<ShopItem>();

            base.OnModelCreating(modelBuilder);
        }

        #region Overrides of Context

        /// <summary>
        /// Generate the database structure by running the code-first migrations
        /// </summary>
        public override void CreateStructure() => Database.Migrate();

        /// <summary>
        /// Drops the configured database
        /// </summary>
        public override void DeleteDatabase() => Database.EnsureDeleted();

        /// <summary>
        /// Drop the database structure by reverting the code-first migrations
        /// </summary>
        public override void DropStructure()
        {
            var migrator = this.GetInfrastructure().GetRequiredService<IMigrator>();
            migrator.Migrate("0");
        }

        #endregion Overrides of Context

        #endregion Public Methods
    }
}

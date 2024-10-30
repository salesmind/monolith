using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace SalesMind.Infrastructure.Data;
#pragma warning disable EF1001 // Internal EF Core API usage.
internal class MultiTenancyMigrator : Migrator
#pragma warning restore EF1001 // Internal EF Core API usage.
{
    private readonly ICurrentDbContext _currentDbContext;
    private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;
    private readonly IRelationalCommandDiagnosticsLogger _commandLogger;
    public MultiTenancyMigrator(IMigrationsAssembly migrationsAssembly, IHistoryRepository historyRepository, IDatabaseCreator databaseCreator, IMigrationsSqlGenerator migrationsSqlGenerator, IRawSqlCommandBuilder rawSqlCommandBuilder, IMigrationCommandExecutor migrationCommandExecutor, IRelationalConnection connection, ISqlGenerationHelper sqlGenerationHelper, ICurrentDbContext currentContext, IModelRuntimeInitializer modelRuntimeInitializer, IDiagnosticsLogger<DbLoggerCategory.Migrations> logger, IRelationalCommandDiagnosticsLogger commandLogger, IDatabaseProvider databaseProvider)
#pragma warning disable EF1001 // Internal EF Core API usage.
        : base(migrationsAssembly, historyRepository, databaseCreator, migrationsSqlGenerator, rawSqlCommandBuilder, migrationCommandExecutor, connection, sqlGenerationHelper, currentContext, modelRuntimeInitializer, logger, commandLogger, databaseProvider)
#pragma warning restore EF1001 // Internal EF Core API usage.
    {
        _currentDbContext = currentContext;
        _rawSqlCommandBuilder = rawSqlCommandBuilder;
        _commandLogger = commandLogger;
    }

    protected override IReadOnlyList<MigrationCommand> GenerateDownSql(Migration migration, Migration previousMigration, MigrationsSqlGenerationOptions options = MigrationsSqlGenerationOptions.Default)
    {
#pragma warning disable EF1001 // Internal EF Core API usage.
        return PopulateSchemaSql(base.GenerateDownSql(migration, previousMigration, options));
#pragma warning restore EF1001 // Internal EF Core API usage.
    }
    protected override IReadOnlyList<MigrationCommand> GenerateUpSql(Migration migration, MigrationsSqlGenerationOptions options = MigrationsSqlGenerationOptions.Default)
    {
#pragma warning disable EF1001 // Internal EF Core API usage.
        return PopulateSchemaSql(base.GenerateUpSql(migration, options));
#pragma warning restore EF1001 // Internal EF Core API usage.
    }
    private IReadOnlyList<MigrationCommand> PopulateSchemaSql(IReadOnlyList<MigrationCommand> migrationCommands)
    {
        if (_currentDbContext.Context is TenantDbContext tenantDbContext)
        {
            var schemaSqlCommand = new MigrationCommand(_rawSqlCommandBuilder.Build($"set search_path to \"{tenantDbContext.Schema}\""), _currentDbContext.Context, _commandLogger);
            var newCommands = new List<MigrationCommand>()
            {
                schemaSqlCommand,
            };
            return newCommands.Concat(migrationCommands).ToList();
        }
        return migrationCommands;
    }
}

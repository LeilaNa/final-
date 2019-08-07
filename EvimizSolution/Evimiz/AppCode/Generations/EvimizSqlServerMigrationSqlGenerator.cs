using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace Evimiz
{
    public class EvimizSqlServerMigrationSqlGenerator: SqlServerMigrationSqlGenerator
    {

        protected override void Generate(AddColumnOperation operation)
        {
            SetColumnValue(operation.Column);

            base.Generate(operation);
        }

        protected override void Generate(AlterColumnOperation operation)
        {
            SetColumnValue(operation.Column);

            base.Generate(operation);
        }

        protected override void Generate(AlterTableOperation operation)
        {
            foreach (var column in operation.Columns)
                SetColumnValue(column);

            base.Generate(operation);
        }

        protected override void Generate(CreateTableOperation operation)
        {
            foreach (var column in operation.Columns)
                SetColumnValue(column);

            base.Generate(operation);
        }

        void SetColumnValue(ColumnModel column)
        {
            if (column.Annotations.TryGetValue("EvimizDatabaseGeneratedAttribute", out AnnotationValues EvimizDatabaseValue))
            {
                column.DefaultValueSql = (EvimizDatabaseValue.NewValue ?? "").ToString();
            }
            else if (column.Annotations.TryGetValue("EvimizSqlDefaultValueAttribute", out AnnotationValues EvimizSqlDefaultValue))
            {
                column.DefaultValueSql = (EvimizSqlDefaultValue.NewValue ?? "").ToString();
            }
        }
    }
}
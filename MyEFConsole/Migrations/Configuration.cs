namespace MyEFConsole.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyEFConsole.StudentDBContext>
    {
        public Configuration()
        {
            //是否使用自动迁移功能
            AutomaticMigrationsEnabled = false;
            //是否允许在迁移时允许数据丢失，如果设置未false,在可能发生数据丢失时，则引发异常
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MyEFConsole.StudentDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

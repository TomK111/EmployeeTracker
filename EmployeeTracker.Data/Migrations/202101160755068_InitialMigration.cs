namespace EmployeeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkInformation", "VacationDaysAccruedTotal", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "VacationDaysUsedTotal", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "PersonalDaysAccruedTotal", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "PersonalDaysUsedTotal", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "SickDaysAccruedTotal", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "SickDaysUsedTotal", c => c.Double(nullable: false));
            DropColumn("dbo.WorkInformation", "VacationDaysAccruedLifetime");
            DropColumn("dbo.WorkInformation", "VacationDaysUsedLifetime");
            DropColumn("dbo.WorkInformation", "PersonalDaysAccruedLifetime");
            DropColumn("dbo.WorkInformation", "PersonalDaysUsedLifetime");
            DropColumn("dbo.WorkInformation", "SickDaysAccruedLifetime");
            DropColumn("dbo.WorkInformation", "SickDaysUsedLifetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkInformation", "SickDaysUsedLifetime", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "SickDaysAccruedLifetime", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "PersonalDaysUsedLifetime", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "PersonalDaysAccruedLifetime", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "VacationDaysUsedLifetime", c => c.Double(nullable: false));
            AddColumn("dbo.WorkInformation", "VacationDaysAccruedLifetime", c => c.Double(nullable: false));
            DropColumn("dbo.WorkInformation", "SickDaysUsedTotal");
            DropColumn("dbo.WorkInformation", "SickDaysAccruedTotal");
            DropColumn("dbo.WorkInformation", "PersonalDaysUsedTotal");
            DropColumn("dbo.WorkInformation", "PersonalDaysAccruedTotal");
            DropColumn("dbo.WorkInformation", "VacationDaysUsedTotal");
            DropColumn("dbo.WorkInformation", "VacationDaysAccruedTotal");
        }
    }
}

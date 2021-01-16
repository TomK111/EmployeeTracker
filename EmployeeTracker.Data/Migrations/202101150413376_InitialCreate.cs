namespace EmployeeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleName = c.String(),
                        SocialSecurityNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        DateOfHire = c.DateTimeOffset(nullable: false, precision: 7),
                        DateOfTermination = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        EmployeeCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionTitle = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsSupervisor = c.Boolean(nullable: false),
                        IsDirector = c.Boolean(nullable: false),
                        IsExecutive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.WorkInformation",
                c => new
                    {
                        WorkInformationId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        ContactId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        Wage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasBenefits = c.Boolean(nullable: false),
                        StartOfBenefits = c.DateTimeOffset(precision: 7),
                        WorkEmail = c.String(),
                        LastReview = c.DateTimeOffset(precision: 7),
                        NextReview = c.DateTimeOffset(precision: 7),
                        VacationDaysAccruedLifetime = c.Double(nullable: false),
                        VacationDaysUsedLifetime = c.Double(nullable: false),
                        VacationDaysAccruedForPeriod = c.Double(nullable: false),
                        VacationDaysUsedForPeriod = c.Double(nullable: false),
                        PersonalDaysAccruedLifetime = c.Double(nullable: false),
                        PersonalDaysUsedLifetime = c.Double(nullable: false),
                        PersonalDaysAccruedForPeriod = c.Double(nullable: false),
                        PersonalDaysUsedForPeriod = c.Double(nullable: false),
                        SickDaysAccruedLifetime = c.Double(nullable: false),
                        SickDaysUsedLifetime = c.Double(nullable: false),
                        SickDaysAccruedForPeriod = c.Double(nullable: false),
                        SickDaysUsedForPeriod = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.WorkInformationId)
                .ForeignKey("dbo.Contact", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Position", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ContactId)
                .Index(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkInformation", "PositionId", "dbo.Position");
            DropForeignKey("dbo.WorkInformation", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.WorkInformation", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Position", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Contact", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.WorkInformation", new[] { "PositionId" });
            DropIndex("dbo.WorkInformation", new[] { "ContactId" });
            DropIndex("dbo.WorkInformation", new[] { "EmployeeId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Position", new[] { "DepartmentId" });
            DropIndex("dbo.Contact", new[] { "EmployeeId" });
            DropTable("dbo.WorkInformation");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Position");
            DropTable("dbo.Department");
            DropTable("dbo.Employee");
            DropTable("dbo.Contact");
        }
    }
}

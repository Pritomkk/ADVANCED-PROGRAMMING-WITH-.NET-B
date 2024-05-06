namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 20),
                        email = c.String(nullable: false, maxLength: 20),
                        password = c.String(nullable: false, maxLength: 20),
                        date = c.String(nullable: false, maxLength: 20),
                        phone = c.String(nullable: false, maxLength: 20),
                        gender = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        AppointmentDate = c.String(nullable: false, maxLength: 20),
                        AppointmentTime = c.String(nullable: false, maxLength: 20),
                        AppointmentStatus = c.String(nullable: false, maxLength: 20),
                        PaitentAppointmentSerial = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .ForeignKey("dbo.doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Gender = c.String(nullable: false, maxLength: 20),
                        MaxCheckUpPatient = c.Int(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete:false)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        email = c.String(),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.doctors");
            DropForeignKey("dbo.doctors", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.Appointments", "AdminId", "dbo.Admins");
            DropIndex("dbo.Tokens", new[] { "AdminId" });
            DropIndex("dbo.doctors", new[] { "AdminId" });
            DropIndex("dbo.Appointments", new[] { "AdminId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.doctors");
            DropTable("dbo.Appointments");
            DropTable("dbo.Admins");
        }
    }
}

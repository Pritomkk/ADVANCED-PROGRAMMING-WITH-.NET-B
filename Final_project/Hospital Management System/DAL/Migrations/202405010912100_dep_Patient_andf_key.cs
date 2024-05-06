namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dep_Patient_andf_key : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepId = c.Int(nullable: false, identity: true),
                        DepName = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepId)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete:false)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        AdmissionDate = c.DateTime(),
                        DischargeDate = c.DateTime(),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Status = c.String(nullable: false, maxLength: 20),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete:false)
                .Index(t => t.AdminId);
            
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.doctors", "DepId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "PatientId");
            CreateIndex("dbo.doctors", "DepId");
            AddForeignKey("dbo.doctors", "DepId", "dbo.Departments", "DepId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "AdminId", "dbo.Admins");
            DropForeignKey("dbo.doctors", "DepId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "AdminId", "dbo.Admins");
            DropIndex("dbo.Patients", new[] { "AdminId" });
            DropIndex("dbo.Departments", new[] { "AdminId" });
            DropIndex("dbo.doctors", new[] { "DepId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropColumn("dbo.doctors", "DepId");
            DropColumn("dbo.Appointments", "PatientId");
            DropTable("dbo.Patients");
            DropTable("dbo.Departments");
        }
    }
}

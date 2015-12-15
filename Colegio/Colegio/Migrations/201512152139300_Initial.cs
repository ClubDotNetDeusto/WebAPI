namespace Colegio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Pulseras",
                c => new
                    {
                        PulseraID = c.Int(nullable: false, identity: true),
                        PulseraName = c.String(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.PulseraID)
                .ForeignKey("dbo.Student", t => t.Student_StudentID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_SubjectID = c.Int(nullable: false),
                        Student_StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_SubjectID, t.Student_StudentID })
                .ForeignKey("dbo.subjects", t => t.Subject_SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_StudentID, cascadeDelete: true)
                .Index(t => t.Subject_SubjectID)
                .Index(t => t.Student_StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "StudentId", "dbo.Student");
            DropForeignKey("dbo.SubjectStudents", "Student_StudentID", "dbo.Student");
            DropForeignKey("dbo.SubjectStudents", "Subject_SubjectID", "dbo.subjects");
            DropForeignKey("dbo.Pulseras", "Student_StudentID", "dbo.Student");
            DropIndex("dbo.SubjectStudents", new[] { "Student_StudentID" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Pulseras", new[] { "Student_StudentID" });
            DropIndex("dbo.Addresses", new[] { "StudentId" });
            DropTable("dbo.SubjectStudents");
            DropTable("dbo.subjects");
            DropTable("dbo.Pulseras");
            DropTable("dbo.Student");
            DropTable("dbo.Addresses");
        }
    }
}

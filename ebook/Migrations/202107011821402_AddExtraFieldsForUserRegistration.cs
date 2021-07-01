namespace ebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExtraFieldsForUserRegistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Dob", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserCategory", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserId");
            DropColumn("dbo.AspNetUsers", "UserCategory");
            DropColumn("dbo.AspNetUsers", "ContactNumber");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Dob");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}

namespace ebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookModel3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                {
                    BookId = c.Guid(nullable: false, defaultValueSql: "newid()"),
                    BookName = c.String(nullable: false),
                    BookCode = c.String(nullable: false),
                    BookDescription = c.String(nullable: false),
                    Author = c.String(nullable: false),
                    Category = c.Int(nullable: false),
                    Type = c.Int(nullable: false),
                    Option = c.Int(nullable: false),
                    Rate = c.Single(nullable: false),
                    Discount = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.BookId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}

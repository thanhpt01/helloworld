namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAttachments",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 32),
                        Name = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAttachments");
        }
    }
}

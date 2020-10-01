namespace TeamComeback_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedback1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Answer = c.Int(),
                        Comment = c.String(maxLength: 500),
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}

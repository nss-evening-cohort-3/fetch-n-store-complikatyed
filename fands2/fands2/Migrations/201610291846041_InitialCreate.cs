namespace fands2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponseModels",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        RequestedMethod = c.String(),
                        RequestedUrl = c.String(),
                        ResponseCode = c.String(),
                        ResponseTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResponseModels");
        }
    }
}

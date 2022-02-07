namespace finalassignmnet2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        gender = c.String(),
                        mobile = c.String(),
                    })
                .PrimaryKey(t => t.email);
            
            CreateTable(
                "dbo.logins",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.logins");
            DropTable("dbo.Details");
        }
    }
}

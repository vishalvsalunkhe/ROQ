namespace ROQ.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ROQDbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogActions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ObjectType = c.String(),
                        MethodName = c.String(),
                        RecordType = c.String(),
                        RecordMessage = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LogExceptions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ErrorMsg = c.String(),
                        Method = c.String(),
                        StackStrace = c.String(),
                        UserId = c.String(),
                        ErrorDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        QID = c.String(),
                        UserName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Domain = c.String(),
                        ArabicName = c.String(),
                        EnglistName = c.String(),
                        EmailID = c.String(),
                        MobileNo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.LogExceptions");
            DropTable("dbo.LogActions");
        }
    }
}

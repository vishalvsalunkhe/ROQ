namespace ROQ.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NwTblLogActionLogExceptionUsers : DbMigration
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
                        EmpNo = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Gender = c.String(),
                        EmailID = c.String(),
                        MobileNo = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(),
                        IsPasswordReset = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(),
                        CreationDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
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

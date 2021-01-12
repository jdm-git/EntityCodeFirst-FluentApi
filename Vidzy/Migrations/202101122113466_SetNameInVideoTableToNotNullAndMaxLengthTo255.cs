namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameInVideoTableToNotNullAndMaxLengthTo255 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Videos", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "Name", c => c.String());
        }
    }
}

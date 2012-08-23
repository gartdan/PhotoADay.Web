namespace PhotoADay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContentLengthFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "ContentLength", c => c.Long(nullable: false));
            AddColumn("dbo.Photos", "ContentType", c => c.String());
            AddColumn("dbo.Photos", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "FileName");
            DropColumn("dbo.Photos", "ContentType");
            DropColumn("dbo.Photos", "ContentLength");
        }
    }
}

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipName='Pay as you Go' where Id = 1");
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipName='Monthly' where Id = 2");
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipName='Quaterly' where Id = 3");
            Sql("UPDATE MEMBERSHIPTYPES SET MembershipName='Yearly' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}

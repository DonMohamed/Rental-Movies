namespace Vidlly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'22716d25-1c84-41ea-9368-728c6813c329', N'Admin@Vidlly.com', 0, N'AAqfFxqGFr/0iS0NtmplqN79FYUuqx5wZipEtKAwxYluthzSrNoeJLLxXDfTHP5i4A==', N'a06d2087-731c-481c-b06d-56e63d9248e3', NULL, 0, 0, NULL, 1, 0, N'Admin@Vidlly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b782e94d-a75e-42d3-89f3-eae80b85af59', N'Guest@Vidlly.com', 0, N'AJnu45+x8TSnAhy9lau2vKfL8FoEowxFsgEYfWeeuRV/VF23dkkVuiCUpyJK5dDuIw==', N'9813d41f-76de-4591-a977-6b6431f4b57d', NULL, 0, 0, NULL, 1, 0, N'Guest@Vidlly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'84cfd819-faaf-4043-afeb-42b12d60a3de', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22716d25-1c84-41ea-9368-728c6813c329', N'84cfd819-faaf-4043-afeb-42b12d60a3de')



            ");
        }
        
        public override void Down()
        {
        }
    }
}

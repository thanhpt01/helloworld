https://stackoverflow.com/questions/27958793/add-new-table-to-an-existing-database-using-code-first-approach-in-ef-6-and-mvc
What has happened here is that you had existing database tables before Migrations where enabled. 
So Entity Framework thinks that ALL your database objects need to created, this could be seen by opening up your PostMigration migration file.
The best way is to trick EF into to doing the initial migration with every before you added the Post table and then do the Posts migration after.

Steps
1. Comment out the Posts in the DBContext so EF doesn't know about posts
//public DbSet<Post> Posts { get; set; }

2. Enable Migrations
Enable-Migrations
Khi RUN "Enable-Migrations" phải đảm bảo DbContext đang giống với Database đã tạo.

3. Add an initial migration with all tables prior to your changes
Add-Migration "InitialBaseline" –IgnoreChanges

4. Now update the database, this will create a MigrationHistory table so that EF knows what migrations have been run.
Update-Database

5. Now you can uncomment the line in 1 to "Do your change"
6. Create a new migration with the addition of Posts
Add-Migration "PostMigration"

7. Now do an update... and hopefully it should all work.
Update-Database

Now that migrations are all setup and they are baselined future migrations will be easy.
For more information I found this link useful: http://msdn.microsoft.com/en-us/data/dn579398.aspx

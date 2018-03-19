namespace TaskManager.Models.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyMainDBModel : DbContext
    {
        // Your context has been configured to use a 'MyMainDBModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TaskManager.Models.DBModel.MyMainDBModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyMainDBModel' 
        // connection string in the application configuration file.
        public MyMainDBModel()
            : base("name=MyMainDBModel")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
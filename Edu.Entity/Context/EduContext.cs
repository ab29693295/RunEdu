namespace Edu.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EduContext : DbContext
    {
        public EduContext()
            : base("name=EduContext")
        {
        }
   
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<LogInfo> LogInfo { get; set; }
        public virtual DbSet<TeamUser> TeamUser { get; set; }
        public virtual DbSet<Running> Running { get; set; }
        public virtual DbSet<RunPoint> RunPoint { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

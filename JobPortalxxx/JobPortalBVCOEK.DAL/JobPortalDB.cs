namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JobPortalDB : DbContext
    {
        public JobPortalDB()
            : base("name=JobPortalDB")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<EmpProfile> EmpProfiles { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<job_applied> job_applied { get; set; }
        public virtual DbSet<Jobpost> Jobposts { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.Groups)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("ApplicationRoleGroups").MapLeftKey("RoleId").MapRightKey("GroupId"));

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.EmpProfiles)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.ApplicationUserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Profiles)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.ApplicationUserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Groups)
                .WithMany(e => e.AspNetUsers)
                .Map(m => m.ToTable("ApplicationUserGroups").MapLeftKey("UserId").MapRightKey("GroupId"));

            modelBuilder.Entity<EmpProfile>()
                .HasMany(e => e.Jobposts)
                .WithOptional(e => e.EmpProfile)
                .HasForeignKey(e => e.EmpProfile_UserId);

            modelBuilder.Entity<EmpProfile>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.EmpProfile)
                .HasForeignKey(e => e.EmpProfile_UserId);

            modelBuilder.Entity<job_applied>()
                .HasMany(e => e.Jobposts)
                .WithOptional(e => e.job_applied)
                .HasForeignKey(e => e.Job_Applied_Id);

            modelBuilder.Entity<job_applied>()
                .HasMany(e => e.Profiles)
                .WithOptional(e => e.job_applied)
                .HasForeignKey(e => e.job_applied_Id);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Jobposts)
                .WithOptional(e => e.Profile)
                .HasForeignKey(e => e.Profile_UserId);

            modelBuilder.Entity<Profile>()
                .HasMany(e => e.Notifications)
                .WithOptional(e => e.Profile)
                .HasForeignKey(e => e.Profile_UserId);
        }
    }
}

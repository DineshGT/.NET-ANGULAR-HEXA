using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAppDAL.Models
{
    public class EventDBContext:DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<SpeakersDetails> SpeakersDetails { get; set; }
        public DbSet<SessionInfo> SessionInfos { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEventDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To configure a connection string
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Check constraint for UserInfo.Role
            modelBuilder.Entity<UserInfo>().HasCheckConstraint("CK_UserInfo_Role", "[Role] IN ('Admin', 'Participant')");

            // Check constraint for EventDetails.Status
            modelBuilder.Entity<EventDetails>().HasCheckConstraint("CK_EventDetails_Status", "[Status] IN ('Active', 'In-Active')");

            // Check constraint for ParticipantEventDetails.IsAttended
            modelBuilder.Entity<ParticipantEventDetails>().HasCheckConstraint("CK_ParticipantEventDetails_IsAttended", "[IsAttended] IN ('Yes', 'No')");

            // Configure relationships
            modelBuilder.Entity<SessionInfo>().HasOne(s => s.EventDetails).WithMany().HasForeignKey(s => s.EventId);

            modelBuilder.Entity<SessionInfo>().HasOne(s => s.SpeakersDetails).WithMany().HasForeignKey(s => s.SpeakerId);

            modelBuilder.Entity<ParticipantEventDetails>().HasOne(p => p.UserInfo).WithMany().HasForeignKey(p => p.ParticipantEmailId);

            modelBuilder.Entity<ParticipantEventDetails>().HasOne(p => p.EventDetails).WithMany().HasForeignKey(p => p.EventId);
        }

    }
}

using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ActivityAttendee>(x =>
            x.HasKey(aa => new { aa.AppUserId, aa.ActivityId }));
        builder.Entity<ActivityAttendee>()
            .HasOne(aa => aa.AppUser)
            .WithMany(au => au.Activities)
            .HasForeignKey(aa => aa.AppUserId);
        builder.Entity<ActivityAttendee>()
            .HasOne(aa => aa.Activity)
            .WithMany(a => a.Attendees)
            .HasForeignKey(aa => aa.ActivityId);

        builder.Entity<Comment>()
            .HasOne(a => a.Activity)
            .WithMany(c => c.Comments)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<UserFollowing>(b =>
        {
            b.HasKey(k => new { k.ObserverId, k.TargetId });

            b.HasOne(o => o.Observer)
                .WithMany(f => f.Followings)
                .HasForeignKey(o => o.ObserverId)
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(t => t.Target)
                .WithMany(f => f.Followers)
                .HasForeignKey(t => t.TargetId)
                .OnDelete(DeleteBehavior.Cascade);
        });        
    }

    public DbSet<ActivityAttendee> ActivityAttendees { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Comment> Comments { get; set; }
     public DbSet<UserFollowing> UserFollowings { get; set; }
}
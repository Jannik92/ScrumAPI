using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataModell))]
    partial class DataModellModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("OwnerId");

                    b.Property<int>("SprintId");

                    b.Property<string>("Title");

                    b.Property<int>("estimatedEffort");

                    b.Property<int>("realEffort");

                    b.HasKey("ItemId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("SprintId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("WebApplication1.Models.MemberTeam", b =>
                {
                    b.Property<int>("MemberId");

                    b.Property<int>("TeamId");

                    b.HasKey("MemberId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("MemberTeams");
                });

            modelBuilder.Entity("WebApplication1.Models.Sprint", b =>
                {
                    b.Property<int>("SprintId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MasterId");

                    b.Property<int>("TeamId");

                    b.Property<string>("Title");

                    b.HasKey("SprintId");

                    b.HasIndex("MasterId");

                    b.HasIndex("TeamId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("WebApplication1.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WebApplication1.Models.Item", b =>
                {
                    b.HasOne("WebApplication1.Models.Member", "Owner")
                        .WithMany("AssignedItems")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.Sprint", "Sprint")
                        .WithMany("Items")
                        .HasForeignKey("SprintId");
                });

            modelBuilder.Entity("WebApplication1.Models.MemberTeam", b =>
                {
                    b.HasOne("WebApplication1.Models.Member", "Member")
                        .WithMany("MemberTeams")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.Team", "Team")
                        .WithMany("MemberTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.Sprint", b =>
                {
                    b.HasOne("WebApplication1.Models.Member", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

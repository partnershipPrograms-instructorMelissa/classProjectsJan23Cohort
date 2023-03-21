﻿// <auto-generated />
using System;
using DevsHelpingDevs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevsHelpingDevs.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DevsHelpingDevs.Models.DevSkill", b =>
                {
                    b.Property<int>("DevSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DevSkillId");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("DevSkills");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OrgId")
                        .HasColumnType("int");

                    b.Property<string>("Pay")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("JobId");

                    b.HasIndex("OrgId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.JobSkill", b =>
                {
                    b.Property<int>("JobSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("jobSkillSkillId")
                        .HasColumnType("int");

                    b.HasKey("JobSkillId");

                    b.HasIndex("JobId");

                    b.HasIndex("jobSkillSkillId");

                    b.ToTable("JobSkills");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Org", b =>
                {
                    b.Property<int>("OrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrgId");

                    b.HasIndex("UserId");

                    b.ToTable("Orgs");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.OrgKey", b =>
                {
                    b.Property<int>("OrgKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastUsed")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrgKeyId");

                    b.ToTable("OrgKeys");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.OrgProfile", b =>
                {
                    b.Property<int>("OrgProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OrgId")
                        .HasColumnType("int");

                    b.Property<string>("OrgOwner")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrgProfileId");

                    b.HasIndex("OrgId")
                        .IsUnique();

                    b.ToTable("OrgProfiles");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.PassKey", b =>
                {
                    b.Property<int>("PassKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastUsed")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PassKeyId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PassKeys");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Topic")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("forumTopicTopicId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.HasIndex("forumTopicTopicId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Post")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("forumPostPostId")
                        .HasColumnType("int");

                    b.HasKey("ReplyId");

                    b.HasIndex("UserId");

                    b.HasIndex("forumPostPostId");

                    b.ToTable("Replys");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OrgTopic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Visibility")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastLogged")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastPage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.UserProfile", b =>
                {
                    b.Property<int>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Github")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.DevSkill", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.Skill", "mySkill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevsHelpingDevs.Models.User", "theUser")
                        .WithMany("mySkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("mySkill");

                    b.Navigation("theUser");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Job", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.Org", "orgPoster")
                        .WithMany("ourJobs")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("orgPoster");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.JobSkill", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.Job", "theJob")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevsHelpingDevs.Models.Skill", "jobSkill")
                        .WithMany()
                        .HasForeignKey("jobSkillSkillId");

                    b.Navigation("jobSkill");

                    b.Navigation("theJob");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Org", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.User", "owner")
                        .WithMany("createdOrgs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("owner");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.OrgProfile", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.Org", "myOrg")
                        .WithOne("myProfile")
                        .HasForeignKey("DevsHelpingDevs.Models.OrgProfile", "OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("myOrg");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.PassKey", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.User", "userPass")
                        .WithOne("myPassKey")
                        .HasForeignKey("DevsHelpingDevs.Models.PassKey", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userPass");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Post", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.User", "poster")
                        .WithMany("myPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevsHelpingDevs.Models.Topic", "forumTopic")
                        .WithMany("topicPosts")
                        .HasForeignKey("forumTopicTopicId");

                    b.Navigation("forumTopic");

                    b.Navigation("poster");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Reply", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.User", "replier")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevsHelpingDevs.Models.Post", "forumPost")
                        .WithMany("postReplies")
                        .HasForeignKey("forumPostPostId");

                    b.Navigation("forumPost");

                    b.Navigation("replier");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Topic", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.User", "topicOwner")
                        .WithMany("myTopics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("topicOwner");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.UserProfile", b =>
                {
                    b.HasOne("DevsHelpingDevs.Models.User", "myUser")
                        .WithOne("myProfile")
                        .HasForeignKey("DevsHelpingDevs.Models.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("myUser");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Org", b =>
                {
                    b.Navigation("myProfile");

                    b.Navigation("ourJobs");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Post", b =>
                {
                    b.Navigation("postReplies");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.Topic", b =>
                {
                    b.Navigation("topicPosts");
                });

            modelBuilder.Entity("DevsHelpingDevs.Models.User", b =>
                {
                    b.Navigation("createdOrgs");

                    b.Navigation("myPassKey");

                    b.Navigation("myPosts");

                    b.Navigation("myProfile");

                    b.Navigation("mySkills");

                    b.Navigation("myTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
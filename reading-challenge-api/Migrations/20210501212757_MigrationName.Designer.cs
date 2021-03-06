// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadingChallengeApi;

namespace ReadingChallengeApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210501212757_MigrationName")]
    partial class MigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ReadingChallengeApi.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AmazonLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ReadingChallengeApi.Prompt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PromptBookId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PromptBookId");

                    b.ToTable("Prompts");
                });

            modelBuilder.Entity("ReadingChallengeApi.PromptBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookReadId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateRead")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookReadId");

                    b.ToTable("PromptBooks");
                });

            modelBuilder.Entity("ReadingChallengeApi.Prompt", b =>
                {
                    b.HasOne("ReadingChallengeApi.PromptBook", null)
                        .WithMany("Prompts")
                        .HasForeignKey("PromptBookId");
                });

            modelBuilder.Entity("ReadingChallengeApi.PromptBook", b =>
                {
                    b.HasOne("ReadingChallengeApi.Book", "BookRead")
                        .WithMany()
                        .HasForeignKey("BookReadId");

                    b.Navigation("BookRead");
                });

            modelBuilder.Entity("ReadingChallengeApi.PromptBook", b =>
                {
                    b.Navigation("Prompts");
                });
#pragma warning restore 612, 618
        }
    }
}

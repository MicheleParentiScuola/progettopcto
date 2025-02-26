using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using progettopcto.Data;
using System;

namespace progettopcto.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("progettopcto.Data.Author", b =>
            {
                b.Property<string>("CF")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Surname")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CF");

                b.ToTable("Authors");
            });

            modelBuilder.Entity("progettopcto.Data.Book", b =>
            {
                b.Property<int>("ISBN")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:Identity", "1, 1");

                b.Property<string>("AuthorCF")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("Genre")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("ISBN");

                b.HasIndex("AuthorCF");

                b.ToTable("Books");
            });

            modelBuilder.Entity("progettopcto.Data.Loan", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:Identity", "1, 1");

                b.Property<int>("BookISBN")
                    .HasColumnType("int");

                b.Property<DateTime>("EndDate")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("StartDate")
                    .HasColumnType("datetime2");

                b.Property<string>("UserCF")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("BookISBN");

                b.HasIndex("UserCF");

                b.ToTable("Loans");
            });

            modelBuilder.Entity("progettopcto.Data.User", b =>
            {
                b.Property<string>("CF")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("Address")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Surname")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CF");

                b.ToTable("Users");
            });

            modelBuilder.Entity("progettopcto.Data.Book", b =>
            {
                b.HasOne("progettopcto.Data.Author", "Author")
                    .WithMany("Books")
                    .HasForeignKey("AuthorCF")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Author");
            });

            modelBuilder.Entity("progettopcto.Data.Loan", b =>
            {
                b.HasOne("progettopcto.Data.Book", "Book")
                    .WithMany("Loans")
                    .HasForeignKey("BookISBN")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("progettopcto.Data.User", "User")
                    .WithMany("Loans")
                    .HasForeignKey("UserCF")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Book");

                b.Navigation("User");
            });

            modelBuilder.Entity("progettopcto.Data.Author", b =>
            {
                b.Navigation("Books");
            });

            modelBuilder.Entity("progettopcto.Data.Book", b =>
            {
                b.Navigation("Loans");
            });

            modelBuilder.Entity("progettopcto.Data.User", b =>
            {
                b.Navigation("Loans");
            });
        }
    }
}

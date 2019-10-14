﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyShrike_API.Persistence;

namespace SurveyShrike_API.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("SurveyShrike_API.Domain.Entities.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("SurveyShrike_API.Application.Interfaces.IApplicationDBContext.Surveys");
                });

            modelBuilder.Entity("SurveyShrike_API.Domain.Entities.SurveyFormField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormConfiguration")
                        .IsRequired()
                        .HasColumnType("nText");

                    b.Property<int>("FormTypes")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("SurveyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyFormFields");
                });

            modelBuilder.Entity("SurveyShrike_API.Domain.Entities.SurveyResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReportedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReportedIP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("nText");

                    b.Property<int?>("SurveyFormFieldId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SurveyFormFieldId");

                    b.ToTable("SurveyShrike_API.Application.Interfaces.IApplicationDBContext.SurveyResponses");
                });

            modelBuilder.Entity("SurveyShrike_API.Domain.Entities.SurveyFormField", b =>
                {
                    b.HasOne("SurveyShrike_API.Domain.Entities.Survey", "Survey")
                        .WithMany("SurveyForms")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("SurveyShrike_API.Domain.Entities.SurveyResponse", b =>
                {
                    b.HasOne("SurveyShrike_API.Domain.Entities.SurveyFormField", "SurveyFormField")
                        .WithMany("SurveyResponses")
                        .HasForeignKey("SurveyFormFieldId");
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyShrike_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// @author Ankit
/// @date - 10/14/2019 3:22:11 PM 
/// </summary>
namespace SurveyShrike_API.Persistence.Configuration
{
    /// <summary>
    /// Database configuration for the Entity - Survey
    /// <seealso cref="SurveyShrike_API.Domain.Entities.Survey">
    /// </summary>
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ModifiedBy).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.isDeleted).HasDefaultValue(false);
            builder.HasMany(c => c.SurveyForms)
                      .WithOne(e => e.Survey);

        }
    }
}

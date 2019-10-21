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
    /// Database configuration for the Entity - Survey form fields
    /// <seealso cref="SurveyShrike_API.Domain.Entities.SurveyFormField">
    /// </summary>
    public class SurveyFormFieldsConfiguration : IEntityTypeConfiguration<SurveyFormField>
    {
        public void Configure(EntityTypeBuilder<SurveyFormField> builder)
        {

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(e => e.FormConfiguration)
             .IsRequired().HasColumnType("nText");

            builder.HasOne(c => c.Survey)
                        .WithMany(e => e.SurveyForms);

            builder.HasMany(c => c.SurveyResponses)
                      .WithOne(e => e.SurveyFormField);
        }
    }
}

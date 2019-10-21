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
    /// <seealso cref="SurveyShrike_API.Domain.Entities.SurveyResponse">
    /// </summary>
    public class SurveyResponsesConfiguration : IEntityTypeConfiguration<SurveyResponse>
    {
        public void Configure(EntityTypeBuilder<SurveyResponse> builder)
        {

            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.ReportedAt)
                .IsRequired();


            builder.Property(e => e.ReportedIP)
                .IsRequired();

            builder.Property(e => e.Response)
             .IsRequired().HasColumnType("nText");

            builder.HasOne(c => c.SurveyFormField)
                        .WithMany(e => e.SurveyResponses);
        }
    }
  
}

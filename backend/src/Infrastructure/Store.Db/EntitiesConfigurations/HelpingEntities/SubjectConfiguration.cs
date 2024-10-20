﻿using Domain.HelpingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Db.EntitiesConfigurations.HelpingEntities;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subjects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(Subject.NameMaxLength)
            .IsRequired();

        builder.HasData(SubjectHelper.GetSubjects());
    }
}

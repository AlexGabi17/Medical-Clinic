using API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Configurations
{
    public class DiagnosticConfiguration : IEntityTypeConfiguration<Diagnostic>
    {
        public void Configure(EntityTypeBuilder<Diagnostic> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Observations)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
        }
    }
}

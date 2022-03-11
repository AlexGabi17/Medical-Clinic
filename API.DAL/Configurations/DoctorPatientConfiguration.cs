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
    public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> builder)
        {
            builder.HasOne(p => p.Doctor)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(p => p.DoctorId);

            builder.HasOne(p => p.Patient)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(p => p.PatientId);
        }
    }
}

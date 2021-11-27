using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSoftware.Data.Configurations
{
    public class AplikantConfiguration : IEntityTypeConfiguration<Aplikant>
    {
        public void Configure(EntityTypeBuilder<Aplikant> builder)
        {
            builder
                .HasKey(m => m.ID);

            builder
                .Property(m => m.Email)
                .IsRequired();

            builder
               .Property(m => m.Lozinka)
               .IsRequired();

            builder
                .Property(m => m.Ime)
                .IsRequired();

            builder
                .Property(m => m.Prezime)
                .IsRequired();

            builder
                .Property(m => m.BrojTelefona)
                .IsRequired();

            builder
               .Property(m => m.MjestoRodjenja)
               .IsRequired();

            builder
               .Property(m => m.DatumRodjenja)
               .IsRequired();

            builder
               .Property(m => m.Adresa)
               .IsRequired();

            builder
                .Property(m => m.JeVerifikovan)
                .IsRequired();

            builder
               .Property(m => m.StatusZaposlenja)
               .IsRequired();

            builder
               .Property(m => m.LokacijaZaposlenja)
               .IsRequired();

            builder
               .Property(m => m.TrenutnaPozicija)
               .IsRequired();


        }
    }
}

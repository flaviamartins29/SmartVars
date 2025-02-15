using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartVars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVars.Infra.Data.Context.Mapping
{
    public class BuildingVarsMap : IEntityTypeConfiguration<BuildingVars>
    {
        public void Configure(EntityTypeBuilder<BuildingVars> builder)
        {
            builder.ToTable("SmartVars_Data");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder.Property(c => c.MyInt)
                .HasColumnName("MyInt");

            builder.Property(c => c.MyString)
                .HasColumnName("MyString");

            builder.Property(c => c.ThisMy)
                .HasColumnName("ThisMy");

            builder.Property(c => c.MyDouble)
                .HasColumnName("MyDouble");

            builder.Property(c => c.MyDecimal)
                .HasColumnName("MyDecimal");

            builder.Property(c => c.MyDateTime)
                .HasColumnName("MyDateTime");


        }
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.ModelMaps
{
    public class FeedbackStatusMap : IEntityTypeConfiguration<FeedbackStatus>
    {
        public void Configure(EntityTypeBuilder<FeedbackStatus> builder)
        {
            builder.ToTable("feedback_status");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_feedback_status");
            builder.Property(e => e.Description).HasColumnName("description");
        }
    }
}

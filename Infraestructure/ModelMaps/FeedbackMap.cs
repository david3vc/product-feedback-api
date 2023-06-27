using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infraestructure.ModelMaps
{
    public class FeedbackMap : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("feedback");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_feedback");
            builder.Property(e => e.Title).HasColumnName("title");
            builder.Property(e => e.Detail).HasColumnName("detail");
            builder.Property(e => e.CountVotes).HasColumnName("count_votes");
            builder.Property(e => e.IdCategory).HasColumnName("id_category");
            builder.Property(e => e.IdFeedbackStatus).HasColumnName("id_feedback_status");
            builder.Property(e => e.Status).HasColumnName("status");

            builder.HasOne(f => f.Category).WithMany(g => g.Feedbacks).HasForeignKey(f => f.IdCategory);
            builder.HasOne(f => f.FeedbackStatus).WithMany(g => g.Feedbacks).HasForeignKey(f => f.IdFeedbackStatus);
        }
    }
}

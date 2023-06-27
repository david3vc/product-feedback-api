using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.ModelMaps
{
    internal class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comment");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_comment");
            builder.Property(e => e.Detail).HasColumnName("detail");
            builder.Property(e => e.IdCommentParent).HasColumnName("id_comment_parent");
            builder.Property(e => e.IdFeedback).HasColumnName("id_feedback");

            builder.HasOne(f => f.Feedback).WithMany(g => g.Comments).HasForeignKey(f => f.IdFeedback);
            builder.HasOne(f => f.CommentParent).WithMany(g => g.Replys).HasForeignKey(f => f.IdCommentParent);
        }
    }
}

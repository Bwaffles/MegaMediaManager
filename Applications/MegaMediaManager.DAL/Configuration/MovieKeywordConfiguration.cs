using MegaMediaManager.Model;
using System.Data.Entity.ModelConfiguration;
using System;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class MovieKeywordConfiguration : EntityTypeConfiguration<MovieKeyword>
    {
        public MovieKeywordConfiguration()
        {
            this.ToTable("movie_keyword_t");

            Property(a => a.KeywordId).HasColumnName("keyword_id");
            Property(a => a.MovieId).HasColumnName("movie_id");
            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

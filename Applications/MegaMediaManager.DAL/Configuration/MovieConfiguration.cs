using System.Data.Entity.ModelConfiguration;
using MegaMediaManager.Model;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.DAL.TypeConfiguration
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            this.ToTable("movie_t");

            Property(a => a.Id).HasColumnName("id");
            Property(a => a.Adult).HasColumnName("adult");
            Property(a => a.BackdropPath).HasColumnName("backdrop_path");
            Property(a => a.Budget).HasColumnName("budget");
            Property(a => a.ImdbId).HasColumnName("imdb_id");
            Property(a => a.OriginalTitle).HasColumnName("original_title");
            Property(a => a.Overview).HasColumnName("overview");
            Property(a => a.Popularity).HasColumnName("popularity");
            Property(a => a.PosterPath).HasColumnName("poster_path");
            //Property(a => a.ReleaseDate).HasColumnName("release_date");
            Property(a => a.Revenue).HasColumnName("revenue");
            Property(a => a.Runtime).HasColumnName("runtime");
            Property(a => a.Status).HasColumnName("status");
            Property(a => a.Tagline).HasColumnName("tagline");
            Property(a => a.Title).HasColumnName("title");
            Property(a => a.VoteAverage).HasColumnName("vote_average");
            Property(a => a.VoteCount).HasColumnName("vote_count");

            Property(a => a.DateCreated).HasColumnName("date_created");
            Property(a => a.DateModified).HasColumnName("date_modified");
        }
    }
}

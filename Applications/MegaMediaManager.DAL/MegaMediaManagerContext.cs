using MegaMediaManager.DAL.TypeConfiguration;
using Infrastructure;
using MegaMediaManager.Model;
using System;
using System.Data;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace MegaMediaManager.DAL
{
    public partial class MegaMediaManagerContext : IdentityDbContext<User>
    {
        public MegaMediaManagerContext()
            : base("MegaMediaManagerContext") //TODO shouldn't need to specify the connection string--try removing later
        {
        }

        public static MegaMediaManagerContext Create()
        {
            return new MegaMediaManagerContext();
        }

        #region Entity Sets
        public DbSet<AlternativeName> AlternativeName { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Keyword> Keyword { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<MovieKeyword> MovieKeyword { get; set; }
        public DbSet<ReviewType> ReviewType { get; set; }
        public DbSet<SpokenLanguage> SpokenLanguages { get; set; }
        public DbSet<UserMovie> UserMovie { get; set; }
        public DbSet<UserMovieWatch> UserMovieWatch { get; set; }
        public DbSet<UserMovieWatchReview> UserMovieWatchReview { get; set; }
        #endregion

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    #region Model Configurations
        //    modelBuilder.Configurations.Add(new AlternativeNameConfiguration());
        //    modelBuilder.Configurations.Add(new AlternativeTitleConfiguration());
        //    modelBuilder.Configurations.Add(new CountryConfiguration());
        //    modelBuilder.Configurations.Add(new CreditConfiguration());
        //    modelBuilder.Configurations.Add(new DepartmentConfiguration());
        //    modelBuilder.Configurations.Add(new GenreConfiguration());
        //    modelBuilder.Configurations.Add(new JobConfiguration());
        //    modelBuilder.Configurations.Add(new KeywordConfiguration());
        //    modelBuilder.Configurations.Add(new UserConfiguration());
        //    modelBuilder.Configurations.Add(new UserMovieConfiguration());
        //    modelBuilder.Configurations.Add(new UserMovieWatchConfiguration());
        //    modelBuilder.Configurations.Add(new UserMovieWatchReviewConfiguration());
        //    modelBuilder.Configurations.Add(new ReviewTypeConfiguration());
        //    modelBuilder.Configurations.Add(new LanguageConfiguration());
        //    modelBuilder.Configurations.Add(new MovieConfiguration());
        //    modelBuilder.Configurations.Add(new SpokenLanguageConfiguration());
        //    modelBuilder.Configurations.Add(new MovieGenreConfiguration());
        //    modelBuilder.Configurations.Add(new MovieKeywordConfiguration());
        //    modelBuilder.Configurations.Add(new PersonConfiguration());
        //    #endregion
        //}

        public override System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            try
            {
                var modified = ChangeTracker.Entries().Where(
                e => e.State == EntityState.Modified || e.State == EntityState.Added);

                foreach (DbEntityEntry item in modified)
                {
                    var changedOrAddedItem = item.Entity as IDateTracking;
                    if (changedOrAddedItem != null)
                    {
                        if (item.State == EntityState.Added)
                        {
                            changedOrAddedItem.DateCreated = DateTime.Now;
                        }
                        changedOrAddedItem.DateModified = DateTime.Now;
                    }
                }
                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                throw CreateModelValidationException(e);
            }
        }

        public override int SaveChanges()
        {
            try
            {
                var modified = ChangeTracker.Entries().Where(
            e => e.State == EntityState.Modified || e.State == EntityState.Added);

                foreach (DbEntityEntry item in modified)
                {
                    var changedOrAddedItem = item.Entity as IDateTracking;
                    if (changedOrAddedItem != null)
                    {
                        if (item.State == EntityState.Added)
                        {
                            changedOrAddedItem.DateCreated = DateTime.Now;
                        }
                        changedOrAddedItem.DateModified = DateTime.Now;
                    }
                }
                return base.SaveChanges();
            }
            catch (DbEntityValidationException entityException)
            {
                throw CreateModelValidationException(entityException);
            }
        }

        private static ModelValidationException CreateModelValidationException(DbEntityValidationException e)
        {
            var errors = e.EntityValidationErrors;
            var result = new StringBuilder();
            var allErrors = new List<ValidationResult>();
            foreach (var error in errors)
            {
                foreach (var validationError in error.ValidationErrors)
                {
                    result.AppendFormat("\r\n  Entity of type {0} has validation error \"{1}\" for property {2}.\r\n", error.Entry.Entity.GetType().ToString(),
                             validationError.ErrorMessage, validationError.PropertyName);
                    var domainEntity = error.Entry.Entity as DomainEntity<int>;
                    if (domainEntity != null)
                    {
                        result.Append(domainEntity.IsTransient() ? "  This entity was added in this session.\r\n" : string.Format("The Id of the entity is {0}.\r\n",
                            domainEntity.Id));
                    }
                    allErrors.Add(new ValidationResult(validationError.ErrorMessage, new[] { 
                             validationError.PropertyName }));
                }
            }
            throw new ModelValidationException(result.ToString(), e, allErrors);
        }
    }
}

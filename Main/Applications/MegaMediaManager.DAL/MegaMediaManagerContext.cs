using MegaMediaManager.DAL.Configuration;
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
        public DbSet<UserMovie> UserMovie { get; set; }
        public DbSet<UserMovieWatch> UserMovieWatch { get; set; }
        public DbSet<UserMovieWatchReview> UserMovieWatchRating { get; set; }
        public DbSet<ReviewType> RatingType { get; set; }
        public DbSet<Movie> Movie { get; set; }
        #endregion
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Model Configurations
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserMovieConfiguration());
            modelBuilder.Configurations.Add(new UserMovieWatchConfiguration());
            modelBuilder.Configurations.Add(new UserMovieWatchRatingConfiguration());
            modelBuilder.Configurations.Add(new RatingTypeConfiguration());
            #endregion
        }

        public override System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            try { return base.SaveChangesAsync(); }
            catch(DbEntityValidationException e)
            {
                throw CreateModelValidationException(e);
            }
        }

        public override int SaveChanges()
        {
            try { return base.SaveChanges(); }
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

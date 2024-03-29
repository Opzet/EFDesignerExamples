//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.2.5.1
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace Ex6_Course
{
   /// <inheritdoc/>
   public partial class CourseManager : DbContext
   {
      #region DbSets
      public virtual System.Data.Entity.DbSet<global::Ex6_Course.Course> Courses { get; set; }
      public virtual System.Data.Entity.DbSet<global::Ex6_Course.Enrollment> Enrollments { get; set; }
      public virtual System.Data.Entity.DbSet<global::Ex6_Course.Student> Students { get; set; }
      #endregion DbSets

      #region Constructors

      partial void CustomInit();

      /// <summary>
      /// Default connection string
      /// </summary>
      public static string ConnectionString { get; set; } = @"Name=MyLocalDb";
      /// <inheritdoc />
      public CourseManager() : base(ConnectionString)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<CourseManager>(new CourseManagerDatabaseInitializer());
         CustomInit();
      }

      /// <inheritdoc />
      public CourseManager(string connectionString) : base(connectionString)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<CourseManager>(new CourseManagerDatabaseInitializer());
         CustomInit();
      }

      /// <inheritdoc />
      public CourseManager(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<CourseManager>(new CourseManagerDatabaseInitializer());
         CustomInit();
      }

      /// <inheritdoc />
      public CourseManager(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<CourseManager>(new CourseManagerDatabaseInitializer());
         CustomInit();
      }

      /// <inheritdoc />
      public CourseManager(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection) : base(existingConnection, model, contextOwnsConnection)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<CourseManager>(new CourseManagerDatabaseInitializer());
         CustomInit();
      }

      /// <inheritdoc />
      public CourseManager(System.Data.Entity.Infrastructure.DbCompiledModel model) : base(model)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<CourseManager>(new CourseManagerDatabaseInitializer());
         CustomInit();
      }

      /// <inheritdoc />
      public CourseManager(System.Data.Entity.Core.Objects.ObjectContext objectContext, bool dbContextOwnsObjectContext) : base(objectContext, dbContextOwnsObjectContext)
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
         System.Data.Entity.Database.SetInitializer<CourseManager>(new CourseManagerDatabaseInitializer());
         CustomInit();
      }

      #endregion Constructors

      partial void OnModelCreatingImpl(System.Data.Entity.DbModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(System.Data.Entity.DbModelBuilder modelBuilder);

      /// <inheritdoc />
      protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("dbo");

         modelBuilder.Entity<global::Ex6_Course.Course>()
                     .ToTable("Courses")
                     .HasKey(t => t.CourseId);
         modelBuilder.Entity<global::Ex6_Course.Course>()
                     .Property(t => t.CourseId)
                     .IsRequired()
                     .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Ex6_Course.Course>()
                     .Property(t => t.CourseLabel)
                     .HasMaxLength(25);

         modelBuilder.Entity<global::Ex6_Course.Enrollment>()
                     .ToTable("Enrollments")
                     .HasKey(t => t.EnrollmentId);
         modelBuilder.Entity<global::Ex6_Course.Enrollment>()
                     .Property(t => t.EnrollmentId)
                     .IsRequired()
                     .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         modelBuilder.Entity<global::Ex6_Course.Enrollment>()
                     .HasRequired(x => x.Course)
                     .WithMany(x => x.Enrollments)
                     .Map(x => x.MapKey("CourseCourseId"));
         modelBuilder.Entity<global::Ex6_Course.Enrollment>()
                     .HasRequired(x => x.Student)
                     .WithMany(x => x.Enrollments)
                     .Map(x => x.MapKey("StudentStudentId"));

         modelBuilder.Entity<global::Ex6_Course.Student>()
                     .ToTable("Students")
                     .HasKey(t => t.StudentId);
         modelBuilder.Entity<global::Ex6_Course.Student>()
                     .Property(t => t.StudentId)
                     .IsRequired()
                     .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         OnModelCreatedImpl(modelBuilder);
      }
   }
}

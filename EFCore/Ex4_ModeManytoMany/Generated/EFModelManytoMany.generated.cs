//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.2.7.3
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
using Microsoft.EntityFrameworkCore;

namespace Ex4_ModelManytoMany
{
   /// <inheritdoc/>
   public partial class EFModelManytoMany : DbContext
   {
      #region DbSets
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Ex4_ModelManytoMany.Course> Courses { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Ex4_ModelManytoMany.Enrollment> Enrollments { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Ex4_ModelManytoMany.Student> Students { get; set; }

      #endregion DbSets

      /// <inheritdoc />
      public EFModelManytoMany() : base()
      {
      }

      /// <summary>
      ///     <para>
      ///         Initializes a new instance of the <see cref="T:Microsoft.EntityFrameworkCore.DbContext" /> class using the specified options.
      ///         The <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" /> method will still be called to allow further
      ///         configuration of the options.
      ///     </para>
      /// </summary>
      /// <param name="options">The options for this context.</param>
      public EFModelManytoMany(DbContextOptions<EFModelManytoMany> options) : base(options)
      {
      }

      partial void CustomInit(DbContextOptionsBuilder optionsBuilder);

      /// <inheritdoc />
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseLazyLoadingProxies();

         CustomInit(optionsBuilder);
      }

      partial void OnModelCreatingImpl(ModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(ModelBuilder modelBuilder);

      /// <summary>
      ///     Override this method to further configure the model that was discovered by convention from the entity types
      ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
      ///     and re-used for subsequent instances of your derived context.
      /// </summary>
      /// <remarks>
      ///     If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
      ///     then this method will not be run.
      /// </remarks>
      /// <param name="modelBuilder">
      ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
      ///     define extension methods on this object that allow you to configure aspects of the model that are specific
      ///     to a given database.
      /// </param>
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("dbo");

         modelBuilder.Entity<global::Ex4_ModelManytoMany.Course>()
                     .ToTable("Courses")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Course>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Course>()
                     .Property(t => t.Title)
                     .HasMaxLength(255);
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Course>()
                     .HasMany<global::Ex4_ModelManytoMany.Enrollment>(p => p.Enrollments)
                     .WithOne(p => p.Course)
                     .HasForeignKey(k => k.CoursesId)
                     .IsRequired();

         modelBuilder.Entity<global::Ex4_ModelManytoMany.Enrollment>()
                     .ToTable("Enrollments")
                     .HasKey(t => new { t.Id, t.CoursesId, t.StudentsId });
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Enrollment>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Enrollment>()
                     .Property(t => t.CoursesId)
                     .ValueGeneratedNever()
                     .IsRequired();
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Enrollment>()
                     .Property(t => t.StudentsId)
                     .ValueGeneratedNever()
                     .IsRequired();

         modelBuilder.Entity<global::Ex4_ModelManytoMany.Student>()
                     .ToTable("Students")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Student>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Student>()
                     .Property(t => t.FirstName)
                     .HasMaxLength(255);
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Student>()
                     .Property(t => t.LastName)
                     .HasMaxLength(255);
         modelBuilder.Entity<global::Ex4_ModelManytoMany.Student>()
                     .HasMany<global::Ex4_ModelManytoMany.Enrollment>(p => p.Enrollments)
                     .WithOne(p => p.Student)
                     .HasForeignKey(k => k.StudentsId)
                     .IsRequired();

         OnModelCreatedImpl(modelBuilder);
      }
   }
}

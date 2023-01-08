//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.2.1.3
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ex3_ModelOnetoMany
{
   public partial class Book
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Book()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static Book CreateBookUnsafe()
      {
         return new Book();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="_author0"></param>
      public Book(global::Ex3_ModelOnetoMany.Author _author0) : this()
      {
         if (_author0 == null) throw new ArgumentNullException(nameof(_author0));
         _author0.Books.Add(this);

      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="_author0"></param>
      public static Book Create(global::Ex3_ModelOnetoMany.Author _author0)
      {
         return new Book(_author0);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// Unique identifier
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.Description("Unique identifier")]
      public long BookId { get; set; }

      /// <summary>
      /// Max length = 75
      /// </summary>
      [MaxLength(75)]
      [StringLength(75)]
      public string ISBN { get; set; }

      /// <summary>
      /// Max length = 255
      /// </summary>
      [MaxLength(255)]
      [StringLength(255)]
      public string Title { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

   }
}


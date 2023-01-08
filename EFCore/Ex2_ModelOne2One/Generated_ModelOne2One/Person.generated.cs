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

namespace Ex2_ModelOne2One
{
   public partial class Person
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public Person()
      {
         Init();
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      public DateTime? DOB { get; set; }

      /// <summary>
      /// Max length = 45
      /// </summary>
      [MaxLength(45)]
      [StringLength(45)]
      public string Email { get; set; }

      /// <summary>
      /// Max length = 35
      /// </summary>
      [MaxLength(35)]
      [StringLength(35)]
      public string FirstName { get; set; }

      /// <summary>
      /// Max length = 35
      /// </summary>
      [MaxLength(35)]
      [StringLength(35)]
      public string LastName { get; set; }

      /// <summary>
      /// Max length = 35
      /// </summary>
      [MaxLength(35)]
      [StringLength(35)]
      public string MiddleName { get; set; }

      /// <summary>
      /// Identity, Indexed, Required
      /// </summary>
      [Key]
      [Required]
      public long PersonId { get; set; }

      /// <summary>
      /// Max length = 15
      /// </summary>
      [MaxLength(15)]
      [StringLength(15)]
      public string Phone { get; set; }

      /// <summary>
      /// Max length = 75
      /// </summary>
      [MaxLength(75)]
      [StringLength(75)]
      public string PreferredName { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      public virtual global::Ex2_ModelOne2One.Address Address { get; set; }

   }
}


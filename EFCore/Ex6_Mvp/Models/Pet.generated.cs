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

#nullable disable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ex6_Mvp.Models
{
   public partial class Pet
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public Pet()
      {
         Init();
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Min length = 3, Max length = 50
      /// </summary>
      [MinLength(3)]
      [MaxLength(50)]
      [StringLength(50)]
      public string Colour { get; set; }

      /// <summary>
      /// Identity, Indexed, Required
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.DataAnnotations.Display(Name="Primary Key")]
      public long Id { get; set; }

      /// <summary>
      /// Min length = 3, Max length = 50
      /// </summary>
      [MinLength(3)]
      [MaxLength(50)]
      [StringLength(50)]
      public string Name { get; set; }

      /// <summary>
      /// Min length = 3, Max length = 50
      /// </summary>
      [MinLength(3)]
      [MaxLength(50)]
      [StringLength(50)]
      public string Type { get; set; }

   }
}


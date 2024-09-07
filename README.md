# EF Visual Designer Examples

Model and generate code for Database

Examples for both Entity Framework v6.x (Dot Net 4.x)  and Entity Framework Core (Net Core)

You can read more about how to use the designer in the [Documentation site](https://msawczyn.github.io/EFDesigner/).

## EF Core Example Links 

Created with [Entity Framework Visual Editor Extension](https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner2022) from Visual Studio Marketplace

 - [Ex1_ModelPerson](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore/Ex1_ModelPerson)
 - [Ex2_ModelOne2One](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore/Ex2_ModelOne2One)
 - [Ex3_ModelOnetoMany](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore/Ex3_ModelOnetoMany)
 - [Ex4_ModeManytoMany](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore/Ex4_ModeManytoMany)
 - [Ex5_ModelInvoice](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore/Ex5_ModelInvoice)
 - [Ex6_Course](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore/Ex6_Course)
 - [Ex7_Mvp](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore/Ex7_Mvp)
   
[https://github.com/Opzet/EFDesignerExamples](https://github.com/Opzet/EFDesignerExamples/tree/main/EFCore)

Note: Also contains Net4.x examples

# About Entity Framework VIsual Designer

The Entity Framework VIsual Designer, a Visual Studio 2022 extension is the easiest way to add a consistently correct Entity Framework (EF6 or EFCore) model to your project. 

It's an opinionated code generator, adding a new file type (.efmodel) that allows for fast, easy and, most importantly, **visual** design 
of persistent classes. Inheritance, unidirectional and bidirectional associations are all supported. Enumerations are also included in 
the visual model, as is the ability to add text blocks to explain potentially arcane parts of your design.

While giving you complete control over how the code is generated you'll be able to create, out of the box, sophisticated, 
consistent and **correct** Entity Framework code that can be regenerated when your model changes. And, since the code is written using 
partial classes, any additions you make to your generated code are retained across subsequent generations.
The designer doesn't need to be present to use the code that's generated - it generates standard C#, using the code-first, fluent API - so the tool doesn't
become a dependency to your project.

If you are used to the EF visual modeling that comes with Visual Studio, you'll be pretty much at home.
The goal was to duplicate at least those features and, in addition, 
add all the little things that *should* have been there. Things like: 
*   importing entities from C# source, or existing DbContext definitions (including their entities) from compiled EF6 or EFCore assemblies
*   multiple views of your model to highlight important aspects of your design
*   the ability to show and hide parts of the model
*   easy customization of generated output by editing or even replacing the T4 templates
*   entities by default generated as partial classes so the generated code can be easily extended
*   class and enumeration nodes that can be colored to visually group the model
*   different concerns being generated into different subdirectories (entities, enums, dbcontext)
*   string length, index flags, required attributes and other properties being available in the designer

and many other nice-to-have bits.

Code generation is completely customizable via T4 templates. The tool installs templates that 
target both EF6 and EFCore, and generate both a code-first DbContext class and POCO entity classes. The DbContext code is written to allow consumption in 
ASP.Net Core in addition to any other project type, so you'll have flexibility in your development.


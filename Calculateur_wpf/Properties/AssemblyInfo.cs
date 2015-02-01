using System.Reflection;
using System.Runtime.CompilerServices;

// Les informations générales relatives à un assembly dépendent de 
// l'ensemble d'attributs suivant. Changez les valeurs de ces attributs pour modifier les informations
// associées à un assembly.
[assembly: AssemblyTitle("Terre Natale Calculateur")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Trahaum")]
[assembly: AssemblyProduct("Terre Natale Calculateur")]
[assembly: AssemblyCopyright("Copyright © Trahaum 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Les informations de version pour un assembly se composent des quatre valeurs suivantes :
//
//      Version principale
//      Version secondaire 
//      Numéro de build
//      Révision
//
// Vous pouvez spécifier toutes les valeurs ou indiquer les numéros de build et de révision par défaut 
// en utilisant '*', comme indiqué ci-dessous :
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("2.0.1.*")]
[assembly: AssemblyFileVersion("2.0.1.*")]


// Make internal classes visible to test project
[assembly: InternalsVisibleTo("Calculateur Tests")]
[assembly: InternalsVisibleTo("Calculateur_wpf")]

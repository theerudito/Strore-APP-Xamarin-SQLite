﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("YOUR-STORE-ByErudito")]
[assembly: AssemblyDescription("Jorge Loor - Erudito Developer")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("BySky")]
[assembly: AssemblyProduct("YOUR-STORE-ByErudito")]
[assembly: AssemblyCopyright("Copyright ©  2022 By Jorge Loor")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("1.1.1")]
[assembly: AssemblyFileVersion("1.1.1")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]

#if DEBUG
[assembly: Application(Debuggable=true)]
#else
[assembly: Application(Debuggable=false)]
#endif

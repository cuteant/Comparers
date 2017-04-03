using System.Reflection;

[assembly: AssemblyVersion("5.0.0.0")]
#if NETSTANDARD1_0 || NET40
[assembly: AssemblyFileVersion("5.0.0.0")]
#elif NETSTANDARD1_1 || WINDOWS8 || NET45 || NETCORE45
[assembly: AssemblyFileVersion("5.0.1000.0")]
#elif NETSTANDARD1_2 || WINDOWS81 || NET451 || NETCORE451 || WPA81
[assembly: AssemblyFileVersion("5.0.2000.0")]
#elif NETSTANDARD1_3 || NET46
[assembly: AssemblyFileVersion("5.0.3000.0")]
#elif NETSTANDARD1_4 || UAP10_0 || NETCORE50 || NET461
[assembly: AssemblyFileVersion("5.0.4000.0")]
#elif NETSTANDARD1_5 || NET462
[assembly: AssemblyFileVersion("5.0.5000.0")]
#elif NETSTANDARD1_6 || NETCOREAPP1_0 || NET463
[assembly: AssemblyFileVersion("5.0.6000.0")]
#else // this is here to prevent the build system from complaining. It should never be hit
[assembly: AssemblyFileVersion("invalid")]
#endif


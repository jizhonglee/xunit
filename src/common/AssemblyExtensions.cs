using System;
using System.Reflection;
#if !K10
using System.IO;
#endif

internal static class AssemblyExtensions
{
    public static string GetLocalCodeBase(this Assembly assembly)
    {
#if !K10
        string codeBase = assembly.CodeBase;
        if (codeBase == null)
            return null;

        if (!codeBase.StartsWith("file:///"))
            throw new ArgumentException(String.Format("Code base {0} in wrong format; must start with file:///", codeBase), "assembly");

        codeBase = codeBase.Substring(8);
        if (Path.DirectorySeparatorChar == '/')
            return "/" + codeBase;

        return codeBase.Replace('/', Path.DirectorySeparatorChar);
#else
        return assembly.Location;
#endif
    }
}


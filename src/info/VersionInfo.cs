using System.Reflection;

[assembly: AssemblyVersion(VersionNumber.AssemblyVersion)]
[assembly: AssemblyFileVersion(VersionNumber.AssemblyFileVersion)]
[assembly: AssemblyInformationalVersion(VersionNumber.InformationalVersion)]

internal static class VersionNumber
{
    private const string Major = "0";
    private const string Minor = "1";
    private const string Revision = "0";
    private const string Build = "0";

    private const string RevisionVersion = Major + "." + Minor + "." + Revision;
    private const string BuildVersion = RevisionVersion + "." + Build;

    public const string AssemblyVersion = BuildVersion;       //for CLR (used by Nuget if InformationalVersion is not specified)
    public const string AssemblyFileVersion = BuildVersion;   //for Windows (such as in File Explorer)
    public const string InformationalVersion = BuildVersion;  //for humans (used by NuGet if specified)
}
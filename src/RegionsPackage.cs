using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace JavaScriptRegions
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [Guid(PackageGuidString)]
    public sealed class RegionsPackage : Package
    {
        public const string PackageGuidString = "919fc714-2481-4f4f-a916-06eacc702380";
    }
}

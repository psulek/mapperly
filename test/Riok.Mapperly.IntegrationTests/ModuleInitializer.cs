using System.Runtime.CompilerServices;

namespace Riok.Mapperly.IntegrationTests;

public static class ModuleInitializer
{
    // ModuleInitializer should only be used in apps
#pragma warning disable CA2255
    [ModuleInitializer]
#pragma warning restore CA2255
    public static void Init()
    {
        DerivePathInfo((file, _, type, method) => new(Path.Join(Path.GetDirectoryName(file), "_snapshots"), type.Name, method.Name));
    }
}

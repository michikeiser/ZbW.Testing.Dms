using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Zbw.Testing.Dms.Client.UnitTests")]
namespace ZbW.Testing.Dms.Client.Repositories
{
    using System.Collections.Generic;

    internal class ComboBoxItems
    {
        public static List<string> Typ =>
            new List<string>
                {
                    "Verträge",
                    "Quittungen"
                };
    }
}
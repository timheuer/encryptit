using EncryptIt.Controls;
using System.Windows;

namespace EncryptIt;

[Command(PackageIds.EncryptCommand)]
internal sealed class EncryptCommand : BaseCommand<EncryptCommand>
{
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
    {
        Collector c = new Collector()
        {
            Owner = Application.Current.MainWindow
        };

        bool? dialogResult = c.ShowDialog();
    }
}

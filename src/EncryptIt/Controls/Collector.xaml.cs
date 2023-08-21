using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace EncryptIt.Controls;
public partial class Collector : Window
{
    public Collector()
    {
        InitializeComponent();
        txtResult.Text = string.Empty;
        txtValue.Text = string.Empty;

        Loaded += Collector_Loaded;
    }

    private void Collector_Loaded(object sender, RoutedEventArgs e)
    {
        txtValue.Focus();
    }

    private void btnEcnrypt_Click(object sender, RoutedEventArgs e)
    {
        string stringToEncrypt = txtValue.Text;

        Debug.WriteLine($"String to encrypt: {stringToEncrypt}");

        byte[] encBytes = ProtectedData.Protect(Encoding.Unicode.GetBytes(stringToEncrypt), optionalEntropy: null, scope: DataProtectionScope.CurrentUser);
        string base64 = Convert.ToBase64String(encBytes);

        txtResult.Text = base64;

        // copy to clipboard
        Clipboard.SetText(base64);

        Debug.WriteLine($"Encrypted value: {base64}");
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void btnClipCopy_Click(object sender, RoutedEventArgs e)
    {
        Clipboard.SetText(txtResult.Text);
    }
}

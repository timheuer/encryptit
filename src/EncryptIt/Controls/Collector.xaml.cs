using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
        CopyToClipboardAndStatus(base64 );

        Debug.WriteLine($"Encrypted value: {base64}");
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void btnClipCopy_Click(object sender, RoutedEventArgs e)
    {
        CopyToClipboardAndStatus(txtResult.Text);
    }

    internal void CopyToClipboardAndStatus(string valueToCopy)
    {
        Clipboard.SetText(valueToCopy);
        // Set the TextBlock text here if needed
        txtStatus.Text = "Copied to the clipboard!";

        // Create a DoubleAnimation to animate the opacity property
        DoubleAnimation da = new DoubleAnimation
        {
            From = 1.0,
            To = 0.0,
            Duration = new Duration(System.TimeSpan.FromSeconds(4))
        };

        // Create a Storyboard to contain the animations.
        Storyboard sb = new Storyboard();
        sb.Children.Add(da);

        Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
        Storyboard.SetTarget(da, txtStatus);

        // Begin the animation.
        sb.Begin();
    }
}

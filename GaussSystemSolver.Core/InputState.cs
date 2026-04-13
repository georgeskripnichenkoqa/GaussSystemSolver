using System.Globalization;

namespace GaussSystemSolver.Core;

public partial class InputState
{
    public string Text { get; private set; } = string.Empty;
    public bool HasText => !string.IsNullOrWhiteSpace(Text);
    public double? Value { get; private set; }
    public bool IsValid { get; private set; }

    public void Update(string text)
    {
        Text = Normalize(text);
        Validate();
    }

    private void Validate()
    {
        if (HasText &&
            double.TryParse(Text, CultureInfo.InvariantCulture, out double result))
        {
            Value = result;
            IsValid = true;
        }
        else
        {
            Value = null;
            IsValid = false;
        }
    }

    private static string Normalize(string value) => value.Replace(',', '.');

}
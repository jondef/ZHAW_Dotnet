using System.Globalization;

namespace DN10;

public partial class WebForm1 : System.Web.UI.Page
{
    // loading jQuery from CDN
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "https://code.jquery.com/jquery-3.6.1.min.js",
                DebugPath = "https://code.jquery.com/jquery-3.6.1.min.js",
                CdnPath = "https://code.jquery.com/jquery-3.6.1.min.js",
                CdnDebugPath = "https://code.jquery.com/jquery-3.6.1.js"
            });
    }
    
    protected void btnReset_Click(object sender, EventArgs e)
    {
        RangeValidator1.Enabled = false;
        RangeValidator2.Enabled = false;
        RequiredFieldValidator1.Enabled = false;
        RequiredFieldValidator2.Enabled = false;
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
        RangeValidator1.Enabled = true;
        RangeValidator2.Enabled = true;
        RequiredFieldValidator1.Enabled = true;
        RequiredFieldValidator2.Enabled = true;
    }

    protected void btnBerechne_Click(object sender, EventArgs e)
    {
        if (!IsValid)
        {
            return;
        }
        double.TryParse(TextBox1.Text, out double weight);
        double.TryParse(TextBox2.Text, out double height);
        
        // Set text to BMI Value
        TextBox3.Text = (weight / (height * height)).ToString(CultureInfo.InvariantCulture);
    }
}
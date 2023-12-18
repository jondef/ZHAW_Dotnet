using WebApplication_Framework.BMI;

namespace WebApplication_Framework
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            var service = new BmiServiceService();
            bmiLabel.Text = $"Your BMI is {service.calculateBMI(75, 1.4}";
        }
    }
}

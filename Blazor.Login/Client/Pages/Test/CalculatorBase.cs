using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.Login.Client.Pages.Test
{
    public class CalculatorBase : ComponentBase
    {
        protected int number1 = 0;
        protected int number2 = 0;
        protected int total = 0;

        protected void Calculate(MouseEventArgs e, int buttonType)
        {
            switch (buttonType)
            {
                case 1:
                    total = number1 + number2;
                    break;
                case 2:
                    total = number1 - number2;
                    break;
            }
        }
    }
}

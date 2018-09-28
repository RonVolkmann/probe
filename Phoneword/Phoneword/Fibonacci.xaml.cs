using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class Fibonacci : ContentPage
    {
        int slideValue;

        public Fibonacci()
        {
            InitializeComponent();
        }

        void OnSlide(object sender, EventArgs e)
        {
            slideValue = System.Convert.ToInt32(Math.Round(Slider.Value));
            SliderValueField.Text = slideValue.ToString();

            if (slideValue == 12)
            {
                FibonacciValueField.Text = "100";
            }
            else
            {
                FibonacciValueField.Text = FibonacciCalculation(slideValue).ToString();
            }
        }

        int FibonacciCalculation(int currentNumber) {
            if (currentNumber == 0) { return 0; }
            if (currentNumber == 1) { return 1; }

            return (FibonacciCalculation(currentNumber-1) + FibonacciCalculation(currentNumber-2));
        }
    }
}

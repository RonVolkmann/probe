using System;

using Xamarin.Forms;

namespace Phoneword
{
    public class test : ContentPage
    {
        public test()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
<Button x:Name="callHistoryButton" Text="Call History" IsEnabled="false" Clicked="OnCallHistory" />
                }
            };
        }
    }
}


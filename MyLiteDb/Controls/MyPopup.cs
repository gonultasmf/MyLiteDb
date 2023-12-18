namespace MyLiteDb.Controls;

public partial class MyPopup : Popup
{
    public MyPopup(ICustomerService service, MainViewModel viewModel)
    {
        BindingContext = viewModel;
        CanBeDismissedByTappingOutsideOfPopup = true;
        Color = Colors.Transparent;
        Content = new Grid()
        {
            Children =
            {
                new Frame()
                {
                    BorderColor = Colors.Aqua,
                    CornerRadius = 25,
                    Content = new VerticalStackLayout()
                    {
                        Spacing = 10,
                        Children =
                        {
                            new Entry()
                            {
                                IsReadOnly = true,
                            }
                                .Placeholder("Id")
                                .PlaceholderColor(Colors.DarkGray)
                                .Bind(Entry.TextProperty, $"Customer.Id"),

                            new Entry()
                                .Placeholder("Name")
                                .PlaceholderColor(Colors.DarkGray)
                                .Bind(Entry.TextProperty, $"Customer.Name"),

                            new Entry()
                                .Placeholder("Address")
                                .PlaceholderColor(Colors.DarkGray)
                                .Bind(Entry.TextProperty, $"Customer.Address"),

                            new Entry()
                                .Placeholder("Age")
                                .PlaceholderColor(Colors.DarkGray)
                                .Bind(Entry.TextProperty, $"Customer.Age"),

                            new Button()
                                .Text("KAYDET")
                                .Font(bold: true)
                                .Size(100,40)
                                .Invoke(b => b.Clicked += B_Clicked),
                        }
                    }
                }
                .BackgroundColor(Colors.Aqua)
                .Width(200)
            }
        };
    }

    private async void B_Clicked(object? sender, EventArgs e)
    {
        await CloseAsync(((MainViewModel)BindingContext).Customer);
    }
}

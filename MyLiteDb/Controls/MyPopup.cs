﻿namespace MyLiteDb.Controls;

public partial class MyPopup : Popup
{
    Entry imageEntry;
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

                            new Editor()
                                .MinHeight(75)
                                .Placeholder("Address")
                                .PlaceholderColor(Colors.DarkGray)
                                .Bind(Entry.TextProperty, $"Customer.Address"),

                            new Entry()
                                .Placeholder("Age")
                                .PlaceholderColor(Colors.DarkGray)
                                .Bind(Entry.TextProperty, $"Customer.Age"),

                            new Grid()
                            {
                                ColumnDefinitions = Columns.Define(Stars(7), Stars(3)),
                                Children =
                                {
                                    new Entry()
                                    {
                                        IsReadOnly= true,
                                    }
                                        .Assign(out imageEntry)
                                        .Placeholder("Image Id")
                                        .PlaceholderColor(Colors.DarkGray)
                                        .Column(0)
                                        .Bind(Entry.TextProperty, $"Customer.ImageId"),

                                    new Button()
                                        .Text("+")
                                        .Font(size: 16, bold: true)
                                        .Size(40,40)
                                        .Column(1)
                                        .Invoke(b => b.Clicked += U_Clicked),
                                }
                            },

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

    private async void U_Clicked(object? sender, EventArgs e)
    {
        var foto = await MediaPicker.PickPhotoAsync();

        if (foto != null)
        {
            var stream = await foto.OpenReadAsync();
            var result = ((MainViewModel)BindingContext).UploadFile(foto.FileName, stream);
            imageEntry.Text = result;
            ((MainViewModel)BindingContext).Customer.ImageId = result;
        }
    }

    private async void B_Clicked(object? sender, EventArgs e)
    {
        await CloseAsync(((MainViewModel)BindingContext).Customer);
    }
}

using System.Reflection;

namespace MyLiteDb.Views;

public partial class MainPage(MainViewModel viewModel) : BasePage<MainViewModel>(viewModel, "Main Page")
{
    public override void Build()
    {
        Title = "Home";
        Content = new Grid()
        {
            RowDefinitions = Rows.Define(Stars(88), Stars(05), Stars(07)),
            Children =
            {
                new CollectionView
                {
                    SelectionMode = SelectionMode.None
                }
                .BackgroundColor(Colors.Transparent)
                .Bind(CollectionView.ItemsSourceProperty, static (MainViewModel vm) => vm.Customers)
                .AutomationId("CollectionView")
                .ItemTemplate(new DataTemplate(() => new SwipeView()
                {
                    RightItems = new SwipeItems()
                    {
                        new SwipeItem()
                        {
                            IconImageSource = "dotnet_bot.svg",
                            BackgroundColor = Colors.Red,
                            Command = BindingContext.DeleteCommand
                        }
                        .Bind(SwipeItem.CommandParameterProperty, static (Customer c) => c.Id)
                    },

                    LeftItems = new SwipeItems()
                    {
                        new SwipeItem()
                        {
                            IconImageSource = "dotnet_bot.svg",
                            BackgroundColor = Colors.YellowGreen,
                            Command = BindingContext.GoToEditPageCommand
                        }
                        .Bind(SwipeItem.CommandParameterProperty, static (Customer c) => c.Id)
                    },

                    Content = new Frame()
                    {
                        CornerRadius = 20,
                        BorderColor = Colors.Aqua,
                        Content = new Grid()
                        {
                            ColumnDefinitions = Columns.Define(Stars(7), Stars(3)),
                            Children =
                            {
                                new VerticalStackLayout()
                                {
                                    Spacing = 0,
                                    Children =
                                    {
                                        new Label()
                                            .Font(size: 17, bold: true)
                                            .Top()
                                            .SemanticHint("Burası Name")
                                            .Bind(Label.TextProperty, static (Customer c) => c.Name, mode: BindingMode.OneTime),

                                        new Label()
                                        {
                                            LineBreakMode = LineBreakMode.TailTruncation,
                                            MaxLines = 1
                                        }
                                            .Font(size: 15)
                                            .Top()
                                            .SemanticHint("Burası Name")
                                            .Bind(Label.TextProperty, static (Customer c) => c.Address, mode: BindingMode.OneTime),

                                        new Label()
                                            .Font(size: 13)
                                            .Top()
                                            .SemanticHint("Burası Name")
                                            .Bind(Label.TextProperty, static (Customer c) => c.Age, mode: BindingMode.OneTime)
                                    }
                                },

                                new Image()
                                    .Size(100, 75)
                                    .Column(1)
                                    .Bind(Image.SourceProperty, static (Customer c) => c.Image, mode: BindingMode.OneTime),
                            }
                        }
                        .Padding(10)
                    }
                    .BackgroundColor(Colors.Aqua)
                    .Padding(10)
                    .Margin(10)
                })),

                new HorizontalStackLayout()
                {
                    Children =
                    {
                        new Label()
                            .Text("Müşteri Sayısı: ")
                            .Font(size: 17, bold: true)
                            .Start(),

                        new Label()
                            .Font(size: 19, bold: true)
                            .End()
                            .Bind(Label.TextProperty, nameof(MainViewModel.Count)),
                    }
                }
                .CenterVertical()
                .Padding(10, 0)
                .Row(1),

                new Button()
                    .Text("MÜŞTERİ EKLE")
                    .Font(bold: true)
                    .Margin(10, 0)
                    .Row(2)
                    .BindCommand(nameof(MainViewModel.GoToAddPageCommand)),
            }
        };
    }
}

using System.Reflection;

namespace MyLiteDb.Views;

public partial class MainPage(MainViewModel viewModel) : BasePage<MainViewModel>(viewModel, "Main Page")
{
    private int _count = 0;
    private Label CounterLabel;

    public override void Build()
    {
        var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        Title = "Home";
        Content = new Grid()
        {
            RowDefinitions = Rows.Define(Stars(7), Stars(1), Stars(2)),
            Children =
            {
                new CollectionView
                {
                    SelectionMode = SelectionMode.Single
                }
                .BackgroundColor(Colors.Transparent)
                .Bind(CollectionView.ItemsSourceProperty, static (MainViewModel vm) => vm.Customers)
                .AutomationId("CollectionView")
                .ItemTemplate(new DataTemplate(static () => new VerticalStackLayout()
                {
                    Children =
                    {
                        new Label()
                            .Font(size: 16, bold: true)
                            .Top()
                            .Padding(10,0)
                            .SemanticHint("Burası Name")
                            .Bind(Label.TextProperty, static (Customer c) => c.Name, mode: BindingMode.OneTime),

                        new Label()
                        {
                            LineBreakMode = LineBreakMode.TailTruncation,
                            MaxLines = 1
                        }
                            .Font(size: 16)
                            .Top()
                            .Padding(10,0)
                            .SemanticHint("Burası Name")
                            .Bind(Label.TextProperty, static (Customer c) => c.Address, mode: BindingMode.OneTime),

                        new Label()
                            .Font(size: 16)
                            .Top()
                            .Padding(10,0)
                            .SemanticHint("Burası Name")
                            .Bind(Label.TextProperty, static (Customer c) => c.Age, mode: BindingMode.OneTime)
                    }
                }))
            }
        };
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        _count++;
        CounterLabel.Text = $"Current count: {_count}";

        SemanticScreenReader.Announce(CounterLabel.Text);
    }
}

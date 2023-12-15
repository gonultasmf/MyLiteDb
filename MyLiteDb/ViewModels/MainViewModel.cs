namespace MyLiteDb.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly ICustomerService _customerService;

    public MainViewModel(ICustomerService customerService)
    {
        _customerService = customerService;
        //for (int i = 0; i < 50; i++)
        //{
        //    _customerService.Add(new Customer
        //    {
        //        Name = $"Bu {i} İsim",
        //        Address = $"Bu {i} Adrestir.",
        //        Age = i + 10
        //    });
        //}
        Customers = _customerService.GetAll();
        Count = _customerService.Count();
    }

    [ObservableProperty]
    private int _count = 0;

    [ObservableProperty]
    private List<Customer> _customers;
}

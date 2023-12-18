using MyLiteDb.Controls;
using System.Windows.Input;

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
        GetInfoCustomersList();
    }

    [ObservableProperty]
    private int _count = 0;

    [ObservableProperty]
    private List<Customer> _customers;

    [ObservableProperty]
    private Customer _customer;

    public ICommand GoToAddPageCommand => new Command(async () =>
    {
        Customer = new();

        if (Customer != null)
        {
            var result = await Shell.Current.ShowPopupAsync(new MyPopup(_customerService, this));

            if (result != null && result is Customer resultCustomer)
            {
                var addResult = _customerService.Add(resultCustomer);

                if (addResult)
                    GetInfoCustomersList();
            }
        }
    });

    public ICommand GoToEditPageCommand => new Command(async (object id) =>
    {
        Customer = _customerService.Get((int)id);

        if (Customer != null )
        {
            var result = await Shell.Current.ShowPopupAsync(new MyPopup(_customerService, this));

            if (result != null && result is Customer resultCustomer)
            {
                var updateResult = _customerService.Update(resultCustomer);

                if (updateResult)
                    GetInfoCustomersList();
            }
        }
    });

    public ICommand DeleteCommand => new Command((object id) =>
    {
        var control = _customerService.Delete((int)id);

        if (control)
            GetInfoCustomersList();
    });

    private void GetInfoCustomersList()
    {
        Customers = _customerService.GetAll();
        Count = _customerService.Count();
    }
}

using Newtonsoft.Json;

namespace Onward;
/* This is created by Vinh Huynh. Modified by Vinh Huynh and Jack*/
public partial class CreateCustomer : ContentPage
{
    private Customer toSubmit; //refer to Customer.cs class
    private ServerSocket serverSocket;  //refer to ServerSocket.cs
    public CreateCustomer()
    {
        // BindingContext = this;
        InitializeComponent();
        toSubmit = new();       //initialize
        serverSocket = new();   //initialize
    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(true);// Asynchronously dismisses the most recent modally presented Create with true
    }
    //This is a funtion which will submit user input in 
    private async void Submit(object sender, EventArgs e)
    {
        toSubmit.Company = CustCompany.Text;
        toSubmit.ContactPerson = CustContactPerson.Text;
        string json = JsonConvert.SerializeObject(toSubmit);
    	var (response, success) = await serverSocket.PostAsync(json, "/customers/newcustomer");

        if (success)
        {
            await Navigation.PopModalAsync(true);
        }
        else 
        {
            await DisplayAlert("Error", "Data not posted: " + response.ToString(), "Close");
        }
    }

}
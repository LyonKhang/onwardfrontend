namespace Onward;

using Newtonsoft.Json;
using System.Collections.ObjectModel;
/*This file is created by Jack. modified by Vinh and Jack*/
public partial class ViewInvoices : ContentPage
{
    private readonly ServerSocket serverSocket;
    private List<Invoice>? invoicesDe;
    private ObservableCollection<Invoice> invoices;
    public ObservableCollection<Invoice> Invoices
    {
        get { return invoices; }
        set { invoices = value; }
    }
    //this will initialized 
    public ViewInvoices()
	{
        serverSocket = new();   //create server
        invoicesDe = [];        //empty
        invoices = [];          //empty
        BindingContext = this;  //bind property to this
        InitializeComponent();
    }
    //this funtion ask backends to to retrieve
    private async void PopulateInvoices()
    {
        var (json, success) = await serverSocket.GetAsync("/invoices/getinvoices");
        if (success)
        {
            invoicesDe = JsonConvert.DeserializeObject<List<Invoice>>(json);
            if (invoicesDe != null && invoicesDe.Count > 0)
            {
                foreach (Invoice invoices in invoicesDe)
                {
                    invoicesDe.Add(invoices);
                }
            }
            else
            {
                await DisplayAlert("Error", "Invoice list is null", "Close");
                await Navigation.PopAsync();
            }
        }
        else
        {
            await DisplayAlert("Error", "Invoice list can't be found: " + json, "Close");
            await Navigation.PopAsync();
        }
    }
}
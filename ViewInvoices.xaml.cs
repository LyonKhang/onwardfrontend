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
    public ViewInvoices()
	{
        serverSocket = new();
        invoicesDe = [];
        invoices = [];

        BindingContext = this;
        InitializeComponent();
    }

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
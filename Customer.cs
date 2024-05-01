using System.ComponentModel;
using Newtonsoft.Json;

namespace Onward;
/*This file is created byVinh. The file is modify by Vinh and Jack */
public class Customer : INotifyPropertyChanged
{
    [JsonProperty(PropertyName = "company")]
    private string company;
    public string Company
    {
        get { return company; }
        set
        {
            if (company != value)
            {
                company = value;
                OnPropertyChanged(nameof(Company)); //add user input as Company
            }
        }
    }

    [JsonProperty(PropertyName = "contactPerson")]
    private string contactPerson;
    public string ContactPerson
    {
        get { return contactPerson; }
        set
        {
            if (contactPerson != value)
            {
                contactPerson = value;
                OnPropertyChanged(nameof(ContactPerson));   //add user input as contact person
            }
        }
    }
    //Empty Constructor
    public Customer()
    {
        company = "";
        contactPerson = "";
    }
    // Constructor with 2 parameter (Vinh)
    public Customer(string name, string role)
    {
        this.company = name;
        this.contactPerson = role;
    }
    //
    public event PropertyChangedEventHandler? PropertyChanged;  //will run when a property changed
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  //Trigger Property changed
    }

}
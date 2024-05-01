using System.Net;

namespace Onward;
/*This file is create by Vinh. Modified by Vinh*/
public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}
    //From button send user to Github backends
    private void linkBackEnd(object sender, EventArgs e)
    {
        string url = "https://github.com/jack-turk-5/onward"; //link
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });  //this running command cmd and plug in url
    }
    //From button send user to Github Frontkends
    private void linkFrontEnd(object sender, EventArgs e)
    {
        string url = "https://github.com/LyonKhang/onwardfrontend"; //link
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });  //this running command cmd and plug in url
    }
}
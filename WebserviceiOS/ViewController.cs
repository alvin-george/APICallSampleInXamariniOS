using System;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebserviceiOS
{
    public partial class ViewController : UIViewController, IUITableViewDelegate, IUITableViewDataSource
    {

        JArray countriesArray;
        CountriesData countriesData;

        protected ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.countriesTableview.DataSource = this;
            this.countriesTableview.Delegate = this;

        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.initialUISetup();

        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            this.makeGETWebserviceCall();
        }
        private void initialUISetup()
        {
            this.countriesTableview.TableFooterView = new UIView(frame: CGRect.Empty);
            countriesData = new CountriesData();
        }
        private async void makeGETWebserviceCall()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://services.groupkt.com/country/get/all");

            var getResult = await client.GetAsync(client.BaseAddress);
            if (getResult.IsSuccessStatusCode)
            {
                var tokenJson = await getResult.Content.ReadAsStringAsync();
                Console.WriteLine("Success GET  " + tokenJson);

                JObject joResponse = JObject.Parse(tokenJson);
                JObject ojObject = (JObject)joResponse["RestResponse"];
                JArray array = (JArray)ojObject["result"];

                Console.WriteLine("Array : Succes " + array + "Count  :" + array.Count);
                countriesArray = array;

                this.countriesTableview.ReloadData();

            }

        }
        private async void MakePOSTWebserviceCall()
        {
            var client = new HttpClient();
            string jsonData = "{\"username\" : \"myusername\", \"password\" : \"mypassword\"}";

            var content = new StringContent(
             JsonConvert.SerializeObject(new { username = "myusername", password = "mypass" }));

            var result = await client.PostAsync("localhost:8080", content).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var tokenJson = await result.Content.ReadAsStringAsync();

                Console.WriteLine("Success POST: " + tokenJson);
            }
        }


        //TableView DataSource
        public nint RowsInSection(UITableView tableView, nint section)
        {
            if (countriesArray != null)
            {
                return countriesArray.Count;
            }
            else
            {

                return 0;
            }

        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            string cellIdentifier = "CountryTableCellID";

            CountryTableCell cell = tableView.DequeueReusableCell(cellIdentifier) as CountryTableCell;


            if (countriesArray != null)
            {
                JObject eachCountry = (JObject)countriesArray[indexPath.Row];
                string name = eachCountry["name"].ToString();
                string alpha_code2 = eachCountry["alpha2_code"].ToString();
                string alpha_code3 = eachCountry["alpha3_code"].ToString();
                Console.WriteLine("name : " + name);

                cell.namelabel.Text = name;
                cell.alpha_code2.Text = alpha_code2;
                cell.alpha_code3.Text = alpha_code3;
            }

            return cell;
        }

        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("Row Selected");
        }

        [Export("tableView:heightForRowAtIndexPath:")]
        public nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 150;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

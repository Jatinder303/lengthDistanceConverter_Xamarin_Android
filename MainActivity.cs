using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace lengthDistanceConverter_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtNumber;
        Spinner spConvertFrom;
        Spinner spConvertTo;
        TextView lblConversion;
        TextView lblMeasurement;
        Button btnConvert;
        Button btnClear;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtNumber = FindViewById<EditText>(Resource.Id.txtNumber);
            spConvertFrom = FindViewById<Spinner>(Resource.Id.spConvertFrom);
            spConvertTo = FindViewById<Spinner>(Resource.Id.spConvertTo);
            lblConversion = FindViewById<TextView>(Resource.Id.lblConversion);
            lblMeasurement = FindViewById<TextView>(Resource.Id.lblMeasurement);
            btnConvert = FindViewById<Button>(Resource.Id.btnConvert);
            btnClear = FindViewById<Button>(Resource.Id.btnClear);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Measurements, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spConvertFrom.Adapter = adapter;
            spConvertTo.Adapter = adapter;

            spConvertFrom.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spConvertFrom_ItemSelected);
            spConvertTo.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spConvertTo_ItemSelected);
            btnConvert.Click += OnBtnConvertClick;
            btnClear.Click += OnBtnClearClick;
        }
        public void spConvertFrom_ItemSelected(object IntentSender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        public void spConvertTo_ItemSelected(object IntentSender, AdapterView.ItemSelectedEventArgs e)
        {
            if (spConvertTo.SelectedItem.ToString() == "Centimeters")
            {
                lblMeasurement.Text = "Centimeters";
            }
            else if (spConvertTo.SelectedItem.ToString() == "Meters")
            {
                lblMeasurement.Text = "Meters";
            }
            else if (spConvertTo.SelectedItem.ToString() == "Kilometers")
            {
                lblMeasurement.Text = "Kilometers";
            }
        }

        public void OnBtnConvertClick(object sender, EventArgs e)
        {
            if (spConvertFrom.SelectedItem.ToString() == "Centimeters" && spConvertTo.SelectedItem.ToString() == "Meters")
            {
                lblConversion.Text = Convert.ToString(Convert.ToDouble(txtNumber.Text) / 100);
            }
            else if (spConvertFrom.SelectedItem.ToString() == "Centimeters" && spConvertTo.SelectedItem.ToString() == "Kilometers")
            {
                lblConversion.Text = Convert.ToString(Convert.ToDouble(txtNumber.Text) / 100000);
            }
            else if (spConvertFrom.SelectedItem.ToString() == "Meters" && spConvertTo.SelectedItem.ToString() == "Centimeters")
            {
                lblConversion.Text = Convert.ToString(Convert.ToDouble(txtNumber.Text) / 0.010000);
            }
            else if (spConvertFrom.SelectedItem.ToString() == "Meters" && spConvertTo.SelectedItem.ToString() == "Kilometers")
            {
                lblConversion.Text = Convert.ToString(Convert.ToDouble(txtNumber.Text) / 1000);
            }
            else if (spConvertFrom.SelectedItem.ToString() == "Kilometers" && spConvertTo.SelectedItem.ToString() == "Centimeters")
            {
                lblConversion.Text = Convert.ToString(Convert.ToDouble(txtNumber.Text) / 100);
            }
            else if (spConvertFrom.SelectedItem.ToString() == "Kilometers" && spConvertTo.SelectedItem.ToString() == "Meters")
            {
                lblConversion.Text = Convert.ToString(Convert.ToDouble(txtNumber.Text) / 0.0010000);
            }
        }

        public void OnBtnClearClick(object sender, EventArgs e)
        {
            txtNumber.Text = "";
            lblConversion.Text = "";

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
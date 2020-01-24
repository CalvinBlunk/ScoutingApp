using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Draft3
{
    [Activity(Label = "GridView")]
    public class GridViewActivity : Activity
    {
        GridView grid;
        public ArrayAdapter<string> ad;
        public List<ImageTable> imgs = new List<ImageTable>();
        public static string[] teamNumbers = new string[]{
            "254",
            "1320",
            "235",
            "43",
            "4499",
            "232",
            "312",
            "123",
            "25",
            "3452",
            "1232",
            "1290",
            "2299",
            "867",
            "90",
            "99",
            "723",
            "112"
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.grid_layout);
            grid = FindViewById<GridView>(Resource.Id.gridview);
            ad = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, teamNumbers);

            grid.Adapter = ad;
            grid.ItemClick += ShowClick;

        }
        public void ShowClick(object sender, AdapterView.ItemClickEventArgs e) {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<PitsTable>();
                PitsTable pits = new PitsTable();
                List<PitsTable> pts = new List<PitsTable>();

                string tnd = ad.GetItem(e.Position);
                SetContentView(Resource.Layout.team_display);
                var tn = FindViewById<TextView>(Resource.Id.textViewtd1);
                var txtWeight = FindViewById<TextView>(Resource.Id.txtView_Weight);
                var txtDrive = FindViewById<TextView>(Resource.Id.txtView_Drive);
                var txtDimensions = FindViewById<TextView>(Resource.Id.txtView_DimensionsL);
                var txtAuto = FindViewById<TextView>(Resource.Id.txtView_Auto);
                var txtBuild = FindViewById<TextView>(Resource.Id.txtView_Build);
                var txtElectronics = FindViewById<TextView>(Resource.Id.txtView_Electronics);
                var txtChassis = FindViewById<TextView>(Resource.Id.Chassis);
                var txtSpinner = FindViewById<TextView>(Resource.Id.txtView_Spinner);
                var txtCameras = FindViewById<TextView>(Resource.Id.txtView_Cameras);
                var txtClimb = FindViewById<TextView>(Resource.Id.txtView_Climb);
                var txtNotes = FindViewById<TextView>(Resource.Id.txtView_Notes);

                var pt = new PitsTable();
                string teams = pits.Team.ToString();
                tn.Text = tnd;
                int num = Int32.Parse(tnd);
                // var query = "FROM p in pts WHERE p.Team.ToString() == tnd.ToString() SELECT p.Team";
                var query = db.Query<PitsTable>("SELECT * FROM PitsTable WHERE Team ==" + num);
                var queryP = db.Query<ImageTable>("SELECT * FROM ImageTable WHERE Team ==" + num);
                // db.Execute(query);
                foreach(var p in queryP)
                {
                    var gridview1 = FindViewById<GridView>(Resource.Id.gridViewtd1);
                    ImageAdapter adap = new ImageAdapter(this, queryP);
                    gridview1.Adapter = adap;
                }

                // Toast.MakeText(this, query.ToString(), ToastLength.Long).Show();
                foreach (var t in query)
                {
                    txtWeight.Text = "Weight: " + t.RobotWeight;
                    txtDrive.Text = "Drivetrain: " + t.Drivetrain;
                    txtDimensions.Text = "Dimensions: " + t.Dimensions;
                    txtAuto.Text = "Auto Strategy: " + t.Auto;
                    txtBuild.Text = "Build Quality: " + t.Build;
                    txtElectronics.Text = "Electronics Reliability: " + t.Electronics;
                    txtChassis.Text = "Chassis Durability: " + t.Chassis;
                    txtSpinner.Text = "Spinner: " + t.Spinner;
                    txtCameras.Text = "Driver Cameras: " + t.Cameras;
                    txtClimb.Text = "Climb: " + t.Climb;
                    txtNotes.Text = "Notes: " + t.Notes;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}

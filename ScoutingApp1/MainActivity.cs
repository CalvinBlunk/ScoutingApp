using Android;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Plugin.Media;
using SQLite;
using System;

namespace ScoutingApp1
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button pitsclick;
        Button displayclick;
        Button takePhoto;
        ImageView robotImage;
        Button photosandscores;
        TextView test;
        TextView ScoreTest;
        Button ScoresView;
       


        readonly string[] permissionsask =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            pitsclick = FindViewById<Button>(Resource.Id.pitsbutton);
            displayclick = FindViewById<Button>(Resource.Id.displaybutton);
            takePhoto = FindViewById<Button>(Resource.Id.takephoto);
            robotImage = FindViewById<ImageView>(Resource.Id.Images);
            photosandscores = FindViewById<Button>(Resource.Id.showphoto);
            test = FindViewById<TextView>(Resource.Id.testtext);
            ScoreTest = FindViewById<TextView>(Resource.Id.scoretest);
            ScoresView = FindViewById<Button>(Resource.Id.showscores);

            ScoresView.Click += delegate
            {
                StartActivity(typeof(TrueScoresActivity));
            };
            
            pitsclick.Click += delegate
            {
                StartActivity(typeof(PitsActivity));
                
            };
            
            displayclick.Click += delegate
            {
                StartActivity(typeof(PitsActivity));
            };
            CreateDB();
            RequestPermissions(permissionsask, 0);

            takePhoto.Click += TakePhoto;
            photosandscores.Click += delegate
            {
                StartActivity(typeof(ScoresActivity));
            };
        }
        public string CreateDB()
        {
            var output = "";
            output += "Creating Database if it doesn't exist";
            string dpPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<ScoresTable>();
            ScoresTable st = new ScoresTable();
            output += "\n Database Created";
            return output;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    

    
        async void TakePhoto(object sender, System.EventArgs e)
        {
            string dpPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<ISTable>();
            ISTable tbl = new ISTable();

            await CrossMedia.Current.Initialize();


            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                CompressionQuality = 40,
                Name = "icon.jpg",
                Directory = "sample"
            });
            if (file == null)
            {
                return;
            }
            byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);



            tbl.Image = imageArray;
            db.Insert(tbl);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(tbl.Image, 0, tbl.Image.Length);
            robotImage.SetImageBitmap(bitmap);


            LayoutInflater layoutInflater = LayoutInflater.From(this);
            View view = layoutInflater.Inflate(Resource.Layout.photo_alert, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertbuilder.SetView(view);
            var userdata = view.FindViewById<EditText>(Resource.Id.edittextT);


            alertbuilder.SetCancelable(false).SetPositiveButton("Submit", delegate
            {
                int numberT;
                Int32.TryParse(userdata.Text, out numberT);
                tbl.Team = numberT;
                db.Insert(tbl);

                string numstring = tbl.Team.ToString();
                test.Text = numstring;
                ScoreTest.Text = tbl.Score.ToString();
                Toast.MakeText(this, "Submit Input: " + userdata.Text, ToastLength.Short).Show();

                //TakePhoto();
            });

            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();



           

        }
        
    }
}
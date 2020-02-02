using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using System;
using System.IO;

namespace Verification
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SignIn : Activity
    {
        private EditText username;
        private EditText password;

        private Button register;
        private Button signIn;
        private Button toRecoverUsername;
        private Button toRecoverPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sign_in);
            username = FindViewById<EditText>(Resource.Id.username);
            password = FindViewById<EditText>(Resource.Id.password);

            register = FindViewById<Button>(Resource.Id.register);
            signIn = FindViewById<Button>(Resource.Id.signIn);
            toRecoverUsername = FindViewById<Button>(Resource.Id.toRecoverUsername);
            toRecoverPassword = FindViewById<Button>(Resource.Id.toRecoverPassword);

            signIn.Click += SignIn_Click;
            register.Click += delegate { StartActivity(typeof(Register)); };
            toRecoverUsername.Click += delegate { StartActivity(typeof(RecoverUsername)); };
            toRecoverPassword.Click += delegate { StartActivity(typeof(RecoverPassword)); };

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "scouting_users.d3");
            var db = new SQLiteConnection(dbPath);
            var user = from u in db.Table<User>() where u.Username == username.Text && u.HashedPassword == global::BCrypt.Net.BCrypt.HashPassword(password.Text, BCrypt.Net.BCrypt.GenerateSalt()) select u;
            if (user != null) Toast.MakeText(this, "Congrats!", ToastLength.Short).Show();
            else Toast.MakeText(this, "Incorrect username or password", ToastLength.Short).Show();
        }
    }
}
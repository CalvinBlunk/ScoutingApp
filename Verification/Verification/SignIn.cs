using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using SQLite;
using System;
using System.IO;
using System.Text;

namespace Verification
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SignIn : Activity
    {
        private EditText username;
        private EditText password;
        private EditText recoveryAddress;

        private Button register;
        private Button signIn;
        private Button toRecovery;
        private Button recover;
        private Button recoverySwitcher;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sign_in);
            username = FindViewById<EditText>(Resource.Id.username);
            password = FindViewById<EditText>(Resource.Id.password);

            register = FindViewById<Button>(Resource.Id.register);
            signIn = FindViewById<Button>(Resource.Id.signIn);
            toRecovery = FindViewById<Button>(Resource.Id.toRecover);

            signIn.Click += SignIn_Click;
            register.Click += delegate { StartActivity(typeof(Register)); };
            toRecovery.Click += ToRecovery_Click;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "scouting_users.d3");
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<User>();
                var data1 = data.Where(x => x.username == username.Text && global::BCrypt.Net.BCrypt.CheckPassword(password.Text, x.password));
                if (data1 != null)
                {
                    Toast.MakeText(this, "Congrats! Onto the next thing!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Invalid username or password", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        private void ToRecovery_Click(object sender, EventArgs e)
        {
            if (Register.isEmail)
            {
                SetContentView(Resource.Layout.recovery_email);
                recoveryAddress = FindViewById<EditText>(Resource.Id.recoveryAddress);
                recover = FindViewById<Button>(Resource.Id.recover);
                recoverySwitcher = FindViewById<Button>(Resource.Id.recoverySwitcher);
                recover.Click += Recover_Click;
                recoverySwitcher.Click += RecoverySwitcher_Click;
                
            }
            else
            {
                SetContentView(Resource.Layout.recovery_phone);
                recoveryAddress = FindViewById<EditText>(Resource.Id.recoveryAddress);
                recover = FindViewById<Button>(Resource.Id.recover);
                recoverySwitcher = FindViewById<Button>(Resource.Id.recoverySwitcher);
                recover.Click += Recover_Click;
                recoverySwitcher.Click += RecoverySwitcher_Click;
                
            }
        }

        private void Recover_Click(object sender, EventArgs e)
        {
        }

        // Lambda or Linq method: the easiest
        /* Pros:
         * +easy
         * +only have to do light work in the IDE and in DB Browser
         * Cons: 
         * -might be slow
         * -can be complicated for many rows/columns
         */

         // Query style: a little harder
         /*
          * Basic structure: from x in y
          * join z in a on x.<field> equals z.Id
          * select new {x.<field1>, z.<field1>}
          */

        // Use a SQLite command as a variable: the most tricky
        /*
         * Basic structure: var sqlCommand = new SQLiteCommand("<command>");
         * Put in adapter and then give the SQLite command as a parameter to the adapter
         * 
         * *Remember that the code gets translated to Python, making it difficult to understand.
         */

        private void RecoverySwitcher_Click(object sender, EventArgs e)
        {
            Register.isEmail = !Register.isEmail;
            if (Register.isEmail)
            {
                SetContentView(Resource.Layout.recovery_email);
            }
            else
            {
                SetContentView(Resource.Layout.recovery_phone);
            }
        }
    }
}
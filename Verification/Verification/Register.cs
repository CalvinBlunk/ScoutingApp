using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using SQLite;
using System;
using System.IO;

namespace Verification
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {

        public static EditText address;
        public static EditText firstName;
        public static EditText lastName;
        public static EditText password;
        public static EditText username;
        public static EditText inputPIN;

        public static Button addUserToDB;
        public static Button verificationSwitcher;
        public static Button verifyPIN;

        public static string pin;
        public static bool isEmail = true;
        private string inputPass;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.email_address);

            address = FindViewById<EditText>(Resource.Id.address);
            firstName = FindViewById<EditText>(Resource.Id.firstName);
            lastName = FindViewById<EditText>(Resource.Id.lastName);
            username = FindViewById<EditText>(Resource.Id.username);
            password = FindViewById<EditText>(Resource.Id.password);
            addUserToDB = FindViewById<Button>(Resource.Id.addUserToDB);
            verificationSwitcher = FindViewById<Button>(Resource.Id.verificationSwitcher);

            verificationSwitcher.Click += Verification_Click;
            addUserToDB.Click += AddUserToDB_Click;
            base.OnCreate(savedInstanceState);
        }
        private void Verification_Click(object sender, EventArgs e)
        {
            isEmail = !isEmail;
            if (isEmail)
            {
                SetContentView(Resource.Layout.email_address);
            }
            else
            {
                SetContentView(Resource.Layout.phone_number);
            }
        }

        private void AddUserToDB_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "scouting_users.db3");
                SQLiteConnection db = new SQLiteConnection(dbPath);
                User tbl = new User();
                Random rand = new Random();
                pin = rand.Next(0, 9999).ToString("D4");
                tbl.pin = pin;
                if (!isEmail)
                {
                    tbl.address = address.Text;
                    var smsUri = Android.Net.Uri.Parse("smsto:" + address.Text);
                    var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                    smsIntent.PutExtra("sms_body", "Your PIN is " + pin);
                    StartActivity(smsIntent);
                }
                else
                {
                    tbl.address = address.Text;
                    var sendEmail = new Intent(Intent.ActionSend);
                    sendEmail.SetType("message/rfc822");
                    sendEmail.PutExtra(Intent.ExtraEmail, new string[] { address.Text.ToString() });
                    sendEmail.PutExtra(Intent.ExtraSubject, "Your Verification PIN");
                    sendEmail.PutExtra(Intent.ExtraText, "Your verification PIN is " + tbl.pin);
                    StartActivity(sendEmail);
                }
                SetContentView(Resource.Layout.pin_verification);
                verifyPIN = FindViewById<Button>(Resource.Id.verifyPIN);
                inputPIN = FindViewById<EditText>(Resource.Id.pin);
                verifyPIN.Click += VerifyPIN_Click;

                inputPass = BCrypt.Net.BCrypt.HashPassword(password.Text, BCrypt.Net.BCrypt.GenerateSalt());
                tbl.username = username.Text;
                tbl.first_name = firstName.Text;
                tbl.last_name = lastName.Text;
                tbl.password = inputPass;
                db.Insert(tbl);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
        
        public static bool CheckPIN(string pinToBeChecked)
        {
            return pin == pinToBeChecked;
        }

        private void VerifyPIN_Click(object sender, EventArgs e)
        {   
            if (CheckPIN(inputPIN.Text))
            {
                if (isEmail)
                {
                    SetContentView(Resource.Layout.email_address);
                } else
                {
                    SetContentView(Resource.Layout.phone_number);
                }
                Toast.MakeText(this, "Congrats! Onto the next thing!", ToastLength.Short).Show();
            } else
            {
                Toast.MakeText(this, "Wrong PIN", ToastLength.Short).Show();
            }
        }
    }
}
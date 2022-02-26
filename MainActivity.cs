using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quiz_App.Activities;

namespace Quiz_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        AndroidX.AppCompat.Widget.Toolbar toolbar1;
        AndroidX.DrawerLayout.Widget.DrawerLayout drawerLayout;
        Google.Android.Material.Navigation.NavigationView navigationView;

        LinearLayout historyLayout;
        LinearLayout spaceLayout;
        LinearLayout geographyLayout;
        LinearLayout engineeringLayout;
        LinearLayout programmingLayout;
        LinearLayout businessLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            toolbar1 = (AndroidX.AppCompat.Widget.Toolbar)FindViewById(Resource.Id.toolbar1);
            drawerLayout = (AndroidX.DrawerLayout.Widget.DrawerLayout)FindViewById(Resource.Id.drawerLayout);
            navigationView = (Google.Android.Material.Navigation.NavigationView)FindViewById(Resource.Id.navView);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            //Setup Toolbar
            SetSupportActionBar(toolbar1);
            SupportActionBar.Title = "Topics";
            AndroidX.AppCompat.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.menuaction);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            //View Setups
            historyLayout = (LinearLayout)FindViewById(Resource.Id.historyLayout);
            spaceLayout = (LinearLayout)FindViewById(Resource.Id.spaceLayout);
            geographyLayout = (LinearLayout)FindViewById(Resource.Id.geographyLayout);
            engineeringLayout = (LinearLayout)FindViewById(Resource.Id.engineeringLayout);
            programmingLayout = (LinearLayout)FindViewById(Resource.Id.programmingLayout);
            businessLayout = (LinearLayout)FindViewById(Resource.Id.businessLayout);

            //Click event handlers
            historyLayout.Click += HistoryLayout_Click;
            spaceLayout.Click += SpaceLayout_Click;
            geographyLayout.Click += GeographyLayout_Click;
            engineeringLayout.Click += EngineeringLayout_Click;
            programmingLayout.Click += ProgrammingLayout_Click;
            businessLayout.Click += BusinessLayout_Click;
        }

        private void NavigationView_NavigationItemSelected(object sender, Google.Android.Material.Navigation.NavigationView.NavigationItemSelectedEventArgs e)
        {
            if(e.MenuItem.ItemId == Resource.Id.navHistory)
            {
                InitCategory("History");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navGeography)
            {
                InitCategory("Geography");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navSpace)
            {
                InitCategory("Space");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navProgramming)
            {
                InitCategory("Programming");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navEngineering)
            {
                InitCategory("Engineering");
                drawerLayout.CloseDrawers();
            }
            else if (e.MenuItem.ItemId == Resource.Id.navBusiness)
            {
                InitCategory("Business");
                drawerLayout.CloseDrawers();
            }
        }

        private void BusinessLayout_Click(object sender, EventArgs e)
        {
            InitCategory("Business");
        }

        private void ProgrammingLayout_Click(object sender, EventArgs e)
        {
            InitCategory("Programming");
        }

        private void EngineeringLayout_Click(object sender, EventArgs e)
        {
            InitCategory("Engineering");
        }

        private void GeographyLayout_Click(object sender, EventArgs e)
        {
            InitCategory("Geography");
        }

        private void SpaceLayout_Click(object sender, EventArgs e)
        {
            InitCategory("Space");
        }

        private void HistoryLayout_Click(object sender, EventArgs e)
        {
            InitCategory("History");
        }

        void InitCategory(string topic)
        {
            Intent intent = new Intent(this, typeof(QuizDescriptionActivity));
            intent.PutExtra("topic", topic);
            StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
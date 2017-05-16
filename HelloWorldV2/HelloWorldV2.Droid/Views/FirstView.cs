using Android.App;
using Android.OS;

namespace HelloWorldV2.Droid.Views
{
    [Activity(Label = "Princess Bride Mad Lib")]
    public class FirstView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}

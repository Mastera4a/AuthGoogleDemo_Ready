using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;

namespace AuthGoogleDemo.Platforms.Android
{
    public class GoogleSignInService
    {
        private readonly GoogleSignInClient _googleSignInClient;
        private static GoogleSignInService _instance;

        public static GoogleSignInService Instance => _instance ??= new GoogleSignInService();

        private GoogleSignInService()
        {
            var gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestIdToken("725286934712-nig2avdr13cl8tfi702eqmc5rk5it8udy.apps.googleusercontent.com")
                .RequestEmail()
                .Build();

            var activity = (Activity)Platform.CurrentActivity;
            _googleSignInClient = GoogleSignIn.GetClient(activity, gso);
        }

        public Intent GetSignInIntent()
        {
            return _googleSignInClient.SignInIntent;
        }

        public async Task SignOutAsync()
        {
            await _googleSignInClient.SignOutAsync();
        }
    }
}

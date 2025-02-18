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
                .RequestIdToken("28820578575-i74avarft5ema1kgf0nobsngkuhstfj2.apps.googleusercontent.com")
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

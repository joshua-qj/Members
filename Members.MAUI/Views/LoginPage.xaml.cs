namespace Members.MAUI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
    }
    protected override bool OnBackButtonPressed() {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e) {
        if (IsCredentialCorrect(Username.Text, Password.Text)) {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///AttendanceRecordsPage");
        } else {
            await DisplayAlert("Login failed", "Uusername or password is invalid", "Try again");
        }
    }


    bool IsCredentialCorrect(string username, string password) {
        return Username.Text == "admin" && Password.Text == "root";
    }
}
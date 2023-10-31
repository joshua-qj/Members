using Members.MAUI.ViewModels;
using Members.MAUI.Views.Controls;

namespace Members.MAUI.Views;
//[QueryProperty(nameof(StudentId), id)]
public partial class EditStudentPage : ContentPage {
    private readonly StudentViewModel _studentViewModel;

    public EditStudentPage(StudentViewModel studentViewModel) {
        InitializeComponent();
        _studentViewModel = studentViewModel;
        BindingContext = _studentViewModel;
    }

    public string StudentId {
        set {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out int studentId)) {
                LoadContact(studentId);
            }
        }
    }
    private async void LoadContact(int studentId) {
        await _studentViewModel.LoadStudent(studentId);
    }
}
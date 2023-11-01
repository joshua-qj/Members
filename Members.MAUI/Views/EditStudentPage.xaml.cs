using Members.MAUI.ViewModels;
using Members.MAUI.Views.Controls;

namespace Members.MAUI.Views;
[QueryProperty(nameof(StudentId), "Id")]
//[QueryProperty(nameof(TeamId), "Id")]
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
              LoadStudent(studentId);

            }
        }
    }
    private async void LoadStudent(int studentId) {
        await _studentViewModel.LoadStudent(studentId);
        _studentViewModel.Student = await _studentViewModel.LoadStudentWithTeamData(studentId);
        _studentViewModel.SelectedTeam=_studentViewModel.Student.Team;
    }
}
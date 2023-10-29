using Members.MAUI.ViewModels;
using System.Runtime.CompilerServices;

namespace Members.MAUI.Views.Controls;

public partial class StudentControl : ContentView
{
    public bool IsForEdit { get; set; }
    public bool IsForAdd { get; set; }
    public StudentControl() {
        InitializeComponent();
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        base.OnPropertyChanged(propertyName);
        if (IsForAdd && !IsForEdit) {
            btnSave.SetBinding(Button.CommandProperty, "AddStudentCommand");
        } else if (!IsForAdd && IsForEdit) {
            btnSave.SetBinding(Button.CommandProperty, "EditStudentCommand");
        }

    }
}
using System.Runtime.CompilerServices;

namespace Members.MAUI.Views.Controls;

public partial class TeamControl : ContentView {
    public bool IsForEdit { get; set; }
    public bool IsForAdd { get; set; }
    public TeamControl()
	{
		InitializeComponent();
	}

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        base.OnPropertyChanged(propertyName);
        
        if (IsForAdd && !IsForEdit) {
            btnSave.SetBinding(Button.CommandProperty, "AddTeamCommand");
        } else if (!IsForAdd && IsForEdit) {
            btnSave.SetBinding(Button.CommandProperty, "EditTeamCommand");
        }

    }
}
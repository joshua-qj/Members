using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.MAUI.ViewModels {
    public partial class BaseViewModel : ObservableObject {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool _isBusy;
        [ObservableProperty]
        string _title;
        public bool IsNotBusy => !IsBusy;

        //public bool IsBusy {
        //    get => isBusy; set {
        //        if (isBusy == value) {
        //            return;
        //        }
        //        isBusy = value;
        //        //OnPropertyChanged(nameof(isBusy));
        //    }
        //}
    }
}

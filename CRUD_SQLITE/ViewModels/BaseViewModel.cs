using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD_SQLITE.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void SetProperty<T>(ref T field, T Value, [CallerMemberName] string propertyName = "")
        {
            field = Value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

    }
}

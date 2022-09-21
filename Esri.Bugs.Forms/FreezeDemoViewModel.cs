using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Esri.Bugs.Forms
{
    public sealed class FreezeDemoViewModel : INotifyPropertyChanged
    {
        private DateTime _currentTime;

        public FreezeDemoViewModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                CurrentTime = DateTime.Now;
                return true;
            });
        }

        public DateTime CurrentTime
        {
            get => _currentTime;
            set => SetField(ref _currentTime, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
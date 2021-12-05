using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using OnboardingSoftware.App.Models;
using OnboardingSoftware.App.Services;
using OnboardingSoftware.Api;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace OnboardingSoftware.App.ViewModels
{
    public class BaseViewModel : ExtendedBindableObject
    {

        bool isBusy = false;
        public bool _sendingPhoto = true;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public virtual async Task OnAppearing()
        {
            var output = string.Format("ViewModel: {0} is visible", GetType().Name);
            Debug.WriteLine(output);

            await Task.FromResult(true);
        }

        public virtual async Task OnDisappearing()
        {
            var output = string.Format("ViewModel: {0} is disappearing", GetType().Name);
            Debug.WriteLine(output);

            IsBusy = false;

            await Task.FromResult(true);
        }

        internal CancellationTokenSource cts;
    }
}

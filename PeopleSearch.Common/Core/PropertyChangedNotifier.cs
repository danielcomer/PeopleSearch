using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PeopleSearch.Common.Core
{
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetValue<T>(ref T value, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (value.Equals(newValue)) return;

            value = newValue;
            // ReSharper disable once ExplicitCallerInfoArgument
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            VerifyProperty(propertyName);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyProperty(string propertyName)
        {
            var type = GetType();
            var propInfo = type.GetRuntimeProperty(propertyName);

            if (propInfo == null)
            {
                throw new ArgumentException("Invalid Property Name", nameof(propertyName));
            }
        }
    }
}

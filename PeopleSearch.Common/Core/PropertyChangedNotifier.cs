using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
// ReSharper disable ExplicitCallerInfoArgument

namespace PeopleSearch.Common.Core
{
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        protected void SetValue<T>(ref T value, T newValue, IEnumerable<string> affectedProperties, [CallerMemberName] string propertyName = null)
        {
            if (value == null && newValue == null) return;
            if (value != null && value.Equals(newValue)) return;

            value = newValue;

            RaisePropertyChanged(propertyName);

            foreach (var property in affectedProperties)
            {
                RaisePropertyChanged(property);
            }
        }

        protected void SetValue<T>(ref T value, T newValue, [CallerMemberName] string propertyName = null)
        {
            SetValue(ref value, newValue, Enumerable.Empty<string>(), propertyName);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            VerifyProperty(propertyName);

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyProperty(string propertyName)
        {
            if (GetType().GetRuntimeProperty(propertyName) == null)
            {
                throw new ArgumentException("Invalid Property Name", propertyName);
            }
        }
    }
}

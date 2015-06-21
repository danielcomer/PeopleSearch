using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

// ReSharper disable ExplicitCallerInfoArgument

namespace PeopleSearch.Core.ComponentModel
{
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        protected void SetBackingMemberValue<TMember>(ref TMember backingMemberReference, TMember value, IEnumerable<string> affectedPropertyNames = null, [CallerMemberName] string propertyName = null)
        {
            if (backingMemberReference == null && value == null) return;
            if (backingMemberReference != null && backingMemberReference.Equals(value)) return;

            backingMemberReference = value;

            RaisePropertyChanged(propertyName);

            affectedPropertyNames?.ToList().ForEach(RaisePropertyChanged);
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

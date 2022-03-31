using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class StateContainer
    {
        private string? CountryFocus;
        public string CountryFocusProperty
        {
            get => CountryFocus ?? string.Empty;
            set
            {
                CountryFocus = value;
                NotifyStateChanged();
            }
        }

        private string? FocusCode;
        public string FocusCodeProperty
        {
            get => FocusCode ?? string.Empty;
            set
            {
                FocusCode = value;
                NotifyStateChanged();
            }
        }

        private string? Flag;
        public string FlagProperty
        {
            get => Flag ?? string.Empty;
            set
            {
                Flag = value;
                NotifyStateChanged();
            }
        }

        private string? savedCountry;
        public string CountryProperty
        {
            get => savedCountry ?? string.Empty;
            set
            {
                savedCountry = value;
                NotifyStateChanged();
            }
        }

        private string? savedTax;
        public string TaxProperty
        {
            get => savedTax ?? string.Empty;
            set
            {
                savedTax = value;
                NotifyStateChanged();
            }
        }

        private string? savedHsCode;
        public string HsCodeProperty
        {
            get => savedHsCode ?? string.Empty;
            set
            {
                savedHsCode = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

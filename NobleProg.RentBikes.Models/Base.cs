using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.Models
{
    public abstract class Base : INotifyPropertyChanged, IDataErrorInfo
    {
        #region 

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IDataErrorInfo

        private IValidator Validator
        {
            get
            {
                var factory = new AttributedValidatorFactory();

                var validator = factory.GetValidator(GetType());

                return validator;
            }
        }

        public string this[string columnName]
        {
            get { return InputValidation(columnName); }
        }

        public string Error
        {
            get
            {
                if (Validator != null)
                {
                    var results = Validator.Validate(this);

                    return GetErrors(results);
                }

                return string.Empty;
            }
        }

        private string InputValidation(string propertyName)
        {
            var properties = new List<string> { propertyName };

            if (Validator != null)
            {
                var results = Validator.Validate
                    (new ValidationContext(this, new PropertyChain(), new MemberNameValidatorSelector(properties)));

                return GetErrors(results);
            }

            return string.Empty;
        }

        private static string GetErrors(ValidationResult results)
        {
            if (results != null && results.Errors.Any())
            {
                var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                return errors;
            }
            return string.Empty;
        }

        #endregion

    }
}

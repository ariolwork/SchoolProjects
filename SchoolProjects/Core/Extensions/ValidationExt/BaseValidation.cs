using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Extensions.SystemExt.CollectionsExt;

namespace Extensions.ValidationExt
{
    public class BaseValidation
    {
        private IDictionary<string, bool> _elementValidation;

        public BaseValidation()
        {
            _elementValidation = new Dictionary<string, bool>();
        }

        public void ChangeControlValidationValue(Control control, bool value)
        {
            var key = control.Name;
            if (_elementValidation.ContainsKey(key))
            {
                _elementValidation[key] = value;
            }
            else 
            {
                _elementValidation.Add(key, value);
            }
        }

        public bool GetControlValidationValue(Control control)
        {
            var key = control.Name;
            if (!_elementValidation.ContainsKey(key))
            {
                throw new Exception($"Validation element {control.Name} not found");
            }
            return _elementValidation[key];
        }

        public bool GetFullValidationStatus()
        {
            return _elementValidation.Values.Where(e => !e).Count() == 0;
        }
    }
}

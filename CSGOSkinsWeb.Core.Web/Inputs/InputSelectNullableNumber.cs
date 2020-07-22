using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;

namespace CSGOSkinsWeb.Core.Web.Inputs
{
    public class InputSelectNullableNumber<T> : InputSelect<T>
    {
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            if (typeof(T) == typeof(int?))
            {
                if (int.TryParse(value, out int resultInt))
                {
                    result = (T)(object)resultInt;
                }
                else
                {
                    result = default;
                }

                validationErrorMessage = null;
                return true;
            }
            else
            {
                return this.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}

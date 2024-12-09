using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightDrive._Helpers
{
    public enum CustomBoxType
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,

        /// <summary>
        /// Let the user type an input on a rich text box.
        /// </summary>
        TextInput, 

        /// <summary>
        /// Let the user chose from a list a combobox values.
        /// </summary>
        ChoiceInput,
    }
}

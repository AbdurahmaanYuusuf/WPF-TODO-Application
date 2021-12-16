using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WPF_TODO_Application
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType {get; private set;}

        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
            {
                throw new Exception("enumType must not be null and of type Enum");
            }
            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}

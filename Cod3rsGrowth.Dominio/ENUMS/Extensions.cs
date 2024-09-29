using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ENUMS
{
    public static class Extensions
    {
        static public string PegarDescricaoEnum(this ProfissaoEnum valorEnum)
        {
            var field = valorEnum.GetType().GetField(valorEnum.ToString());
            if (field == null)
                return valorEnum.ToString();

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return valorEnum.ToString();
        }
    }
}

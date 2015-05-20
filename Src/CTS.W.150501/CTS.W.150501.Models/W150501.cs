using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Resources.Strings;

namespace CTS.W._150501.Models
{
    /// <summary>
    /// W150501
    /// </summary>
    public class W150501
    {
        /// <summary>
        /// Áp dụng resource
        /// </summary>
        public static void ApplyResources()
        {
            // Load name resource
            AppHelper.LoadNameResources(Names.ResourceManager);
        }
    }
}

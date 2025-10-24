//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.GenericModel
//{
//    public class SelectListEntity
//    {
//        public dynamic? DataValueField { get; set; }
//        public string? DataTextField { get; set; }
//        public string? DataGroupField { get; set; }
//        public string? DataSelectedItem { get; set; }
//        public List<SelectListEntity>? SelectListItem { get; set; }
//    }
//}


using System;
using System.Collections.Generic;

namespace Domain.GenericModel
{
    /// <summary>
    /// Generic class to represent a select list item (dropdown item)
    /// Can be used for simple or nested dropdowns.
    /// </summary>
    /// <typeparam name="T">Type of the value field (int, string, GUID etc.)</typeparam>
    public class SelectListEntity<T>
    {
        /// <summary>
        /// The value that will be submitted when this item is selected
        /// </summary>
        public T? Value { get; set; }

        /// <summary>
        /// Text that will be displayed in the dropdown
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Optional group name for grouping items in dropdown
        /// </summary>
        public string? Group { get; set; }

        /// <summary>
        /// Indicates if this item should be selected by default
        /// </summary>
        public bool Selected { get; set; } = false;

        /// <summary>
        /// Optional list for nested dropdowns
        /// </summary>
        public List<SelectListEntity<T>>? ChildItems { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SelectListEntity()
        {
            ChildItems = new List<SelectListEntity<T>>();
        }
    }
}
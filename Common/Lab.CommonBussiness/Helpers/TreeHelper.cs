using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.CommonBussiness.Helpers
{
    public class TreeHelper
    {
        /// <summary>
        /// 填充树状结构的子集合(children)
        /// </summary>
        /// <param name="parentRecords"></param>
        /// <param name="allRecords"></param>
        /// <param name="idField"></param>
        /// <param name="parentField"></param>
        /// <param name="textField"></param>
        public static void FillChildren(ref List<ExpandoObject> parentRecords, List<ExpandoObject> allRecords, string idField = "ID", string parentField = "ParentID", string textField = "Name")
        {
            for (var i = 0; i < parentRecords.Count(); i++)
            {
                dynamic item = parentRecords[i];
                var children = allRecords.Where(x => (x as IDictionary<string, object>)[parentField]!=null&&(x as IDictionary<string, object>)[parentField].ToString() == (item as IDictionary<string, object>)[idField].ToString()).ToList();
                FillChildren(ref children, allRecords, idField, parentField, textField);
                item.children = children;
                item.id = (parentRecords[i] as IDictionary<string, object>)[idField];
                item.text = (parentRecords[i] as IDictionary<string, object>)[textField];
            }
        }
    }
}

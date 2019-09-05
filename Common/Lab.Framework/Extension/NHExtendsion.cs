using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Lab.Framework
{
    public static class NHExtendsion
    {
        public static IList<dynamic> ToDynamicList(this IQuery query)
        {
            return query.SetResultTransformer(ExpandoObjectResultTransformerHelper.ExpandoObject)
                        .List<dynamic>();
        }
    }

    internal class ExpandoObjectResultTransformerHelper
    {
        public static readonly IResultTransformer ExpandoObject;
        static ExpandoObjectResultTransformerHelper()
        {
            ExpandoObject = new ExpandoObjectResultTransformer();
        }
    }

    internal class ExpandoObjectResultTransformer : IResultTransformer
    {
        public IList TransformList(IList collection)
        {
            return collection;
        }
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            try
            {
                var expando = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)expando;
                for (var i = 0; i < tuple.Length; i++)
                {
                    var alias = aliases[i];
                    if (alias != null)
                    {
                        if (new string[2] { "CHILDREN", "STATE" }.Contains(alias))
                        {
                            alias = alias.ToLower();
                        }
                        if (tuple[i] != null && tuple[i].GetType() == typeof(double))
                        {
                            tuple[i] = Math.Round((double)tuple[i], 10);
                        }
                        dictionary[alias] = tuple[i];
                        if (alias == "CHECKED") {
                            dictionary["checked"] = dictionary[alias].ToString() == "true" ? true : false;
                        }
                    }
                }
                return expando;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

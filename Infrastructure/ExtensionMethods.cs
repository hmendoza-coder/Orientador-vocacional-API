using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI
{
    public static class ExtensionMethods
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower().Equals(column.ColumnName.ToLower())|| pro.Name.ToLower() == column.ColumnName.Replace("_", "").ToLower())
                        pro.SetValue(obj, dr[column.ColumnName], null);
                }
            }
            return obj;
        }
        //public static async Task<List<T>> ToList<T>(this Task<DataTable> dt)
        //{
        //    List<T> data = new List<T>();
        //    foreach (DataRow row in dt.Result.Rows)
        //    {
        //        T item = GetItem<T>(row);
        //        data.Add(item);
        //    }
        //    return data;
        //}

        public static string ToMysqlFormat(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static bool IsNullOrEmpty(this object source)
        {
            return IsNull(source) || source.ToString().Trim().Length == 0;
        }

        public static bool IsNull(this object source)
        {
            return source == null || source == DBNull.Value;
        }
    }
}

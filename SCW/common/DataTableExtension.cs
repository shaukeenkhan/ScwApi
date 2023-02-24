using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace SCW.common
{
    public static class DataTableExtension
    {

        public static DataTable ConvertListToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }


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
            try
            {
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, (dr[column.ColumnName] != DBNull.Value ? dr[column.ColumnName] : null), null);


                        else
                            continue;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return obj;
        }

        public static string GetUniqueFileName(string fileName)
        {

            fileName = Path.GetFileName(fileName);
            return string.Concat(Path.GetFileNameWithoutExtension(fileName), "_", Guid.NewGuid().ToString().AsSpan(0, 4), Path.GetExtension(fileName));


        }

    }
}

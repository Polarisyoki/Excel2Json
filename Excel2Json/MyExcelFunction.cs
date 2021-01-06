using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using ExcelDataReader;
using System.Reflection;
using System.Reflection.Emit;

namespace Excel2Json
{
    class MyExcelFunction
    {
        public enum ExcelType
        { 
            XLS,
            XLSL,
            CSV,
        }


        public static void Transform(string excelPath,string jsonPath ,ExcelType excelType,int rowStart, int colStart = 0)
        {
            using (FileStream stream = File.Open(excelPath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                switch (excelType)
                {
                    case ExcelType.XLS:
                        reader = ExcelReaderFactory.CreateReader(stream);
                        break;
                    case ExcelType.XLSL:
                        reader = ExcelReaderFactory.CreateReader(stream);
                        break;                  
                    case ExcelType.CSV:
                        reader = ExcelReaderFactory.CreateCsvReader(stream);
                        break;
                    default:
                        reader = ExcelReaderFactory.CreateReader(stream);
                        break;
                }            
                var result = reader.AsDataSet();

                Dictionary<string, object> singleTable = new Dictionary<string, object>();
                for (int i = 0; i < result.Tables.Count; i++)
                {
                    List<object> items = new List<object>();
                    System.Data.DataTable table = result.Tables[i];
                    object[] names = table.Rows[0].ItemArray;
                    object[] types = table.Rows[1].ItemArray;
                    for (int j = 0; j < table.Rows.Count - rowStart; j++)
                    {
                        int m = j + rowStart;
                        Type dynType = CreateType("row" + m, GetString(names, colStart), GetString(types, colStart));
                        object myclass = Activator.CreateInstance(dynType);

                        for (int k = 0; k < names.Length - colStart; k++)
                        {
                            int n = k + colStart;
                            FieldInfo fi = dynType.GetField(names[n].ToString());
                            if (fi == null)
                                continue;
                            try
                            {
                                fi.SetValue(myclass, Convert.ChangeType(table.Rows[m][n], GetYourType(types[n].ToString())));
                            }
                            catch
                            {
                                fi.SetValue(myclass, null);
                            }
                        }
                        items.Add(myclass);
                    }
                    singleTable.Add(table.TableName, items);
                }
                JsonManager.WriteToJson(jsonPath, singleTable);
            }
        }

        static Type CreateType(string className, string[] fieldName, string[] fieldType)
        {
            //动态创建程序集
            AssemblyName demoName = new AssemblyName("MyTestExcel");
            AssemblyBuilder dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(demoName, AssemblyBuilderAccess.Run);
            //AssemblyBuilder dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(demoName, AssemblyBuilderAccess.Run);
            //动态创建模块
            ModuleBuilder mb = dynamicAssembly.DefineDynamicModule("MyTestModule");
            //动态创建类
            TypeBuilder tb = mb.DefineType(className, TypeAttributes.Public);
            for (int j = 0; j < fieldName.Length; j++)
            {
                if (fieldName[j] == "" || fieldName[j] == string.Empty)
                    continue;

                //动态创建字段               
                tb.DefineField(fieldName[j], GetYourType(fieldType[j]), FieldAttributes.Public);
            }

            return tb.CreateType();
        }

        static Type GetYourType(string typeName)
        {
            switch (typeName.ToLower())
            {
                case "string":
                    return typeof(string);
                case "float":
                    return typeof(float);
                case "single":
                    return typeof(float);
                case "double":
                    return typeof(double);
                case "int":
                    return typeof(int);
                case "int32":
                    return typeof(int);
                default:
                    return typeof(string);

            }
        }

        static string[] GetString(object[] name, int startIndex = 0)
        {
            List<string> str = new List<string>();
            for (int i = 0; i < name.Length - startIndex; i++)
            {
                int m = i + startIndex;
                str.Add(name[m].ToString());
            }
            return str.ToArray();
        }
    }
}

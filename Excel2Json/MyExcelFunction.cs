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

                var temp = GetClassData(result, rowStart, colStart);
                MyJsonUtils.WriteToJson(jsonPath, temp);
            }
        }

        static Dictionary<string,object> GetClassData(DataSet result, int rowStart, int colStart = 0)
        {
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
                            if(fi.FieldType.IsArray)
                            {
                                var elementType = fi.FieldType.GetElementType();
                                if(elementType.IsArray)
                                {
                                    //int[][] ,string[][]
                                    var elemType2 = elementType.GetElementType();
                                    var str = table.Rows[m][n].ToString();
                                    var strs = table.Rows[m][n].ToString().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                                    Array myArray = Array.CreateInstance(elementType, strs.Length);
                                    for(int p = 0;p<strs.Length;p++)
                                    {
                                        var strs2 = strs[p].Split(new char[] { '|', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                        Array myArray2 = Array.CreateInstance(elemType2, strs2.Length);
                                        for(int q = 0;q < strs2.Length;q++)
                                        {
                                            if (elemType2 == typeof(int))
                                            {
                                                myArray2.SetValue(int.Parse(strs2[q]), q);
                                            }
                                            else if (elemType2 == typeof(string))
                                            {
                                                myArray2.SetValue(strs2[q], q);
                                            }
                                        }
                                        myArray.SetValue(myArray2, p);
                                    }
                                    fi.SetValue(myclass, myArray);
                                }
                                else
                                {
                                    //int[] , string[]
                                    var strs = table.Rows[m][n].ToString().Split(new char[] { '|', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    Array myArray = Array.CreateInstance(elementType, strs.Length);
                                    for (int p = 0; p < strs.Length; p++)
                                    {
                                        if (elementType == typeof(int))
                                        {
                                            myArray.SetValue(int.Parse(strs[p]), p);
                                        }
                                        else if (elementType == typeof(string))
                                        {
                                            myArray.SetValue(strs[p], p);
                                        }
                                    }
                                    fi.SetValue(myclass, myArray);
                                }
                                
                            }                          
                            else
                            {
                                fi.SetValue(myclass, Convert.ChangeType(table.Rows[m][n], GetYourType(types[n].ToString())));
                            }

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
            return singleTable;
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
                if (fieldName[j] == string.Empty)
                    continue;

                try
                {
                    //动态创建字段               
                    tb.DefineField(fieldName[j], GetYourType(fieldType[j]), FieldAttributes.Public);
                }
                catch
                {
                    continue;
                }
                
            }

            return tb.CreateType();
        }

        static Type GetYourType(string typeName)
        {
            switch (typeName.ToLower())
            {
                case "string":
                    return typeof(string);
                case "string[]":
                    return typeof(string[]);
                case "string[][]":
                    return typeof(string[][]);
                case "double":
                    return typeof(double);
                case "int":
                case "int32":
                    return typeof(int);
                case "int[]":
                    return typeof(int[]);
                case "int[][]":
                    return typeof(int[][]);             
                case "float":
                case "single":
                    return typeof(float);
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

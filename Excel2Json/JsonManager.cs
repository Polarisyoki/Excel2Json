using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class JsonManager
{
    public static void WriteToJson<T>(string path, List<T> data)
    {
        string str_write = JsonConvert.SerializeObject(data, Formatting.Indented);
        FileInfo fileWrite = new FileInfo(path);
        StreamWriter sw = fileWrite.CreateText();
        sw.WriteLine(str_write);
        sw.Close();
        sw.Dispose();
        // AssetDatabase.Refresh();
    }

    public static void WriteToJson<T>(string path, T data)
    {
        string str_write = JsonConvert.SerializeObject(data, Formatting.Indented);
        FileInfo fileWrite = new FileInfo(path);
        StreamWriter sw = fileWrite.CreateText();
        sw.WriteLine(str_write);
        sw.Close();
        sw.Dispose();
        // AssetDatabase.Refresh();
    }

    public static void ReadFromJson<T>(string path , out List<T> dataList)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        StreamReader fileStream = new StreamReader(fs);
        string str = "";
        string line;
        while ((line = fileStream.ReadLine()) != null)
        {
            str += line;
        }
        dataList = JsonConvert.DeserializeObject<List<T>>(str);
        fs.Close();
        fs.Dispose();
        fileStream.Close();
        fileStream.Dispose();
    }

    public static void ReadFromJson<T>(string path , out T data)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        StreamReader fileStream = new StreamReader(fs);
        string str = "";
        string line;
        while ((line = fileStream.ReadLine()) != null)
        {
            str += line;
        }
        data = JsonConvert.DeserializeObject<T>(str);
        fs.Close();
        fs.Dispose();
        fileStream.Close();
        fileStream.Dispose();
    }

}

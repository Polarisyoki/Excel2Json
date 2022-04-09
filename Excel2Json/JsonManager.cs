using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class MyJsonUtils
{
    public static void WriteToJson<T>(string path, T data)
    {
        string str_write = JsonConvert.SerializeObject(data, Formatting.Indented);
        FileInfo fileWrite = new FileInfo(path);
        StreamWriter sw = fileWrite.CreateText();
        sw.WriteLine(str_write);
        sw.Close();
        sw.Dispose();
    }

    public static void ReadFromJson<T>(string path , out T data)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        StreamReader fileStream = new StreamReader(fs);
        string str = fileStream.ReadToEnd();
        data = JsonConvert.DeserializeObject<T>(str);
        fs.Close();
        fs.Dispose();
        fileStream.Close();
        fileStream.Dispose();
    }

}

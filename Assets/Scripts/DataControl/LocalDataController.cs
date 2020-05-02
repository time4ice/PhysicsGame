using UnityEngine;
using System.IO;
using System.Text;

using Newtonsoft.Json;

public class LocalDataController
{
    public string Serialize<T>(T jsonObject)
    {
        string json = JsonConvert.SerializeObject(jsonObject);
        return json;
    }

    public T Deserialize<T>(string data)
    {
        T getObject = JsonConvert.DeserializeObject<T>(data);
        return getObject;
    }

    public string LoadData(string nameFile, bool useEncryption = false)
    {
        string finalPath = Path.Combine(Application.persistentDataPath, nameFile);

        string result = string.Empty;

        if (File.Exists(finalPath))
        {
            result = File.ReadAllText(finalPath);
        }

        return result;
    }

    public string LoadDataPath(string path, bool useEncryption = false)
    {
        string finalPath = path;

        string result = string.Empty;

        if (File.Exists(finalPath))
        {
            result = File.ReadAllText(finalPath);
        }

        return result;
    }

    public string LoadDataFromAssets(string nameFile, bool useEncryption = false)
    {
        string path = Path.Combine(Application.dataPath, "Data");

        string finalPath = Path.Combine(path, nameFile);

        string result = string.Empty;

        if (File.Exists(finalPath))
        {
            result = File.ReadAllText(finalPath);
        }

        return result;
    }

    public void SaveData(string namefile, string data)
    {
        string path = Path.Combine(Application.persistentDataPath);

        string finalPath = Path.Combine(path, namefile);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        using (FileStream fs = File.Create(finalPath))
        {
            AddText(fs, data);
        }
    }

    public void SaveData<T>(T jsonObject, string nameFile)
    {
        string path = Path.Combine(Application.persistentDataPath);

        string finalPath = Path.Combine(path, nameFile);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string data = Serialize(jsonObject);
        using (FileStream fs = File.Create(finalPath))
        {
            AddText(fs, data);
        }
    }

    private void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);

        fs.Write(info, 0, info.Length);
    }

}

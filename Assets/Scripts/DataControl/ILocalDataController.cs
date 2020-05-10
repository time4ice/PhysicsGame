public interface ILocalDataController
{
    string Serialize<T>(T jsonObject);

    T Deserialize<T>(string data);

    string LoadData(string nameFile, bool useEncryption = false);

    string LoadDataPath(string path, bool useEncryption = false);

    string LoadDataFromAssets(string nameFile, bool useEncryption = false);

    void SaveData(string namefile, string data);

    void SaveData<T>(T jsonObject, string nameFile);
}

using UnityEngine;
using System.IO;

namespace SaveSystem
{
    public class JsonSaveSystem 
    {
        private readonly string _jsonPath;

        public JsonSaveSystem()
        {
            _jsonPath = Application.persistentDataPath + "/Save.json";
        }

        public void Save(SaveData saveData)
        {
            Debug.Log(_jsonPath);
            string data = JsonUtility.ToJson(saveData);
            
            File.WriteAllText(_jsonPath, data);
        }

        public SaveData Load()
        {
            if (File.Exists(_jsonPath) == false)
            {
                return new SaveData();
            }

            string data = File.ReadAllText(_jsonPath);
            return JsonUtility.FromJson<SaveData>(data);
        }
    }
}
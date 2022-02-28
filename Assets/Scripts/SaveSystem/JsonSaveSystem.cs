using UnityEngine;
using System.IO;

namespace SaveSystem
{
    public class JsonSaveSystem 
    {
        private readonly string _jsonPath;
        private string _data;
        
        public JsonSaveSystem()
        {
            _jsonPath = Application.persistentDataPath + "/Save.json";
        }

        public void Save(SaveData saveData)
        {
            _data = JsonUtility.ToJson(saveData);
            
            File.WriteAllText(_jsonPath, _data);
        }

        public SaveData Load()
        {
            _data = File.ReadAllText(_jsonPath);

            return JsonUtility.FromJson<SaveData>(_data);
        }
    }
}
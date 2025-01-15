using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public float timeElapsed;
    public Color unitColour;

    private void Awake()
    {
        //making sure that there's always only one of this
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        
        //setting this current object (MainManager) as Instance
        Instance = this;

        //making this object persist across scenes
        DontDestroyOnLoad(gameObject);

        loadColour();
    }
    private void Update()
    {
        timeElapsed = Time.time;     
    }

    [System.Serializable]
    class saveData
    {
        public Color _unitColour;
    }
    public void saveColour()
    {
        saveData data = new();
        data._unitColour = unitColour;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }
    public void loadColour()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        saveData data = JsonUtility.FromJson<saveData>(jsonData);
        unitColour = data._unitColour;
    }
}

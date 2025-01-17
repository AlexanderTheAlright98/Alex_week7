using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartManager : MonoBehaviour
{
    public static StartManager instance { get; private set; }
    public TMP_InputField nameInput;
    public string userName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            userName = nameInput.text;
        }
    }
    public void startGame()
    {
        PlayerPrefs.SetString("PlayerName", userName);
        SceneManager.LoadScene(1);
    }
}

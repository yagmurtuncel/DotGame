using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string highScoreText = "HighScore";
    private int currentScore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreText, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreText, value);
        }
    }

    public int CurrentScore
    { get; set;}

    public bool IsInitialized
    { get; set; }

    private void Init()
    {
        CurrentScore = 0;
        IsInitialized  = false;     
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}

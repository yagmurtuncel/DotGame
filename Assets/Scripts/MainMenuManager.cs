using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text newBestScoreText;
    [SerializeField] private TMP_Text highScoreText;

    [SerializeField] private float animationTime;
    [SerializeField] private AnimationCurve speedCurve;

    [SerializeField] private AudioClip clickClip;

    private void Awake()
    {
        highScoreText.text = GameManager.Instance.HighScore.ToString();

        if(!GameManager.Instance.IsInitialized)
        {
            scoreText.gameObject.SetActive(false);
            newBestScoreText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;

        //high score yazısını gösterme
        if(highScore<currentScore)
        {
            newBestScoreText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            newBestScoreText.gameObject.SetActive(false);
        }

        float speed = 1 / animationTime;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)(speedCurve.Evaluate(timeElapsed) * currentScore);
            scoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        scoreText.text = tempScore.ToString();
    }

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(clickClip);
        GameManager.Instance.ToGameplay();
    }
}

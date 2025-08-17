using TMPro;
using UnityEngine;
using UnityEngine.LightTransport;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI missionCompletedText;

    void Awake()
    {
        if (!scoreText)
            scoreText = GetComponentInChildren<TextMeshProUGUI>();

        if (!missionCompletedText)
        {
            foreach (var tmp in GetComponentsInChildren<TextMeshProUGUI>(true))
            {
                if (tmp != scoreText && tmp.name.ToLower().Contains("mission"))
                    missionCompletedText = tmp;
            }
        }
    }

    void Start()
    {
        if (missionCompletedText)
            missionCompletedText.gameObject.SetActive(false); // hide at start

        if (ScoreManager.Instance)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScoreText;
            UpdateScoreText(ScoreManager.Instance.Score);
        }
    }

    void OnDestroy()
    {
        if (ScoreManager.Instance)
            ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
    }

    void UpdateScoreText(int newScore)
    {
        if (scoreText)
            scoreText.text = "Score: " + newScore;

        if (newScore >= 30 && missionCompletedText)
        {
            missionCompletedText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

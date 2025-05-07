using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Elements")]
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    public GameObject winText;
    public GameObject loseText;

    [Header("Game Settings")]
    public float timeLimit = 30f;
    [Range(0, 4)]
    public int decimalPlaces = 1; // New: select how many decimals to show

    private int score = 0;
    private int maxScore;
    private float timer;
    private bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameObject[] clickables = GameObject.FindGameObjectsWithTag("Clickable");
        maxScore = clickables.Length;

        timer = timeLimit;
        winText.SetActive(false);
        loseText.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        if (gameEnded) return;

        timer -= Time.deltaTime;
        if (timer < 0f) timer = 0f;

        string format = "F" + decimalPlaces;
        timerText.text = "Time: " + timer.ToString(format);

        if (timer <= 0f)
        {
            EndGame(false);
        }
    }

    public void AddScore(int value)
    {
        if (gameEnded) return;

        score += value;
        Debug.Log("Score: " + score + " sent from GameManager");

        UpdateUI();

        if (score >= maxScore)
        {
            EndGame(true);
        }
    }

    void UpdateUI()
    {
        countText.text = "Score: " + score + "/" + maxScore;
    }

    void EndGame(bool won)
    {
        gameEnded = true;
        if (won)
        {
            winText.SetActive(true);
        }
        else
        {
            loseText.SetActive(true);
        }
    }
}

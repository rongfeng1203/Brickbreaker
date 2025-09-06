using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseUI : MonoBehaviour
{
    public GameObject panel;
    public GameObject highScore;
    public TMP_Text endtext;
    public TMP_Text finalScoreText;
    public string winText;
    public string loseText;
    public TMP_Text inputFieldText;
    private GameManager gm;
    private ScoreManager sm;


    private bool alreadyDisplayed = false;

    public TMP_Text[] highScoreTexts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
        highScore.SetActive(false);

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        sm = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        displayEndUI();
    }

    private void displayEndUI()
    {
        if (gm.state == GameManager.GameState.Win || gm.state == GameManager.GameState.Lose)
        {
            if (alreadyDisplayed) return;
            alreadyDisplayed = true;
            if (gm.state == GameManager.GameState.Lose)
            {
                endtext.SetText(loseText);
            }
            else if (gm.state == GameManager.GameState.Win)
            {
                endtext.SetText(winText);
            }
            finalScoreText.SetText("Final score: " + gm.GetScore().ToString());

            sm.SaveHighScore();

            if (sm.isNewHighScore())
            {
                highScore.SetActive(true);
            }
            panel.SetActive(true);

            // Show top 3 high scores
            showHighScores();
        }
    }

    public void SetNewName()
    {
        int idx = sm.newIndex();

        if (idx != -1)
        {
            PlayerPrefs.SetString("HighScoreName" + idx, inputFieldText.text);
        }
        showHighScores();
    }

    private void showHighScores()
    {
        string[] topScores = sm.GetHighScores();
            for (int i = 0; i < highScoreTexts.Length && i < topScores.Length; i++)
            {
                highScoreTexts[i].text = topScores[i];
            }
    }
}

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private GameManager gm;
    private bool newHighScore = false;
    private int newHSIndex = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private class Score
    {
        private int score;
        private string name;

        public Score(int score, string name)
        {
            this.score = score;
            this.name = name;
        }

        public Score(int score)
        {
            this.score = score;
            this.name = "Player";
        }

        public void setName(string newName)
        {
            name = newName;
        }
        public int getScore()
        {
            return score;
        }

        public string getName()
        {
            return name;
        }

        public static int Compare(Score x, Score y)
        {
            return x.getScore().CompareTo(y.getScore());
        }
    }

    public void SaveHighScore()
    {
        Score newScore = new Score(gm.GetScore());

        Score[] scores = new Score[4];
        for (int i = 0; i < 3; i++)
        {
            scores[i] = new Score(PlayerPrefs.GetInt("HighScore" + i, 0), PlayerPrefs.GetString("HighScoreName" + i, "Player"));
        }

        scores[3] = newScore;

        System.Array.Sort(scores, Score.Compare);
        System.Array.Reverse(scores);


        for (int i = 0; i < 3; i++)
        {
            if (scores[i] == newScore)
            {
                newHighScore = true;
                newHSIndex = i;
            }
            
            PlayerPrefs.SetInt("HighScore" + i, scores[i].getScore());
            PlayerPrefs.SetString("HighScoreName" + i, scores[i].getName());
        }

        PlayerPrefs.Save();
    }

    public string[] GetHighScores()
    {
        string[] results = new string[3];

        for (int i = 0; i < 3; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            string name = PlayerPrefs.GetString("HighScoreName" + i, "Player");
            results[i] = $"{i + 1}. {name} - {score}";
        }
        return results;
    }

    public bool isNewHighScore()
    {
        return newHighScore;
    }

    public int newIndex()
    {
        return newHSIndex;
    }
}

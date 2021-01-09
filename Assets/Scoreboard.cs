using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public Transform scoreboardContainer;
    public Transform scoreboardEntryTempalte;
    private HighScores highScores;
    private List<Transform> highscoreEntrytranformList;

    /// <summary>
    /// Gets called when the scoreboard is used.
    /// </summary>
    private void Awake()
    {
        

        scoreboardEntryTempalte.gameObject.SetActive(false);

        highScores = new HighScores();

        string jsonString = PlayerPrefs.GetString("scoreboard");

        Debug.Log(jsonString);
        if (jsonString != "")
        {
            highScores = JsonUtility.FromJson<HighScores>(jsonString);
            highscoreEntrytranformList = new List<Transform>();

            foreach (Highscore item in highScores.Highscores)
            {
                CreateHighscoreEntryTransform(item, scoreboardContainer, highscoreEntrytranformList);
            }
            string json = JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString("scoreboard", json);
            PlayerPrefs.Save();
        }
    }
    /// <summary>
    /// Displays the Scoreborad Entrys
    /// </summary>
    /// <param name="highscore">The highscore object</param>
    /// <param name="container">The scoreboardcontainer</param>
    /// <param name="transformList">The list of transforms</param>
    private void CreateHighscoreEntryTransform(Highscore highscore, Transform container, List<Transform> transformList)
    {
        float tempalteHeight = 55f;
        Transform entryTransform = Instantiate(scoreboardEntryTempalte, scoreboardContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, 112 - tempalteHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        int rank = transformList.Count + 1;
        float score = highscore.Score;
        switch (rank)
        {
            default:
                entryTransform.GetComponent<TextMeshProUGUI>().text = rank + "TH: " + score;
                break;
            case 1:
                entryTransform.GetComponent<TextMeshProUGUI>().text = "1ST: " + score;
                break;
            case 2:
                entryTransform.GetComponent<TextMeshProUGUI>().text = "2ND: " + score;
                break;
            case 3:
                entryTransform.GetComponent<TextMeshProUGUI>().text = "3RD: " + score;
                break;
        }
        transformList.Add(entryTransform);
    }
    /// <summary>
    /// Adds a HighscoreEntry to the Highscores list.
    /// </summary>
    /// <param name="score">The given Score.</param>
    public static void AddHighscoreEntry(int score)
    {
        Highscore highscore = new Highscore(score);
        HighScores highscores;
        string jsonString = PlayerPrefs.GetString("scoreboard");
        if (jsonString != "")
        {
            highscores = JsonUtility.FromJson<HighScores>(jsonString);
        }
        else 
        {
            highscores = new HighScores();
        }

        highscores.AddHighScore(highscore);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("scoreboard", json);
        PlayerPrefs.Save();

    }
}
/// <summary>
/// HighScores object acts like a manager for the Highscore object.
/// </summary>
[System.Serializable]
public class HighScores
{
    public List<Highscore> highscores;

    public List<Highscore> Highscores { get => highscores; }

    public HighScores()
    {
        highscores = new List<Highscore>();
    }
    /// <summary>
    /// Adds the given highscore to the highscores list.
    /// </summary>
    /// <param name="highscore">The given highscore that should be added to the list.</param>
    public void AddHighScore(Highscore highscore)
    {
        highscores.Add(highscore);
        SortHighScores();
        RegulateLength();
    }
    /// <summary>
    /// Sorts the HighScore entries.
    /// </summary>
    public void SortHighScores()
    {
        for (int i = 0; i < highscores.Count; i++)
        {
            for (int j = i + 1; j < highscores.Count; j++)
            {
                if (highscores[j].Score > highscores[i].Score)
                {
                    Highscore tmp = highscores[i];
                    highscores[i] = highscores[j];
                    highscores[j] = tmp;
                }
            }
        }
    }
    
    private void RegulateLength()
    {
        if(highscores.Count > 5)
        {
            highscores.RemoveRange(5, highscores.Count - 5);
        }
    }
}
/// <summary>
/// Highscore object represents one Score.
/// </summary>
[System.Serializable]
public class Highscore
{
    public int score;

    public Highscore(int score)
    {
        this.score = score;
    }

    public int Score { get => score; }
}

using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private string KEY_BESTSCORE = "BESTSCORE";
    public ObservableVariable<int> Score { get; private set; }
    public ObservableVariable<int> ScoreRecord { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        Score = new ObservableVariable<int>();
        ScoreRecord = new ObservableVariable<int>();
        LoadScore();

    }

    public void AddScore(int amount)
    {
        Score.Value = Score.Value + amount;

        if (Score.Value > ScoreRecord.Value)
        {
            ScoreRecord.Value = Score.Value;
            SaveBestScore();
        }
    }
    private void LoadScore()
    {
        ScoreRecord.Value = PlayerPrefs.GetInt(KEY_BESTSCORE, 0);
    }
    private void SaveBestScore()
    {
        PlayerPrefs.SetInt(KEY_BESTSCORE, ScoreRecord.Value);
    }
}

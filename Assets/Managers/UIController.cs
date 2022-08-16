
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(ScoreSystem), typeof(PlayerCollision))]
public class UIController : MonoBehaviour
{
    [SerializeField] private ScoreSystem _scoreSystem;
    private ObservableVariable<int> _score;
    private ObservableVariable<int> _bestScore;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private GameObject _gameoverCanvas;
    [SerializeField] private GameObject _gameplayCanvas;
    [SerializeField] private GameObject _coinIcon;

    private void Start()
    {
        _score = _scoreSystem.Score;
        _bestScore = _scoreSystem.ScoreRecord;

        _bestScoreText.text = $"BEST SCORE: {_bestScore.Value}";
        _scoreText.text = _score.Value.ToString();

        _score.OnChanged += ChangedScore;
        _bestScore.OnChanged += ChangedBestScore;

        HideGameOverScreen();

        _playerCollision.OnDeath += DeathPlayer;
        _coinIcon.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);

    }

    private void DeathPlayer() => ShowGameOverScreen();

    private void ChangedBestScore(int obj) => _bestScoreText.text = $"BEST SCORE: {obj}";

    private void ChangedScore(int obj) => _scoreText.text = obj.ToString();

    private void ShowGameOverScreen()
    {
        _gameoverCanvas.SetActive(true);
        _gameOverText.text = $"BEST SCORE: \n {_bestScore.Value}";
        _gameplayCanvas.SetActive(false);

    }
    private void HideGameOverScreen()
    {
        _gameoverCanvas.SetActive(false);
        _gameplayCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        _score.OnChanged -= ChangedScore;
        _bestScore.OnChanged -= ChangedBestScore;
        _playerCollision.OnDeath -= DeathPlayer;
    }
   
}

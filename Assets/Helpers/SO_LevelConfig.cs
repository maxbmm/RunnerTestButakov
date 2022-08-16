using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableObject", menuName = "Config")]
public class SO_LevelConfig : ScriptableObject
{
    [Header("Lines Setup")]
    [SerializeField] private Vector3[] _lines = { new Vector3(-2f, 0, 10), new Vector3(0, 0, 10), new Vector3(2f, 0, 10) };
    [SerializeField] private GameObject _linePrefab;

    [Header("Coins Setup")]
    [SerializeField] private int _coinLayerIndex = 3;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _minCountCoinPath;
    [SerializeField] private int _maxCountCoinPath;
    [SerializeField] private float _distanceBeetwenCoin;

    [Header("Obstacle Setup")]
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private int _obstacleLayerIndex = 8;
    public Vector3[] Lines => this._lines;
    public int CoinLayerIndex => this._coinLayerIndex;
    public int MinCountCoinPath => this._minCountCoinPath;
    public int MaxCountCoinPath => this._maxCountCoinPath;
    public float DistanceBeetwenCoin => this._distanceBeetwenCoin;
    public GameObject CoinPrefab => this._coinPrefab;
    public GameObject ObstaclePrefab => this._obstaclePrefab;
    public GameObject LinePrefab => this._linePrefab;

    public int ObstacleLayerIndex => this._obstacleLayerIndex;
}

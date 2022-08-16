using UnityEngine;

public class Emmiter : MonoBehaviour
{
    private SO_LevelConfig config;
    private Vector3 _lastSpawnPoint;
    private LayerMask _layerMask;
    
    [SerializeField] private GameObject[] _envSegment;

    private GameObject[] _lines = new GameObject[3];

    private void Awake()
    {
        config = Resources.Load<SO_LevelConfig>("LevelConfig");
    }
    private void Start()
    {
        _layerMask = gameObject.layer;
        CreateSection();

    }
    private void SpawnCoin(Transform _section)
    {
        var _lengthCoinPath = Random.Range(config.MinCountCoinPath, config.MaxCountCoinPath);
        var _spawnLine = GetRandomLine();

        for (int i = 0; i < _lengthCoinPath; i++)
        {
            var _spawnPosition = new Vector3(transform.position.x + _spawnLine.transform.position.x, transform.position.y + 1, transform.position.z + i* config.DistanceBeetwenCoin);

            
            GameObject coinFromPool = ObjectPool.SharedInstance.GetPooledObject();

            if (coinFromPool != null)
            {
                coinFromPool.transform.position = _spawnPosition;
                coinFromPool.SetActive(true);
                coinFromPool.transform.SetParent(_section);
            }
            _lastSpawnPoint = _spawnPosition;
        }

        if (Random.value > 0.5f)
        {
            Instantiate(config.ObstaclePrefab, new Vector3(_lastSpawnPoint.x, _lastSpawnPoint.y-0.7f, _lastSpawnPoint.z + config.DistanceBeetwenCoin), Quaternion.identity).gameObject.transform.SetParent(_section);
        }

    }

    private void CreateLines(Transform _section)
    {
        for (int i = 0; i < config.Lines.Length; i++)
        {
            _lines[i] = Instantiate(config.LinePrefab, config.Lines[i], Quaternion.identity);
            _lines[i].gameObject.transform.SetParent(_section);
        }
        
    }
    private void CreateEnvironment(Transform _section)
    {
        var _envObj = Instantiate(_envSegment[Random.Range(0,_envSegment.Length)], new Vector3(config.Lines[1].x+7, config.Lines[1].y, config.Lines[1].z+10), Quaternion.identity);
        _envObj.gameObject.transform.SetParent(_section);
    }

    private void CreateSection()
    {
        GameObject section = new GameObject("Section");

        section.layer = _layerMask;

        section.AddComponent<BoxCollider>().isTrigger = true;
        section.AddComponent<Section>();

        CreateEnvironment(section.transform);

        CreateLines(section.transform);
        SpawnCoin(section.transform);
    }
      
    private GameObject GetRandomLine()
    {
        return _lines[ Random.Range(0, config.Lines.Length) ];
    }

    private void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.layer == _layerMask)
        {
            CreateSection();
        }

    }
    
}

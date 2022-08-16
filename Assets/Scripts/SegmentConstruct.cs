using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentConstruct : Push, IIRespawnable
{
    private int[] _lines = { -1, 0, 1 };
    //private Vector3 _segmentPosition;
    [SerializeField] private GameObject _prefabLine;
    [SerializeField] private GameObject _prefabObstacle;
    [SerializeField] private GameObject _prefabCoin;

    private int _lineAmount = 3;
    private int _obstacleCount = 3;
    private int _minLengthCoin = 4;
    private int _maxLengthCoin = 10;
    private float _distanceBetweenCoin = 0.5f;

    void Start()
    {
        SpawnLines();
        CreateCoinPath();
    }
   
    private void SpawnLines()
    {
        GameObject _line = Instantiate(_prefabLine, new Vector3(0,0,0), Quaternion.identity);
        _line.transform.SetParent(transform);
        /*for (int i = 0; i < _lineAmount; i++)
        {
            Vector3 _parentPos = transform.position;
            Vector3 _pos = new Vector3(_parentPos.x + i, 0 + _parentPos.y, 0 + _parentPos.z);
            GameObject _line = Instantiate(_prefabLine, _pos, Quaternion.identity);
            _line.transform.SetParent(transform);
        }*/
    }
    private void CreateCoinPath()
    {
        int _currentLine = _lines[Random.Range(0, 3)];
        int _currentRow = Random.Range(1, 6);
        int _pathLength = Random.Range(_minLengthCoin, _maxLengthCoin);
        for (int i = 0; i < _pathLength; i++)
        {
            Vector3 _positionCoin = new Vector3(_currentLine, 0.3f, _currentRow-5+i*_distanceBetweenCoin);

            GameObject _coin = ObjectPool.SharedInstance.GetPooledObject();

            if (_coin != null)
            {
                _coin.transform.position = _positionCoin;
                _coin.transform.rotation = Quaternion.identity;
                _coin.SetActive(true);
                _coin.transform.SetParent(transform);
            }

            /*var _coin = SpawnCoin(_positionCoin);
            _coin.SetActive(true);
            _coin.transform.SetParent(transform);*/
        }
    }
    private GameObject SpawnCoin(Vector3 _position) 
    {
        return Instantiate(_prefabCoin, _position, Quaternion.identity);
    }
    private void SpawnObstacle(Vector3 _position)
    {
        Instantiate(_prefabObstacle, _position, Quaternion.identity);
    }

    public void Respawn()
    {
        transform.position = new Vector3(-1, 0, 3);
        CreateCoinPath();
        gameObject.SetActive(true);
    }
}

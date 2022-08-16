using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _segmentPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_segmentPrefab, new Vector3(0, 0, i * 10), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

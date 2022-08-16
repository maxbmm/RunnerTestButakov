using DG.Tweening;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private SO_LevelConfig config;
    private void Awake()
    {
        config = Resources.Load<SO_LevelConfig>("LevelConfig");
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (Transform child in other.gameObject.transform)
        {
            if (child.gameObject.layer == config.CoinLayerIndex)
            {
                DOTween.Kill(child.gameObject);
                child.gameObject.SetActive(false);
           
            }
            else
            {
                DOTween.Kill(child.gameObject);
                Destroy(child.gameObject);
            }
            
        }

        other.gameObject.transform.DetachChildren();
        DOTween.Kill(other.gameObject);
        Destroy(other.gameObject);
    }
}

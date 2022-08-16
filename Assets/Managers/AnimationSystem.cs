using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    private SO_LevelConfig config;
    private int _currentLine = 1;
    private Vector3 _defaultScale;

    private void Awake()
    {
        config = Resources.Load<SO_LevelConfig>("LevelConfig");

    }
    private void Start()
    {
        _defaultScale = transform.localScale;
        transform.position = new Vector3(config.Lines[_currentLine].x, transform.position.y, transform.position.z);
        transform.DOLocalMoveY(config.Lines[_currentLine].y + 0.3f, 0.2f).SetLoops(-1).SetEase(Ease.OutBack);
        StartCoroutine(RotateCoin());
    }
    public void StopMove()
    {
        StopAllCoroutines();
        DOTween.KillAll(this.gameObject);
    }
    public void CollectAnimation()
    {
        
        transform.DOScale(1.15f, 0.2f).SetEase(Ease.InOutBack).OnComplete(() =>
        {
            transform.localScale = _defaultScale;
        });
    }

    private IEnumerator RotateCoin()
    {
        var pool = ObjectPool.SharedInstance.pooledObjects;

        while (true)
        {
            
            for (int i = 0; i < pool.Count; i++)
            {

                if (pool[i] != null)
                {
                
                    pool[i].gameObject.transform.DOLocalRotate(new Vector3(0, 90+i, 0), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
                }
            }
            yield return new WaitForSeconds(1f);
        }

    }
}

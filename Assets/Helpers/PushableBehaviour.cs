using System.Collections.Generic;
using UnityEngine;

public abstract class PushableBehaviour : MonoBehaviour
{
    private bool _isRun = true;
    private float _speed = 10.0f;

    public virtual void StopRun()
    {
        _isRun = false;
    }
    public virtual void StartRun()
    {
        _isRun = true;
    }

    private static readonly HashSet<PushableBehaviour> instances = new HashSet<PushableBehaviour>();

    public static HashSet<PushableBehaviour> Instances => new HashSet<PushableBehaviour>(instances);

    protected virtual void Awake()
    {
       
        instances.Add(this);
    }

    protected virtual void OnDestroy()
    {
        
        instances.Remove(this);
    }
    protected virtual void Update()
    {
        if (_isRun)
        {
            transform.Translate(new Vector3(0, 0, -1) * _speed * Time.deltaTime);
        }
    }

   
}

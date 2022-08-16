using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Push : MonoBehaviour
{
    private Vector3 _segmentPosition;
    private void Start()
    {
        _segmentPosition = GetComponent<Transform>().position;
    }
    public virtual void MoveOutOfBound()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -30), 2 * Time.deltaTime);
    }
    private void Update()
    {
        MoveOutOfBound();
    }
}

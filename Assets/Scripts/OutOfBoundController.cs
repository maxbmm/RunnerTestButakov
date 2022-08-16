using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OutOfBoundController : MonoBehaviour
{
    private const int _segmentLayerIndex = 8;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _segmentLayerIndex)
        {
            other.gameObject.SetActive(false);
            Debug.Log($"{other.name} is out of bound...");
            IIRespawnable _respawnable = other.GetComponent<IIRespawnable>();
            if (_respawnable != null)
            {
                _respawnable.Respawn();
            }
        } else
        {
            Debug.Log(other.gameObject.layer);
        }
        
    }
}

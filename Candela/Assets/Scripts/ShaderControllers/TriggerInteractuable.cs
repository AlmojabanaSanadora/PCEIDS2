using System;
using UnityEngine;

public class TriggerInteractuable : MonoBehaviour
{
    private GameObject parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeLayer("OutlineObjects");
        }
    }

    void OnTriggerExit(Collider other)
    {
        ChangeLayer("Default");
    }

    void ChangeLayer(String layerName)
    {
        int layer = LayerMask.NameToLayer(layerName);
        parent.layer = layer;
    }
}

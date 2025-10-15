using System;
using UnityEngine;

public class MasterInteractuable : MonoBehaviour
{
    private GameObject[] interactuables;
    LayerMask layerMask;

    void Start()
    {
        interactuables = GameObject.FindGameObjectsWithTag("Interactuable");
        for(int i = 0; i < interactuables.Length; i++)
        {
            ChangeLayer("OutlineObjects", interactuables[i]);
            AddTrigger(interactuables[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLayer(String layerName, GameObject interactuable)
    {
        int layer = LayerMask.NameToLayer(layerName);
        interactuable.layer = layer;
    }
    
    void AddTrigger(GameObject interactuable)
    {
        GameObject trigger = new GameObject("Trigger" + interactuable.name);

        trigger.transform.SetParent(interactuable.transform);

        trigger.transform.localPosition = Vector3.zero;

        trigger.transform.localScale = interactuable.transform.localScale * 2;

        trigger.AddComponent<SphereCollider>();

        SphereCollider colliderTrigger = trigger.GetComponent<SphereCollider>();

        colliderTrigger.isTrigger = true;

    }
}

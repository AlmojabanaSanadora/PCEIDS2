using System;
using UnityEngine;

public class MasterInteractuable : MonoBehaviour
{
    private GameObject[] interactuables;

    void Start()
    {
        interactuables = GameObject.FindGameObjectsWithTag("Interactuable");
        for(int i = 0; i < interactuables.Length; i++)
        {
            AddTrigger(interactuables[i]);
        }
        
    }
    
    void AddTrigger(GameObject interactuable)
    {
        GameObject trigger = new GameObject("Trigger" + interactuable.name);

        trigger.AddComponent<TriggerInteractuable>();

        trigger.transform.SetParent(interactuable.transform);

        trigger.transform.localPosition = Vector3.zero;

        trigger.transform.localScale = interactuable.transform.localScale * 2;

        trigger.AddComponent<SphereCollider>();

        SphereCollider colliderTrigger = trigger.GetComponent<SphereCollider>();

        colliderTrigger.isTrigger = true;

    }
}

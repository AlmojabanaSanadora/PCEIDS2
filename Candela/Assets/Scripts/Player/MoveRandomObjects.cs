using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomObjects : MonoBehaviour
{
    public float maxForce = 10f;
    public float minVelocidad = 0.1f;
    public float timeToAutoMove = 10f;

    public List<Rigidbody> objectsToMove = new List<Rigidbody>();


    private void Start()
    {
        StartCoroutine(AutoMoveObjects());
    }

    public void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Movible")) return;
        objectsToMove.Add(other.GetComponent<Rigidbody>());
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Movible")) return;
        objectsToMove.Remove(other.GetComponent<Rigidbody>());
    }

    IEnumerator AutoMoveObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToAutoMove);
            if(objectsToMove.Count == 0) continue;
            int randomIndex = Random.Range(0, objectsToMove.Count);
            Rigidbody rb = objectsToMove[randomIndex];
            if (rb != null && rb.linearVelocity.magnitude <= minVelocidad)
            {
                MoveObject(rb);
            }
        }
    }

    public void MoveObject(Rigidbody rb)
    {
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(0, 1f), Random.Range(-1f, 1f)).normalized;
        float fuerza = Random.Range(5, maxForce);
        rb.AddForce(direction * fuerza, ForceMode.VelocityChange);
    }
}

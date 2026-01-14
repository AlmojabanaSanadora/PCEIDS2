using UnityEngine;

public class InLight : MonoBehaviour
{
    bool inZone = false;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            inZone = false;
        }
    }
}

using Unity.Cinemachine;
using UnityEngine;

public class CalleCamara : MonoBehaviour
{
    public CinemachineCamera activa, desactiva;
    public GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activa.Priority = 1;
            desactiva.Priority = 0;
            trigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

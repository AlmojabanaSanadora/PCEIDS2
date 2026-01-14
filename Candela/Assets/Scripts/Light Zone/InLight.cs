using UnityEngine;

public class InLight : MonoBehaviour
{
    public PlayerManager player;

    private void Update() {
        Debug.Log("en zona?: " + player.inZone);    
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            player.inZone = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            player.inZone = false;
        }
    }
}

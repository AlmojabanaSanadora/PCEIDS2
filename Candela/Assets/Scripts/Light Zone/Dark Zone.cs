using UnityEngine;
public class DarkZone : MonoBehaviour
{   
   public PlayerManager player;

   public Transform respawn;

   private void OnCollisionStay(Collision other) {
    if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("sexo");
            if (player.inZone == false)
            {
                Debug.Log("sexo");
                other.transform.position = respawn.position;
            }
        }  
   }
}

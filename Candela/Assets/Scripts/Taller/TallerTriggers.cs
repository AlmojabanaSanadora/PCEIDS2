using UnityEngine;

public class TallerTriggers : MonoBehaviour
{
    public enum TallerZone
    {
        Zona1,
        Zona2,
        Taller
    }

    public TallerZone zone;

    public TallerManager tallerManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tallerManager != null)
            {
                switch (zone)
                {
                    case TallerZone.Zona1:
                        tallerManager.changeCamera(tallerManager.camZona1);
                        break;
                    case TallerZone.Zona2:
                        tallerManager.endTallerAnimation();
                        break;
                    case TallerZone.Taller:
                        tallerManager.startTallerAnimation();
                        break;
                }
            }
        }
    }
}

using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public InformacionTexto informacionTexto;
    public enum TextType
    {
        Taller, Guia
    }
    public TextType typeInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(typeInteraction == TextType.Taller)
            {
                informacionTexto.ShowTallerInformation();
            }
            else if(typeInteraction == TextType.Guia)
            {
                informacionTexto.ShowGuiaInformation();
            }
        }
    }
}

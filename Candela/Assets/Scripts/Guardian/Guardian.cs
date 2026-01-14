using System.Collections;
using TMPro;
using UnityEngine;

public class Guardian : MonoBehaviour
{
    public PlayerManager playerManager;
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI textoUI;
    public float velocidadLetra = 0.05f;
    private string[] mensajes = new string[]
    {
    "No puede ser...",
    "Esto no puede estar pasando.",
    "¿Acaso...?",
    "¡Oye tú! ¿Acaso fuiste tú quien liberó a esos pequeños espíritus?",
    "Sí... claro que sí. Puedo verlo en tu interior.",
    "Tal vez tú seas quien pueda salvarnos.",
    "Debes ayudarme a rescatar a los espíritus de las cercanías.",
    "Ellos te guiarán y te mostrarán el camino para salvar nuestro mundo."
    };

    private bool jugadorCerca = false;
    private bool estaHablando = false;
    private int indiceMensaje = 0;
    private Coroutine currentCoroutine;

    public GameObject interactuar;

    private void Update()
    {
        if(jugadorCerca)
        {
            interactuar.SetActive(true);
        }
        else
        {
            interactuar.SetActive(false);
        }
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
                textoUI.text = mensajes[indiceMensaje];
            }
            else
            {
                if (!estaHablando)
                {
                    StartTalk();
                }
                else
                {
                    indiceMensaje++;

                    if (indiceMensaje < mensajes.Length)
                    {
                        Talk(mensajes[indiceMensaje]);
                    }
                    else
                    {
                        EndTalk();
                    }
                }
            }
        }
    }

    public void StartTalk()
    {
        playerManager.isAnimation = true;
        estaHablando = true;
        indiceMensaje = 0;
        canvasGroup.gameObject.SetActive(true);
        currentCoroutine = StartCoroutine(AparecerYEscribir(mensajes[indiceMensaje]));
    }

    public void Talk(string mensaje)
    {
        currentCoroutine = StartCoroutine(EscribirTexto(mensaje));
    }

    public void EndTalk()
    {
        playerManager.isAnimation = false;
        estaHablando = false;
        canvasGroup.gameObject.SetActive(false);
        textoUI.text = "";
    }

    private IEnumerator AparecerYEscribir(string texto)
    {
        float timer = 0.5f;
        float elapsed = 0f;

        while (elapsed < timer)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = elapsed / timer;
            yield return null;
        }
        canvasGroup.alpha = 1;

        yield return EscribirTexto(texto);
    }

    public IEnumerator EscribirTexto(string textoAMostrar)
    {
        textoUI.text = "";
        foreach (char letra in textoAMostrar.ToCharArray())
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadLetra);
        }
        currentCoroutine = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            EndTalk();
        }
    }
}
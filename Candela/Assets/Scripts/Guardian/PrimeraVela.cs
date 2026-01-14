using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PrimeraVela : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject noPasar;
    public GameObject final;
    public GameObject guia;

    public PlayableDirector director;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finalDemo()
    {
        final.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (PlayerStats.instance.spiritCount < 6)
                ActivarNoPasar();
            else
                ActivarVela();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            if (PlayerStats.instance.spiritCount < 6)
                DesactivarNoPasar();
    }

    public void ActivarVela()
    {
        playerManager.gameObject.SetActive(false);
        guia.SetActive(false);
        director.Play();
    }

    public void ActivarNoPasar()
    {
        noPasar.SetActive(true);
    }
    public void DesactivarNoPasar()
    {
        noPasar.SetActive(false);
    }

}

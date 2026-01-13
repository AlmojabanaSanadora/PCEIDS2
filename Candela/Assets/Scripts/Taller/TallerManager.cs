using System.Collections;
using Unity.Cinemachine;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Playables;

public class TallerManager : MonoBehaviour
{
    [Header("Triggers")]
    public GameObject triggerZona1ATaller, triggerTallerAZona1, triggerZona2ATaller, triggerTallerAZona2;

    [Header("Cinemachine Cameras")]
    public CinemachineCamera camZona1, camtaller, camZona2, camZona3;

    [Header("Player")]
    public PlayerManager playerManager;
    public bool enTaller;

    [Header("Puertas Corruptas")]
    public GameObject[] puertasCorruptas;
    public float timeToWait = 2f;

    private void Start()
    {
        triggerZona1ATaller.SetActive(true);
        triggerTallerAZona1.SetActive(false);
        triggerZona2ATaller.SetActive(true);
        triggerTallerAZona2.SetActive(false);
    }

    public void startTallerAnimation()
    {
        if (playerManager != null)
        {
            playerManager.isAnimation = true;
            StartCoroutine(EntrarEnTaller());
        }
    }

    public void endTallerAnimation()
    {
        if (playerManager != null)
        {
            playerManager.isAnimation = true;
            StartCoroutine(SalirDeTaller());
        }
    }

    IEnumerator EntrarEnTaller()
    {
        changeCamera(camtaller);
        triggerZona1ATaller.SetActive(false);
        triggerTallerAZona1.SetActive(true);
        triggerZona2ATaller.SetActive(false);
        triggerTallerAZona2.SetActive(true);
        closePuertasCorruptas();

        float timer = 0f;
        float valorInicialFog = 0.02f;
        float valorFinalFog = 0f;
        while (timer <= timeToWait)
        {
            timer+= Time.deltaTime;
            RenderSettings.fogDensity = Mathf.Lerp(valorInicialFog, valorFinalFog, timer / timeToWait);
            yield return null;
        }
        RenderSettings.fogDensity = valorFinalFog;
        playerManager.isAnimation = false;
    }

    IEnumerator SalirDeTaller()
    {
        changeCamera(camZona2);
        triggerZona1ATaller.SetActive(true);
        triggerTallerAZona1.SetActive(false);
        triggerZona2ATaller.SetActive(true);
        triggerTallerAZona2.SetActive(false);
        closePuertasCorruptas();

        float timer = 0f;
        float valorInicialFog = 0f;
        float valorFinalFog = 0.02f;
        while (timer <= timeToWait)
        {
            timer += Time.deltaTime;
            RenderSettings.fogDensity = Mathf.Lerp(valorInicialFog, valorFinalFog, timer / timeToWait);
            yield return null;
        }
        RenderSettings.fogDensity = valorFinalFog;
        playerManager.isAnimation = false;
        changeCamera(camZona3);
    }

    public void changeCamera(CinemachineCamera to)
    {
        camZona1.Priority = 0;
        camtaller.Priority = 0;
        camZona2.Priority = 0;
        camZona3.Priority = 0;
        to.Priority = 1;
    }

    public void closePuertasCorruptas()
    {
        Debug.Log("Cerrando puertas corruptas");
        foreach (GameObject puerta in puertasCorruptas)
        {
            puerta.SetActive(true);
            puerta.transform.GetChild(0).gameObject.SetActive(true);
            puerta.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        }
    }
}

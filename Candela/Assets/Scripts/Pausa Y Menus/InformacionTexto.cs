using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformacionTexto : MonoBehaviour
{
    [Header("Configuración")]
    public float filled;
    public Image targetImage;

    public TextMeshProUGUI guia, informacion, taller;

    private KeyCode[] keysToTrack = {
        KeyCode.W,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.Space
    };

    private bool[] activatedKeys;
    private bool tutorialCompleted = false;

    public Pausa pausaMenu;

    void Start()
    {
        activatedKeys = new bool[keysToTrack.Length];

        guia.transform.parent.gameObject.SetActive(true);
        informacion.transform.parent.gameObject.SetActive(false);
    }

    void Update()
    {
        if(pausaMenu.juegoPausado) return;
        CheckInputs();
        CalculateFilled();
    }

    private void CheckInputs()
    {
        for (int i = 0; i < keysToTrack.Length; i++)
        {
            if (Input.GetKeyDown(keysToTrack[i]) && !activatedKeys[i])
            {
                activatedKeys[i] = true;
            }
        }
    }

    private void CalculateFilled()
    {
        int counter = 0;
        foreach (bool activated in activatedKeys)
        {
            if (activated) counter++;
        }
        
        filled = counter;
        targetImage.fillAmount = filled / keysToTrack.Length;

        if (filled >= keysToTrack.Length && !tutorialCompleted)
        {

            if (guia.transform.parent.gameObject.activeInHierarchy)
            {
                StartCoroutine(ChangeInformation(guia, informacion));
                StartCoroutine(HideImageTutorial());
            }
            tutorialCompleted = true;
        }
    }

    IEnumerator HideImageTutorial() 
    { 
        float duration = 1f;
        float elapsed = 0f;
        Image image = targetImage;
        while (elapsed < duration)
        {
            float alpha = 1 - (elapsed / duration);
            Color color = image.color;
            color.a = alpha;
            image.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        Color finalColor = image.color;
        finalColor.a = 0f;
        image.color = finalColor;
    }

    public void ShowTallerInformation()
    {
        if (guia.transform.parent.gameObject.activeInHierarchy)
        {
            StartCoroutine(ChangeInformation(guia, taller));
            StartCoroutine(HideImageTutorial());
        }
        else
            StartCoroutine(ChangeInformation(informacion, taller));
    }

    public void ShowGuiaInformation()
    {
        if (guia.transform.parent.gameObject.activeInHierarchy)
        {
            StartCoroutine(ChangeInformation(guia, informacion));
            StartCoroutine(HideImageTutorial());
        }
        else
            StartCoroutine(ChangeInformation(taller, informacion));
    }

    IEnumerator ChangeInformation(TextMeshProUGUI text1, TextMeshProUGUI text2)
    {
        text1.transform.parent.gameObject.SetActive(true);
        text2.transform.parent.gameObject.SetActive(true);
        text2.alpha = 0f;

        float duration = 1f;
        
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float alpha = elapsed / duration;
            text1.alpha = 1 - alpha;
            elapsed += Time.deltaTime;
            yield return null;
        }

        text1.transform.parent.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        float elapsed2 = 0f;
        while(elapsed2 < duration)
        {
            float alpha = elapsed2 / duration;
            text2.alpha = alpha;
            elapsed2 += Time.deltaTime;
        }
    }
}

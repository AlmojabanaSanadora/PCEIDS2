using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public CanvasGroup spiritCanvasGroup;
    public TextMeshProUGUI spiritText;

    public GameObject spiritAnimation;
    public Transform startAnimationPosition;
    public Transform endAnimationPosition;

    public int spiritCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        spiritCanvasGroup.alpha = 0;
    }

    private void Update()
    {
        spiritText.text = spiritCount.ToString();
    }

    public void AddSpirit()
    {
        if (spiritCount == 0)
        {
            StartCoroutine(ShowSpirits());
        }
        GetSpiritAnimation();
    }

    public void GetSpiritAnimation()
    {
        StartCoroutine(SpiritAnimation());
    }

    IEnumerator SpiritAnimation()
    {
        spiritAnimation.SetActive(true);
        RectTransform rect = spiritAnimation.GetComponent<RectTransform>();
        float timer = 1f;
        float elapsed = 0f;

        while (elapsed < timer)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = elapsed / timer;
            float scaleT;
            if (normalizedTime <= 0.5f)
            {
                scaleT = normalizedTime * 2f;
                rect.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, scaleT);
            }
            else
            {
                scaleT = (normalizedTime - 0.5f) * 2f;
                rect.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, scaleT);
            }

            rect.position = Vector3.Lerp(startAnimationPosition.position, endAnimationPosition.position, normalizedTime);

            yield return null;
        }

        rect.localScale = Vector3.zero;
        rect.position = startAnimationPosition.position;
        spiritAnimation.SetActive(false);
        spiritCount++;
    }

    IEnumerator ShowSpirits()
    {
        float timer = 1f;
        float elapsed = 0f;
        while (elapsed <= timer)
        {
            elapsed += Time.deltaTime;
            spiritCanvasGroup.alpha = Mathf.Lerp(0, 1, elapsed / timer);
            yield return null;
        }
    }
}

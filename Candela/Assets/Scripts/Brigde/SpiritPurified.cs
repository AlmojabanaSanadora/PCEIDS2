using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class SpiritPurified : MonoBehaviour
{
    public GameObject gate;

    public float maxPurificationTime = 3f;
    private float purificationTime = 3f;

    public GameObject spiritOut;
    public GameObject spiritIn;

    public ParticleSystem[] particleSystems;

    public UnityEngine.Color[] colors;

    private bool isPurified = false;
    public GameObject purificationProgressUI;
    public Image purifiedProgressImage;
    private void Start()
    {
        purificationTime = maxPurificationTime;
        spiritIn.GetComponent<Renderer>().material.color = colors[0];
        spiritOut.GetComponent<Renderer>().material.color = colors[1];
        particleSystems[0].Play();
        particleSystems[1].Stop();
    }
    public void Purified()
    {
        purificationTime -= Time.deltaTime;
        if (!isPurified)
        {
            if (purificationTime <= 0f)
            {
                OpenGate();
            }
            if (purificationTime <= maxPurificationTime)
            {
                purificationProgressUI.SetActive(true);
                purifiedProgressImage.fillAmount = 1 - (purificationTime / maxPurificationTime);
            }
            else
                purificationProgressUI.SetActive(false);
        }
        else
            purificationProgressUI.SetActive(false);
    }

    public void StopPurified()
    {
        if (!isPurified)
        {
            if (purificationTime <= maxPurificationTime)
            {
                purificationTime += Time.deltaTime;
                purificationProgressUI.SetActive(true);

            }
            else
                purificationProgressUI.SetActive(false);


            if (purificationProgressUI.activeInHierarchy)
            {
                purifiedProgressImage.fillAmount = 1 - (purificationTime / maxPurificationTime);
            }
        }
        else 
            purificationProgressUI.SetActive(false);
    }

    public void OpenGate()
    {
        spiritIn.GetComponent<Renderer>().material.color = colors[2];
        spiritOut.GetComponent<Renderer>().material.color = colors[3];
        particleSystems[1].Play();
        particleSystems[0].Stop();
        isPurified = true;
        if (gate != null)
        {            
            gate.transform.GetChild(0).gameObject.SetActive(false);
            gate.transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
        }
    }
}

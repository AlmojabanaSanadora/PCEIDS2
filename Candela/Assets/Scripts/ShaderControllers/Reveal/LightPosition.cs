using System;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

public class LightPosition : MonoBehaviour
{
    [SerializeField]
    private Transform TriggerCenter;

    [SerializeField]
    private Renderer targetRenderer;

    public float fadeStart = 1f;
    public float fadeEnd = 5f;

    int lightPosID, testID;

    void Start()
    {
        lightPosID = Shader.PropertyToID("_lightPosition");
        testID = Shader.PropertyToID("_Test");
    }
    
    void Update()
    {
        if (TriggerCenter && targetRenderer)
        {
            
            Debug.Log(TriggerCenter.position);
            Material material = targetRenderer.material;
            material.SetFloat(testID, 1.5f);
            material.SetVector(lightPosID, TriggerCenter.position);
        }
    }
}

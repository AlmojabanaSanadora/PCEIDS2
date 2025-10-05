using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Splines;
using Unity.Mathematics;
public class CamTrigger : MonoBehaviour
{
    public bool isStay;
    public CamerasList allCameras;
    public CinemachineCamera currentCamera;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        allCameras = FindFirstObjectByType<CamerasList>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isStay)
        {
            if (other.CompareTag("Player"))
            {
                foreach(CinemachineCamera cam in allCameras.allCameras)
                {
                    cam.Priority = 0;
                }
                currentCamera.Priority = 10;
            }
        }
    }
}

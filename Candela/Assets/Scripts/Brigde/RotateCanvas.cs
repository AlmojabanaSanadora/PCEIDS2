using UnityEngine;

public class RotateCanvas : MonoBehaviour
{
    public Transform camTransform;

    void LateUpdate()
    {
        if (camTransform != null)
        {
            transform.LookAt(transform.position + camTransform.rotation * Vector3.forward,
                             camTransform.rotation * Vector3.up);
        }
    }
}

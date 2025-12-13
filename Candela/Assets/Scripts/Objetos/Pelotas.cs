using UnityEngine;

public class Pelotas : MonoBehaviour
{
    public Rigidbody rb;
    public float maxForce = 10f;
    public float minVelocidad = 0.1f;
    public float timerAutoMove = 0f;
    public float timeToAutoMove = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude <= minVelocidad)
        {
            AutoMoveBall();
        }
        else
        {
            timerAutoMove = 0;
        }
    }

    private void AutoMoveBall()
    {
        if(timerAutoMove <= timeToAutoMove)
        {
            timerAutoMove += Time.deltaTime;
            return;
        }

        int randomFunction = Random.Range(0, 2);

        if(randomFunction == 0)
        {
            MoveBall();
        }
        else
        {
            timerAutoMove = 0;
        }

    }

    private void MoveBall()
    {
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(0, 1f), Random.Range(-1f, 1f)).normalized;
        float fuerza = Random.Range(5, maxForce);

        rb.AddForce(direction * fuerza, ForceMode.VelocityChange);
        timerAutoMove = 0;
    }

}

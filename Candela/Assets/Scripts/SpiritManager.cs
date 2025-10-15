using UnityEngine;
using UnityEngine.AI;

public class SpiritManager : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;

    public float projectionDistance = 5f;

    public float runDistance = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= runDistance) return;

        Vector3 direction = transform.position - player.transform.position;
        direction.Normalize();

        Vector3 newDestination = transform.position + direction * projectionDistance;

        agent.SetDestination(newDestination);
    }
}

using UnityEngine;
using UnityEngine.AI;

public class SpiritManager : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;

    public float projectionDistance = 5f;
    public float runDistance = 10f;
    public float repathRate = 0.5f;

    public Animator animator;

    private float nextRepathTime;

    void Start()
    {
        if (player == null || agent == null || animator == null)
        {
            enabled = false;
        }
        nextRepathTime = Time.time;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer >= runDistance)
        {
            animator.SetBool("isRunning", false);
            if (agent.hasPath)
            {
                agent.ResetPath();
            }
            return;
        }

        animator.SetBool("isRunning", true);

        if (Time.time >= nextRepathTime)
        {
            Vector3 directionAwayFromPlayer = transform.position - player.transform.position;
            directionAwayFromPlayer.Normalize();

            Vector3 targetPosition = transform.position + directionAwayFromPlayer * projectionDistance;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(targetPosition, out hit, projectionDistance * 2, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }

            nextRepathTime = Time.time + repathRate;
        }
    }
}
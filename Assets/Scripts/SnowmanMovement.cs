using UnityEngine;
using UnityEngine.AI;

public class SnowmanMovement : MonoBehaviour
{
    //AI Navigation System
    private NavMeshAgent agent;
    private float boundaryBuffer = 0.5f;
    private float boundaryScale = 0.5f;

    private Vector3 navMeshBoundsMin;
    private Vector3 navMeshBoundsMax;

    public bool isPaused = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 

        MeshFilter navMeshMesh = GetComponent<MeshFilter>();
        if (navMeshMesh != null)
        {
            navMeshBoundsMin = navMeshMesh.mesh.bounds.min + transform.position;
            navMeshBoundsMax = navMeshMesh.mesh.bounds.max + transform.position;
        }

        Vector3 center = (navMeshBoundsMin + navMeshBoundsMax) / 2;
        Vector3 size = navMeshBoundsMax - navMeshBoundsMin;

        size *= boundaryScale;

        navMeshBoundsMin = center - size / 2;
        navMeshBoundsMax = center + size / 2;

        SetRandomDestination();

    }

    private void Update()
    {
        if (isPaused) return;
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomPoint = GetRandomPointInBounds();
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
    Vector3 GetRandomPointInBounds()
    {
        float randomX = Random.Range(navMeshBoundsMin.x + boundaryBuffer, navMeshBoundsMax.x - boundaryBuffer);
        float randomZ = Random.Range(navMeshBoundsMin.z + boundaryBuffer, navMeshBoundsMax.z - boundaryBuffer);

        return new Vector3(randomX, 0, randomZ);
    }


    //To get snowman to stop or move
    public void PauseMovement()
    {
        isPaused = true;
        agent.isStopped = true; 
    }

    public void ResumeMovement()
    {
        isPaused = false;
        agent.isStopped = false; 
    }

}

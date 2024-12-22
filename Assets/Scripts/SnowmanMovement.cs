using UnityEngine;
using UnityEngine.AI;

public class SnowmanMovement : MonoBehaviour
{
    private NavMeshAgent agent;
     
    [SerializeField] private float boundaryBuffer = 0.5f;
    [SerializeField] private float destinationThreshold = 1f; 

    private Vector3 navMeshBoundsMin;
    private Vector3 navMeshBoundsMax;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        MeshFilter navMeshMesh = GetComponent<MeshFilter>();
        if (navMeshMesh != null)
        {
            navMeshBoundsMin = navMeshMesh.mesh.bounds.min + transform.position;
            navMeshBoundsMax = navMeshMesh.mesh.bounds.max + transform.position;
        }

        // Set the first random destination
        SetRandomDestination();
    }

    private void Update()
    {

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
}

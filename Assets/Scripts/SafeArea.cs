using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public Transform trackedObject; // Reference to the tracked AR object (e.g., Ground Plane Stage)
    public Vector3 safeAreaSize = new Vector3(5, 0, 5); // Size of the safe area (default width and depth)

    private Bounds safeBounds;

    void Update()
    {
        if (trackedObject != null)
        {
            // Update the safe area center and rotation to match the tracked object
            safeBounds = new Bounds(trackedObject.position, safeAreaSize);
        }
    }

    public bool IsInsideSafeArea(Vector3 position)
    {
        if (trackedObject == null) return false;

        // Transform the point into the local space of the tracked object
        Vector3 localPoint = trackedObject.InverseTransformPoint(position);

        // Check if the local point is within the bounds
        Vector3 halfSize = safeAreaSize * 0.5f;
        return Mathf.Abs(localPoint.x) <= halfSize.x &&
               Mathf.Abs(localPoint.z) <= halfSize.z;
    }

    private void OnDrawGizmos()
    {
        if (trackedObject != null)
        {
            Gizmos.color = Color.green;

            // Draw a wireframe box representing the safe area
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(trackedObject.position, trackedObject.rotation, Vector3.one);
            Gizmos.matrix = rotationMatrix;
            Gizmos.DrawWireCube(Vector3.zero, safeAreaSize);
        }
    }
}

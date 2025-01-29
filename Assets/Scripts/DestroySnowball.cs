using UnityEngine;

public class DestroySnowball : MonoBehaviour
{
    public void destroySnowball()
    {

        Transform parent = transform.parent;

        if (parent != null)
        {
            Destroy(parent.gameObject); 
        }
        else
        {
            Debug.LogError("No parent to destroy");
        }
    }
}

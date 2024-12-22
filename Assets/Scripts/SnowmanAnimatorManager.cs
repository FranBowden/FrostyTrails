using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanAnimatorManager : MonoBehaviour
{
    public Animator animator;
    
    public void SadSnowmanAnim()
    {
        animator.SetTrigger("isSad");

        Vector3 direction = Camera.main.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}

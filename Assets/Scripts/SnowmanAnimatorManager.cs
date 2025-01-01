using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanAnimatorManager : MonoBehaviour
{
    private float timer = 0f;
    public float interval = 5f;

    public Animator animator;
    /*
    public void SadSnowmanAnim()
    {
        animator.SetTrigger("isSad");

        Vector3 direction = Camera.main.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }*/



    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= interval)
        {
            animator.SetTrigger("Jump");
            timer = 0f;
        }
    }
}

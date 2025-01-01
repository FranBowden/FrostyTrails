using UnityEngine;


public class SnowmanThrowBall : MonoBehaviour
{
    public GameObject snowball;
    public GameObject snowman;
    public Camera camera;

    public float speed = 2.0f;

    bool snowballMoving = false;
    public void ThrowSnowballAtCam()

    {
        snowball.SetActive(true);
        snowball.transform.position = snowman.transform.position;
        snowballMoving = true;
    }

    private void Update()
    {
        if (snowball.activeSelf)
        {
            if (snowballMoving)
            {
                snowball.transform.position = Vector3.MoveTowards(snowball.transform.position, camera.transform.position, speed * Time.deltaTime);
            }

            if (snowball.transform.position == camera.transform.position)
            {

                snowball.transform.position = snowman.transform.position;
                snowball.SetActive(false);
                snowballMoving = false;
            }
        }
    }

}

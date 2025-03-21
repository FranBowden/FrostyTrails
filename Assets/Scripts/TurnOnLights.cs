using SteamAudio;
using UnityEngine;
public class TurnOnLights : MonoBehaviour
{
    [Header("Reference Scripts")]

    [SerializeField] private onHitSnowman snowmanHit;

    [Header("Gameobjects")]

    [SerializeField] private GameObject Star; //get star gameobect
    [SerializeField] private GameObject Starparticles;
   
    private Transform[] lights;
    private int OveralllightCount;
    private int NumLightsPerHit = 18;
    private int count = 0;
    private int TurnedOnLightCount = 0; 



    private void Start()
    {
        OveralllightCount = transform.childCount; //gets all of the children from "lights" (each individual light)
        lights = new Transform[OveralllightCount]; //creates an array of lights

        for (int i = 0; i < OveralllightCount; i++) //for loop to go through all the lights
        {

            //this for loop applies a new material to each individual light so they turn on/off individually

            lights[i] = transform.GetChild(i); //fills the array with the the lights
            Renderer childRenderer = lights[i].GetComponent<Renderer>(); //needed to change material of the children

            if (childRenderer != null)
            {
                UnityEngine.Material[] childMaterials = childRenderer.materials;

                if (childMaterials.Length > 1)  //this is to stop it changing the black material, only coloured
                {

                    UnityEngine.Material uniqueMaterial = new UnityEngine.Material(childMaterials[1]); 
                    uniqueMaterial.color = new Color(Random.value, Random.value, Random.value);

                    uniqueMaterial.SetColor("_EmissionColor", uniqueMaterial.color);

                    childMaterials[1] = uniqueMaterial;

                    childRenderer.materials = childMaterials;

                }


            }
        }
    }


    private void Update()
    {
        if(snowmanHit.isSnowmanHit)
        {
            count++;
            turnOnLights(count);
            snowmanHit.isSnowmanHit = false;
        }
    }
  
    //get all the lights
    //when snowman hits, plus one 
    //if one has hit, then say if "hit" then do x function again
    //then say its not hit but keep track of how many hits theres been vs the count of hits
    public void turnOnLights(int amount)
    {
       
      if (amount < 6)
        {

            gameObject.GetComponent<AudioSource>().Play();
            for (int i = TurnedOnLightCount; i < NumLightsPerHit + TurnedOnLightCount; i++)
            {
                Debug.Log("Index " + i);
                
                Renderer childRenderer = lights[i].GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    UnityEngine.Material[] childMaterials = childRenderer.materials;

                    if (childMaterials.Length > 1)  //this is to stop it changing the black material, only coloured
                    {

                        UnityEngine.Material childMaterial = childRenderer.material;
                        childMaterials[1].EnableKeyword("_EMISSION");
                        childMaterials[1].SetColor("_EmissionColor", childMaterials[1].color * 3.0f);

                        childMaterials[1].SetFloat("_Metallic", 0f); //changes the metallic colour
                        childMaterials[1].SetFloat("_Smoothness", 0.5f);



                    }
                }
              

            }
            TurnedOnLightCount += NumLightsPerHit;
        }

      else if (amount == 6) //for the remaining few lights left, light them all up: (same code as above)
        {
            for (int i = TurnedOnLightCount; i < OveralllightCount; i++)
            {
                Renderer childRenderer = lights[i].GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    UnityEngine.Material[] childMaterials = childRenderer.materials;

                    if (childMaterials.Length > 1)  
                    {

                        UnityEngine.Material childMaterial = childRenderer.material;
                        childMaterials[1].EnableKeyword("_EMISSION");

                        childMaterials[1].SetColor("_EmissionColor", childMaterials[1].color * 3.0f);


                       childMaterials[1].SetFloat("_Metallic", 0f);

                        childMaterials[1].SetFloat("_Smoothness", 0.5f);


                        Debug.Log("changed color");
                    }
                }


            }
            Star.GetComponent<AudioSource>().Play(); //play star sound effect
            Star.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            Starparticles.gameObject.SetActive(true);
        }


      

    }


}

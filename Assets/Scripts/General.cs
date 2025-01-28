using UnityEngine;
using Vuforia;

public class General : MonoBehaviour
{

    [SerializeField] private PlaneFinderBehaviour _planeFinder;
  public void hidePlaneIndicator()
    {
        _planeFinder.PlaneIndicator.SetActive(false);
    }
}

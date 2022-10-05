using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLightingManager : MonoBehaviour
{
    public static SceneLightingManager lightingInstance; // Declaring the instance
    public GameObject Spotlight; // Spotlight 

    // Singleton
    void Awake()
    {
        if (lightingInstance == null)
        {
            lightingInstance = this;
        }
    }
    public void ChangeLighting()
    {
        Debug.Log("Scene lighting has been changed");
        // Changes the scene lighting to blue
        Spotlight.GetComponent<Light>().color = Color.blue;
    }
}

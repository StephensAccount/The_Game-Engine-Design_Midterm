using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        { 
            // Calling the instance
            SceneLightingManager.lightingInstance.ChangeLighting();
        }
    }
}

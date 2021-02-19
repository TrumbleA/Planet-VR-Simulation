using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PCreate : MonoBehaviour
{
    public Transform hand;
    public GameObject planets;

    
    public void PlanetCreation()
    {
        GameObject btn = Instantiate(planets, hand.position, hand.rotation);
    }

    void Update()
    {
        PlanetCreation();
    }
    

  
}

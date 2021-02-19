using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlanetC : MonoBehaviour
{
    public Transform hands;
    public GameObject planet;
    public Transform Clones;

    
    public void PlanetCreation()
    {
        GameObject btn = Instantiate(planet, hands.position, hands.rotation, Clones);
        Debug.Log("Planet name: " + btn);
        Debug.Log("Planet's Parent: " + btn.transform.parent.name);
        Debug.Log($"{Clones}", this);
    }

    
}

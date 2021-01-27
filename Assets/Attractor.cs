using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public static List<Attractor> Attractors;
    public Rigidbody rb;
    const float Grav = 667.4f;




    void FixedUpdate()
    {
       Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in attractors)
        {
            if(attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();
        Attractors.Add(this);
    }
    void OnDisable()
    {
        Attractors.Remove(this);
    }


    void Attract(Attractor objectToAttract)
    {
        Rigidbody rbToAttract = objectToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;


        float forceMagnitude = Grav * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Deletion : MonoBehaviour
{
    public float activationThreshold = 0.1f;
    public XRController handR;
    public Transform hands;
    public InputHelpers.Button delete;

    void Update()
    {

        if (CheckIfActivated(handR))
        {
            //Destroy All Objects within the Planet GameObject, But do not delete Planet GameObject Itself
            Destroy(GameObject.Find("BasePlanet(Clone)"));
        }


    }



    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, delete, out bool isActivated, activationThreshold);
        return isActivated;
    }

}

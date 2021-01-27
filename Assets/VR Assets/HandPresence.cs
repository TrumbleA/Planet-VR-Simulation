using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.Log("Did not Find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
            Debug.Log("Pressing Primary Button");

        //targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            Debug.Log("Trigger Pressed" + triggerValue);

        //targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if(targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
            Debug.Log("Primary Touchpad " + primary2DAxisValue);
    }
}

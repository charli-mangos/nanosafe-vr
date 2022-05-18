using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    //Input
    private InputDevice targetDevice;

    //Controller model options
    public bool showController = false;
    public List<GameObject> controllers;
    private GameObject spawnedController;

    //Device characteristics
    public InputDeviceCharacteristics controllerChar;

    //Hand model
    public GameObject handModel;
    private GameObject spawnedHandModel;

    private Animator handAnimator;

    //Get if is Right or left
    public string isRight;

    //Input variables
    public float trigVal;
    public bool primaryButton;
    public float gripValue;
    public Vector2 axisVal;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    //Try get input device and attach the selected model to it
    void TryInitialize()
    {
        //Get VR devices by characteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerChar, devices);


        if (devices.Count > 0)
        {
            //Get target device and get a controller model
            targetDevice = devices[0];
            GameObject prefab = controllers.Find(con => con.name == targetDevice.name);

            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllers[0], transform);
            }

            //Instantiate Hand Model and get Animator component
            spawnedHandModel = Instantiate(handModel, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    //Update hand events
    void UpdateEvents()
    {
        //Trigger event
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerVal))
        {
            trigVal = triggerVal;
        }

        //PrimaryButton event
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            primaryButton = primary;
        }

        //Grip event
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripVal))
        {
            gripValue = gripVal;
        }

        //Joystick event
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axis))
        {
            axisVal = axis;
        }
    }

    //Update hand animations
    void UpdateAnimations()
    {
        //Trigger animation
        if (trigVal > 0.01)
        {
            handAnimator.SetFloat("Trigger", trigVal);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        //Grip animation
        if (gripValue > 0.01)
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            UpdateEvents();

            if (showController)
            {
                //Show controller model
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            {
                //Show Hand model and update animations
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateAnimations();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftRay;
    public XRController rightRay;

    public InputHelpers.Button teleportActivation;
    public float activationThreshold = 0.1f;

    public XRRayInteractor leftInteractor;
    public XRRayInteractor rightInteractor;

    private bool movement;
    private GameObject[] moveArea;

    public bool EnableRightTeleport { get; set; } = true;
    public bool EnableLeftTeleport { get; set; } = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;

        CheckIfMovement();

        if (leftRay)
        {
            bool isLeftHoovering = leftInteractor.TryGetHitInfo(out pos, out norm, out index, out validTarget);
            leftRay.gameObject.SetActive(EnableLeftTeleport && CheckIfActivated(leftRay) && !isLeftHoovering);
        }

        if (rightRay)
        {
            bool isRightHoovering = rightInteractor.TryGetHitInfo(out pos, out norm, out index, out validTarget);
            rightRay.gameObject.SetActive(EnableRightTeleport && CheckIfActivated(rightRay) && !isRightHoovering);
        }
    }

    //Check if teleport is activated
    public bool CheckIfActivated(XRController controller)
    {
        if (movement)
        {
            InputHelpers.IsPressed(controller.inputDevice, teleportActivation, out bool isActive, activationThreshold);
            return isActive;
        }
        else
        {
            return false;
        }
    }

    //Chaeck if there is some movement area
    void CheckIfMovement()
    {
        moveArea = GameObject.FindGameObjectsWithTag("MoveArea");

        if (moveArea.Length > 0)
        {
            movement = true;
        }
        else
        {
            movement = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachElement : MonoBehaviour
{
    public string elementTag;

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.GetComponent<FixedJoint>() && col.gameObject.tag == elementTag)
        {
            FixedJoint joint = col.gameObject.AddComponent<FixedJoint>() as FixedJoint;
            joint.connectedBody = this.gameObject.GetComponent<Rigidbody>();
        }
    }
}

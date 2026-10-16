using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Graphic))]
public class HideOnBack : MonoBehaviour
{
    private Graphic renderer;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Graphic>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle((transform.position - camera.transform.position), transform.forward);

        renderer.enabled = angle < 90;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The Object to follow
    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = targetObject.transform.position + new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = targetObject.transform.position + new Vector3(0, 0, -10);
    }
}

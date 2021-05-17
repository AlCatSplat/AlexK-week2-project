using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateloop : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

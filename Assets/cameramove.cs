using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public float turnSpeed = 1.0f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
	if (SystemInfo.deviceType == DeviceType.Desktop)
	{
	   float delta = Input.GetAxis("Mouse X") * turnSpeed;
           transform.RotateAround(player.position, Vector3.up, delta);
	   float delta2 = Input.GetAxis("Mouse Y") * turnSpeed;
	   transform.RotateAround(player.position, Vector3.left, delta2);
	}
	else
	{
	   float moveHorizontal = Input.acceleration.x;
	   transform.RotateAround(player.position, Vector3.up, moveHorizontal);
	}
    }
}

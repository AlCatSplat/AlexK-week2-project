using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    public AudioSource sound;
    public float thrust = 5f;
    public int jumpForce = 100;
    public int flyForce = 200;
    public bool isGrounded;
    public GameObject Canvas;
    public CinemachineVirtualCamera vcam;
    public bool levelDone = false;
    public bool playsound = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
	    rb.AddForce(Camera.main.transform.forward * thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
	    rb.AddForce(-Camera.main.transform.forward * thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
	    rb.AddForce(-Camera.main.transform.right * thrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
	    rb.AddForce(Camera.main.transform.right * thrust);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded && SceneManager.GetActiveScene().buildIndex != 4)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
	if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 4)
	{
	    rb.AddForce(Vector3.up * flyForce);
	    sound.clip = (AudioClip)Resources.Load("sfx_wing") as AudioClip;
            sound.Play();
	}
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.touchCount > 0 && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * thrust * 2);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("RestartLevel") && !levelDone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            if (playsound != true)
            {
                sound.clip = (AudioClip)Resources.Load("victory") as AudioClip;
                sound.Play();
                playsound = true;
            }
            levelDone = true;
            if (levelDone == true)
            {
                Canvas.SetActive(true);
                vcam.m_Priority = 9;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider collide)
    {
	if (collide.gameObject.CompareTag("PipeTrigger"))
	{
	    sound.clip = (AudioClip)Resources.Load("sfx_point") as AudioClip;
            sound.Play();
	}
    }

    void Update()
    {
        
    }
}

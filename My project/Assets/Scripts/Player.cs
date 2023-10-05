using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    public float rotationSpeed = 10f;
    Animator animator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(-v, 0, h);

        if (directionVector.magnitude > Mathf.Abs(0.05f))
            
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * rotationSpeed);

        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        rb.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;
    }

    
}

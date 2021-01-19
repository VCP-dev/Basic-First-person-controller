using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    


    Rigidbody rb;
    Vector3 moveinput;
    Vector3 mouseinput;


    public float movespeed = 5f;
    public float mousesensitivity;
    public Camera viewcam;


    float horizontal;
    float vertical;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {

        // PLAYER MOVEMENT
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveinput = new Vector3(horizontal,0,vertical).normalized;


        Vector3 movehorizontal = transform.right * moveinput.x;
        Vector3 moveVertical = transform.forward * moveinput.z;

        if(moveinput.magnitude!=0)
        {    
            rb.velocity = (movehorizontal + moveVertical) * movespeed;
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
        } 


        // PLAYER CAMERA CONTROL
        mouseinput = new Vector3(Input.GetAxisRaw("Mouse Y"),-1*Input.GetAxisRaw("Mouse X"),0f) * mousesensitivity;

        viewcam.transform.rotation = Quaternion.Euler(viewcam.transform.rotation.eulerAngles.x-mouseinput.x,viewcam.transform.rotation.eulerAngles.y,viewcam.transform.rotation.eulerAngles.z);
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y-mouseinput.y,transform.rotation.eulerAngles.z);

    }
    

}

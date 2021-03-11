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
    public float minangleofrotation;
    public float maxangleofrotation;
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

        float rotX = viewcam.transform.rotation.eulerAngles.x-mouseinput.x;

        viewcam.transform.rotation = Quaternion.Euler(Clampangle(rotX,minangleofrotation,maxangleofrotation),viewcam.transform.rotation.eulerAngles.y,viewcam.transform.rotation.eulerAngles.z);
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y-mouseinput.y,transform.rotation.eulerAngles.z);

    }
    
    
    // ------------------ for clamping ------------------------------

    float Clampangle(float angle,float min,float max)
    {
        if (angle<90 || angle>-90){       // if angle in the critic region...
            if (angle>180) angle -= 360;  // convert all angles to -180..+180
            if (max>180) max -= 360;
            if (min>180) min -= 360;
        }    
        angle = Mathf.Clamp(angle, min, max);
        if (angle<0) angle += 360;  // if angle negative, convert to 0..360
        return angle;
    }

    // ------------------ for clamping ------------------------------

    

}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 600f;

    public float airDrag = 0.05f;
    public float drag = 0f;
    public float airHeight = 1.3f;

    // Update is called once per frame
    void FixedUpdate()
    {   
        //Add a forward force
        if(rb.position.y > airHeight){
            drag = airDrag;
        } else {
            drag = 1f;
        }
        
        rb.AddForce(0, 0, forwardForce*drag*Time.deltaTime);

        if(Input.GetKey("d")){
            rb.AddForce(sidewaysForce*drag*Time.deltaTime, 0, 0,  ForceMode.VelocityChange);
        }
        if(Input.GetKey("a")){
            rb.AddForce(-sidewaysForce*drag*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y <= -1){
            FindObjectOfType<GameManager>().RestartGame();
        }
    }
}

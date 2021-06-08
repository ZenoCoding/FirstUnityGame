using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{   
    
    public PlayerMovement movement;

    public Rigidbody playerrb;
    public GameObject DestroyedVersion;

    public float JumpForce = 10;

    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag == "Obstacle"){
            Instantiate(DestroyedVersion, transform.position, transform.rotation);
            Instantiate(DestroyedVersion, transform.position, transform.rotation);
            Invoke("DestroyPlayer", 0.01f);
            FindObjectOfType<GameManager>().RestartGame();
        } else if (collisionInfo.collider.tag == "JumpBoost"){
            playerrb.AddForce(0, JumpForce, 0,  ForceMode.VelocityChange);
        } else if (collisionInfo.collider.tag == "Finish") {
            movement.enabled = false;
            playerrb.useGravity = false;
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }

    void DestroyPlayer(){
        movement.enabled = false;
        playerrb.constraints = RigidbodyConstraints.FreezeAll;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}

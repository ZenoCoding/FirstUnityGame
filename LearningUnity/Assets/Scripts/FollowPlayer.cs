using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public Vector3 defaultOffset;
    public Vector3 pauseOffset;
    public GameManager gameManager;
    
    public float speed = 0.1f;

    // Update is called once per frame
    void Update(){
        if(gameManager.GameIsPaused){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position + pauseOffset, step);
        } else {
            // float step = speed * Time.deltaTime;
            // transform.position = Vector3.MoveTowards(transform.position, player.position + defaultOffset, step*5f);
            transform.position = player.position + defaultOffset;
        }
        
        
    }
}

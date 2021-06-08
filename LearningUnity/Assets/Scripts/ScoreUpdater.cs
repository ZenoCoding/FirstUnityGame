using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    
    public Transform player;
    public float score = 0;

    public float positionCache;
    private TextMeshProUGUI scoreText;

    void Start(){
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {   
        float deltaPos = player.position.z - positionCache;
        if(deltaPos > 0){
            score += deltaPos/5;
        }
        scoreText.text = (score).ToString("0");
        positionCache = player.position.z;
    }
}

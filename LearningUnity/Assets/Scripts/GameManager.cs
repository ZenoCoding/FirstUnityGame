using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;

    public GameObject completeLevelFlash;

    public GameObject completeLevelUI;
    public GameObject completeLevelScoreGameObject;
    private TextMeshProUGUI completeLevelScore;
    public GameObject gameUI;

    public bool GameIsPaused = false;
    public PlayerMovement movement;
    
    public ScoreUpdater scoreUpdater;
    public Rigidbody player;

    public TimeManager timeManager;

    private float score;

    public void CompleteLevel(){
        completeLevelFlash.SetActive(true);
        gameUI.SetActive(false);
    }

    public void LoadLevelUI(){
        score = Mathf.Round(scoreUpdater.score);
        completeLevelScore = completeLevelScoreGameObject.GetComponent<TextMeshProUGUI>();
        completeLevelFlash.SetActive(false);
        completeLevelUI.SetActive(true);
        completeLevelScore.text = $"Score: {score}";
        Debug.Log($"Score: {score}");
    }

    public void LoadNextLevel(){

    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab)){
            GamePause();
        }
    }

    void GamePause(){
        if(!GameIsPaused){
            movement.enabled = false;
            player.constraints = RigidbodyConstraints.FreezeAll;
            GameIsPaused = true;
        } else {
            movement.enabled = true;
            player.constraints = RigidbodyConstraints.None;
            GameIsPaused = false;
        }
    }

    public void RestartGame(){
        if(!gameHasEnded){
            gameHasEnded = true;
            timeManager.SlowTime();
            movement.enabled = false;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

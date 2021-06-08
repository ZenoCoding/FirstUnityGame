using UnityEngine;

public class TimeManager : MonoBehaviour
{
    
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    
    void Update (){
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        if (Time.timeScale == 1.0f) {
            Time.fixedDeltaTime = Time.deltaTime;
        }
    }

    public void SlowTime(){
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}

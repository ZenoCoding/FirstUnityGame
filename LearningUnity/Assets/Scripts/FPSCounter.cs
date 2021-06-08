using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{   
    [SerializeField] private float hudRefreshRate = 0.5f;
 
    private float timer;
 
    private void Update()
    {
        if (Time.unscaledTime > timer)
        {   
            TextMeshProUGUI FPStext = gameObject.GetComponent<TextMeshProUGUI>();
            int fps = (int)(1f / Time.unscaledDeltaTime);
            FPStext.SetText($"{fps} FPS");
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }
}

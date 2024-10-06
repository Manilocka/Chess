using UnityEngine;
using TMPro; 
public class Timer : MonoBehaviour
{
    public TMP_Text timerText; 
    public GameManager gameManager; 
    private float remainingTime;
    private bool timerRunning;

    public void StartTimer(float timeInSeconds)
    {
        remainingTime = timeInSeconds;
        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                timerRunning = false;
                remainingTime = 0;

                gameManager.NextPlayer();
                Debug.Log("Время истекло! Переход к другому игроку.");
                
                timerRunning = true;
                StartTimer(gameManager.timePerTurn);
            }

            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Text hpText;     // สำหรับแสดง HP
    public Text pinsText;   // ✅ เพิ่ม UI แสดงจำนวน Pins ที่ล้มแล้ว

    private BowlingBallHealth bowlingBallHealth;
    private GameManager gameManager; // ✅ เพิ่มตัวแปร GameManager


    public TextMeshProUGUI gameTimerText; // เชื่อมกับ UI Text ใน Inspector
    private float gameTime = 0f; // ตัวแปรนับเวลา
    private bool isTimerRunning = true;

    void Start()
    {
        bowlingBallHealth = FindObjectOfType<BowlingBallHealth>();
        gameManager = FindObjectOfType<GameManager>(); // ✅ ค้นหา GameManager

        if (bowlingBallHealth == null)
            Debug.LogError("BowlingBallHealth not found in the scene!");

        if (gameManager == null)
            Debug.LogError("GameManager not found in the scene!");

        Debug.Log("UIManager Start! Timer should begin.");
        
    }

    void Update()
    {
        UpdateHPText();
        UpdatePinsText();
        Debug.Log("Update Running"); // เช็คว่า Update ทำงานทุกเฟรม
        if (isTimerRunning)
        {
            gameTime += Time.deltaTime;
            UpdateTimerUI();
            Debug.Log("Game Time: " + gameTime);
        }
    }

    void UpdateHPText()
    {
        if (bowlingBallHealth != null && hpText != null)
        {
            hpText.text = "HP: " + bowlingBallHealth.CurrentHP + "/" + bowlingBallHealth.maxHP;
        }
    }

    void UpdatePinsText()
    {
        if (gameManager != null && pinsText != null)
        {
            pinsText.text = "Pins: " + gameManager.FallenPins + "/" + gameManager.totalPins;
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        gameTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StopTimer()
    {
        Debug.Log("Timer Stopped!");
        isTimerRunning = false;
    }
}

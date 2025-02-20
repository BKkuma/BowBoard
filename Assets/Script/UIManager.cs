using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text hpText;     // สำหรับแสดง HP
    public Text pinsText;   // ✅ เพิ่ม UI แสดงจำนวน Pins ที่ล้มแล้ว

    private BowlingBallHealth bowlingBallHealth;
    private GameManager gameManager; // ✅ เพิ่มตัวแปร GameManager

    void Start()
    {
        bowlingBallHealth = FindObjectOfType<BowlingBallHealth>();
        gameManager = FindObjectOfType<GameManager>(); // ✅ ค้นหา GameManager

        if (bowlingBallHealth == null)
            Debug.LogError("BowlingBallHealth not found in the scene!");

        if (gameManager == null)
            Debug.LogError("GameManager not found in the scene!");
    }

    void Update()
    {
        UpdateHPText();
        UpdatePinsText();
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
}

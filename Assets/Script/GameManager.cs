using UnityEngine;
using UnityEngine.SceneManagement; // ใช้สำหรับเปลี่ยนฉาก

public class GameManager : MonoBehaviour
{
    public int totalPins = 5; // จำนวนพินทั้งหมด
    private int fallenPins = 0; // พินที่ล้มแล้ว

    public void PinFallen()
    {
        fallenPins++;
        if (fallenPins >= totalPins)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        // สามารถเปลี่ยนฉากหรือแสดง UI ชนะได้
        SceneManager.LoadScene("WinScene");
    }
}

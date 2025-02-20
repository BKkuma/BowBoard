using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPins = 5; // จำนวนพินทั้งหมด
    private int fallenPins = 0; // ✅ เปลี่ยนเป็น Property เพื่อให้ UIManager เข้าถึงได้

    public int FallenPins => fallenPins; // ✅ ใช้ Property ให้ UIManager ดึงค่าได้

    public void PinFallen()
    {
        fallenPins++;
        Debug.Log("Pins fallen: " + fallenPins);

        if (fallenPins >= totalPins)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        SceneManager.LoadScene("WinScene");
    }
}

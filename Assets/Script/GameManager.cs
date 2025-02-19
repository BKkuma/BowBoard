using UnityEngine;
using UnityEngine.SceneManagement; // ������Ѻ����¹�ҡ

public class GameManager : MonoBehaviour
{
    public int totalPins = 5; // �ӹǹ�Թ������
    private int fallenPins = 0; // �Թ����������

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
        // ����ö����¹�ҡ�����ʴ� UI �����
        SceneManager.LoadScene("WinScene");
    }
}

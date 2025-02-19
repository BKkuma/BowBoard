using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingBallHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("BowlingBall HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("BowlingBall Destroyed!");
        SceneManager.LoadScene("GameOverScene"); // âËÅ´©Ò¡á¾é
    }
}

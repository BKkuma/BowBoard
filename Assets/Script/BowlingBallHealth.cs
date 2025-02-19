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

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP; // �ӡѴ�������Թ maxHP
        Debug.Log("BowlingBall Healed! Current HP: " + currentHP);
    }

    void Die()
    {
        Debug.Log("BowlingBall Destroyed!");
        SceneManager.LoadScene("GameOverScene");
    }
}

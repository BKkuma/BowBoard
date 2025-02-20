using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private AudioSource bgmAudioSource;

    void Start()
    {
        bgmAudioSource = FindObjectOfType<AudioSource>(); // หา AudioSource ในเกม
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // กด ESC เพื่อ Pause
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // หยุดเวลาในเกม
        isPaused = true;

        if (bgmAudioSource != null)
            bgmAudioSource.Pause(); // **หยุดเพลง**
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // เล่นเกมต่อ
        isPaused = false;

        if (bgmAudioSource != null)
            bgmAudioSource.Play(); // **เล่นเพลงต่อ**
    }

    public void QuitToLobby()
    {
        Time.timeScale = 1f; // คืนค่าความเร็วเกม
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }
}

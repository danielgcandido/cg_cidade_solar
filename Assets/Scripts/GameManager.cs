using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI de fim de jogo")]
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Opcional: manter entre cenas
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        if (defeatPanel != null)
            defeatPanel.SetActive(false);

        isGameOver = false;
        Time.timeScale = 1f; // garante tempo normal

        // Ao iniciar o jogo (MainCityScene), travar cursor para FPS
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void WinGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f; // pausa o jogo

        // LIBERAR CURSOR
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (victoryPanel != null)
            victoryPanel.SetActive(true);
    }

    public void LoseGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f;

        // LIBERAR CURSOR
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (defeatPanel != null)
            defeatPanel.SetActive(true);
    }


    public void RestartLevel()
    {
        Time.timeScale = 1f;

        // VOLTAR A TRAVAR O CURSOR
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }


    public void QuitGame()
    {
        // Só funciona no build; no editor não fecha.
        Application.Quit();
    }
}

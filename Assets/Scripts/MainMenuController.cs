using System.Collections;              // necessário para IEnumerator / StartCoroutine
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Nome exato da cena do jogo e de instruções
    [Header("Nomes das cenas")]
    public string gameSceneName = "MainCityScene";
    public string instructionsSceneName = "Instrucoes";

    [Header("Áudio de clique de UI")]
    [Tooltip("AudioSource que toca o som de clique dos botões.")]
    public AudioSource uiClickSource;

    [Tooltip("Tempo de espera antes de mudar de cena/sair, em segundos.")]
    public float clickDelay = 0.2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    // Chamado pelo botão "Jogar"
    public void PlayGame()
    {
        StartCoroutine(PlayClickAndLoadScene(gameSceneName));
    }

    // Chamado pelo botão "Instruções"
    public void OpenInstructions()
    {
        StartCoroutine(PlayClickAndLoadScene(instructionsSceneName));
    }

    // Chamado pelo botão "Sair"
    public void QuitGame()
    {
        StartCoroutine(PlayClickAndQuit());
    }

    private IEnumerator PlayClickAndLoadScene(string sceneName)
    {
        if (uiClickSource != null)
        {
            uiClickSource.Play();

            // espera pequeno tempo (ou até o tamanho do clipe, se quiser garantir)
            float wait = clickDelay;
            if (uiClickSource.clip != null)
                wait = Mathf.Min(clickDelay, uiClickSource.clip.length);

            yield return new WaitForSeconds(wait);
        }

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator PlayClickAndQuit()
    {
        if (uiClickSource != null)
        {
            uiClickSource.Play();

            float wait = clickDelay;
            if (uiClickSource.clip != null)
                wait = Mathf.Min(clickDelay, uiClickSource.clip.length);

            yield return new WaitForSeconds(wait);
        }

        Application.Quit();

        // no Editor isso não fecha, mas no build funciona
    }
}

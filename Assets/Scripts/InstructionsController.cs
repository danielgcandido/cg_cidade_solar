using System.Collections;              // necessário para IEnumerator / StartCoroutine
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsController : MonoBehaviour
{
    [Header("Nome da cena do menu")]
    public string menuSceneName = "MenuPrincipal";

    [Header("Áudio de clique de UI")]
    [Tooltip("AudioSource que toca o som de clique ao voltar para o menu.")]
    public AudioSource uiClickSource;

    [Tooltip("Tempo de espera antes de voltar ao menu, em segundos.")]
    public float clickDelay = 0.2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    // Este método continua sendo chamado pelo botão "Voltar ao Menu"
    public void BackToMenu()
    {
        StartCoroutine(PlayClickAndLoadMenu());
    }

    private IEnumerator PlayClickAndLoadMenu()
    {
        if (uiClickSource != null)
        {
            uiClickSource.Play();

            float wait = clickDelay;
            if (uiClickSource.clip != null)
                wait = Mathf.Min(clickDelay, uiClickSource.clip.length);

            yield return new WaitForSeconds(wait);
        }

        SceneManager.LoadScene(menuSceneName);
    }
}

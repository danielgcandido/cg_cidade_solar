using UnityEngine;
using UnityEngine.InputSystem;       // Novo Input System
using UnityEngine.SceneManagement;  // Para carregar cenas

public class EscapeToMenu : MonoBehaviour
{
    [Header("Nome da cena do menu principal")]
    public string menuSceneName = "MenuPrincipal";

    void Update()
    {
        // Garante que o novo Input System está disponível
        if (Keyboard.current == null)
            return;

        // Se ESC foi pressionado neste frame, volta ao menu
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }
}

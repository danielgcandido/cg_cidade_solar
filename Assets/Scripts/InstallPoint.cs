using UnityEngine;
using UnityEngine.InputSystem; // Novo Input System

public class InstallPoint : MonoBehaviour
{
    public enum InstallType
    {
        SolarPanel,
        WindTurbine
    }

    [Header("Configuração do ponto")]
    public InstallType tipo = InstallType.SolarPanel;
    public bool jaInstalado = false;

    [Header("Prefab visual a ser instanciado")]
    public GameObject prefabVisual;

    [Header("Posição de spawn (opcional)")]
    public Transform spawnPointOverride;

    // Controle interno
    private bool playerDentro = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDentro = false;
        }
    }

    private void Update()
    {
        if (jaInstalado)
            return;

        if (!playerDentro)
            return;

        // Novo Input System
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Instalar();
        }

        // Se estivesse usando o Input antigo, seria:
        // if (Input.GetKeyDown(KeyCode.E)) { Instalar(); }
    }

    private void Instalar()
    {
        if (jaInstalado)
            return;

        // Atualiza energia/pontos
        if (EnergyManager.Instance != null)
        {
            switch (tipo)
            {
                case InstallType.SolarPanel:
                    EnergyManager.Instance.InstalarPainelSolar();
                    break;

                case InstallType.WindTurbine:
                    EnergyManager.Instance.InstalarTurbinaEolica();
                    break;
            }
        }

        // Som de instalação
        if (SFXPlayer.Instance != null)
        {
            SFXPlayer.Instance.PlayInstallSound();
        }

        // Cria o objeto visual
        SpawnVisual();

        jaInstalado = true;
        gameObject.SetActive(false);
    }

    private void SpawnVisual()
    {
        if (prefabVisual == null)
            return;

        Vector3 pos;
        Quaternion rot;

        if (spawnPointOverride != null)
        {
            pos = spawnPointOverride.position;
            rot = spawnPointOverride.rotation;
        }
        else
        {
            pos = transform.position;
            rot = transform.rotation;
        }

        Instantiate(prefabVisual, pos, rot);
    }
}

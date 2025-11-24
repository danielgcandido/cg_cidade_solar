using UnityEngine;

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

    private void OnTriggerStay(Collider other)
    {
        if (jaInstalado)
            return;

        // garante que é o player
        if (!other.CompareTag("Player"))
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
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

            // Cria o objeto visual
            SpawnVisual();

            jaInstalado = true;
            gameObject.SetActive(false);
        }
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

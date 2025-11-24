using UnityEngine;

public class SolarPanelVisual : MonoBehaviour
{
    [Header("Rotação suave do painel (simula rastreamento solar)")]
    public float rotationSpeed = 10f; // graus por segundo

    void Update()
    {
        // Rotação lenta ao redor do eixo Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
    }
}

using UnityEngine;

public class SunMarkerRotator : MonoBehaviour
{
    [Header("Velocidade de rotação em graus por segundo")]
    public float rotationSpeed = 30f;

    void Update()
    {
        // Rotação suave em torno do eixo Y (vertical)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.World);
    }
}


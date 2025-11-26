using UnityEngine;

public class WindTurbineVisual : MonoBehaviour
{
    [Header("Configuração do rotor")]
    [Tooltip("Pivot do rotor (objeto que possui as pás como filhos).")]
    public Transform rotorPivot;

    [Tooltip("Velocidade de rotação do rotor em graus por segundo.")]
    public float rotationSpeed = 180f;

    [Header("Configuração da orientação ao vento")]
    [Tooltip("Velocidade de giro da turbina para alinhar com o vento (yaw).")]
    public float yawSpeed = 2f;

    private void Update()
    {
        // 1) Girar as pás da turbina
        if (rotorPivot != null)
        {
            rotorPivot.Rotate(0f, 0f, rotationSpeed * Time.deltaTime, Space.Self);
        }

        // 2) Alinhar a turbina com o vento
        if (WindManager.Instance == null)
            return;

        Vector3 windDir = WindManager.Instance.GetWindDirection();

        // Consideramos apenas o plano XZ
        Vector3 windDirXZ = new Vector3(windDir.x, 0f, windDir.z);
        if (windDirXZ.sqrMagnitude < 0.0001f)
            return;

        // A frente da turbina (transform.forward) deve apontar CONTRA o vento,
        // ou seja, se o vento sopra para +X, a turbina olha para -X.
        Vector3 targetForward = -windDirXZ.normalized;

        // Rotação alvo apenas no eixo Y
        Quaternion targetRotation = Quaternion.LookRotation(targetForward, Vector3.up);

        // Mantém apenas o yaw (eixo Y), forçando X e Z em 0
        Vector3 currentEuler = transform.rotation.eulerAngles;
        Vector3 targetEuler = targetRotation.eulerAngles;

        float newY = Mathf.LerpAngle(currentEuler.y, targetEuler.y, Time.deltaTime * yawSpeed);
        transform.rotation = Quaternion.Euler(0f, newY, 0f);
    }
}

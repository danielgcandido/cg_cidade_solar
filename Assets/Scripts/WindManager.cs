using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance;

    [Header("Configuração inicial")]
    [Tooltip("Ângulo inicial do vento em graus (0 = eixo Z positivo).")]
    public float initialAngle = 0f;

    [Header("Tempo em cada direção")]
    [Tooltip("Tempo mínimo que o vento permanece apontando para uma direção antes de mudar, em segundos.")]
    public float minHoldTime = 5f;

    [Tooltip("Tempo máximo que o vento permanece apontando para uma direção antes de mudar, em segundos.")]
    public float maxHoldTime = 15f;

    [Header("Velocidade da mudança de direção")]
    [Tooltip("Velocidade máxima de giro do vento ao mudar de direção, em graus por segundo.")]
    public float maxTurnSpeedDegPerSec = 20f;

    [Header("Controle")]
    [Tooltip("Se falso, o vento fica travado na direção atual.")]
    public bool animateWind = true;

    private float currentAngle;   // direção atual usada pelas turbinas
    private float targetAngle;    // próxima direção aleatória
    private float holdTimer;      // quanto tempo ainda fica parado nessa direção
    private bool isTurning;       // se está atualmente mudando de direção

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        currentAngle = initialAngle;
        targetAngle = initialAngle;
        holdTimer = Random.Range(minHoldTime, maxHoldTime);
        isTurning = false;
    }

    private void Update()
    {
        if (!animateWind)
            return;

        if (!isTurning)
        {
            // Fase em que o vento está "parado" em uma direção
            holdTimer -= Time.deltaTime;
            if (holdTimer <= 0f)
            {
                // Escolhe uma nova direção aleatória (0 a 360 graus)
                targetAngle = Random.Range(0f, 360f);
                isTurning = true;
            }
        }
        else
        {
            // Fase de transição suave para a nova direção
            currentAngle = Mathf.MoveTowardsAngle(
                currentAngle,
                targetAngle,
                maxTurnSpeedDegPerSec * Time.deltaTime
            );

            float diff = Mathf.DeltaAngle(currentAngle, targetAngle);
            if (Mathf.Abs(diff) < 0.1f)
            {
                // Chegou na nova direção: fixa e espera um novo tempo aleatório
                currentAngle = targetAngle;
                isTurning = false;
                holdTimer = Random.Range(minHoldTime, maxHoldTime);
            }
        }
    }

    /// <summary>
    /// Retorna a direção do vento no plano XZ (y = 0), normalizada.
    /// </summary>
    public Vector3 GetWindDirection()
    {
        float rad = currentAngle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad)).normalized;
    }
}

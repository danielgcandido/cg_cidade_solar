using UnityEngine;

public class SunController : MonoBehaviour
{
    [Header("Configuração da órbita do Sol")]
    [Tooltip("Ponto central em torno do qual o Sol vai girar (ex.: centro da cidade).")]
    public Transform center;

    [Tooltip("Raio da órbita do Sol em torno do centro.")]
    public float radius = 100f;

    [Tooltip("Duração de um 'dia completo' em segundos.")]
    public float dayDuration = 120f;

    [Range(0f, 1f)]
    [Tooltip("Offset de fase (0 = amanhecer, 0.5 = pôr do sol, etc.).")]
    public float timeOffset = 0f;

    [Header("Luz direcional que representa o Sol")]
    public Light directionalLight;

    private void Update()
    {
        if (center == null)
            return;

        // Progresso do dia normalizado [0,1)
        float t = (Time.time / dayDuration + timeOffset) % 1f;

        // Arco de -60° (amanhecer) até 120° (tarde)
        float angleDeg = Mathf.Lerp(-60f, 120f, t);
        float angleRad = angleDeg * Mathf.Deg2Rad;

        // Órbita em um plano vertical (X-Y), mantendo Z constante
        Vector3 offset = new Vector3(
            Mathf.Cos(angleRad),
            Mathf.Sin(angleRad),
            0f
        ) * radius;

        // Posição do SunTarget
        transform.position = center.position + offset;

        // Atualiza posição e rotação da luz direcional
        if (directionalLight != null)
        {
            // Faz a luz ficar na MESMA posição do SunTarget
            directionalLight.transform.position = transform.position;

            // Direção da luz: do Sol para o centro da cidade
            Vector3 dir = (center.position - transform.position).normalized;
            directionalLight.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        }
    }

}

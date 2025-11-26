using UnityEngine;

public class SolarPanelVisual : MonoBehaviour
{
    [Header("Referências")]
    [Tooltip("Superfície do painel (o objeto que realmente inclina)")]
    public Transform panelSurface;

    [Tooltip("Posição do Sol na cena (pode ser um Empty lá no céu)")]
    public Transform sunTransform;

    [Header("Configuração de inclinação")]
    [Tooltip("Inclinação máxima em graus em relação à orientação base")]
    public float maxTiltAngle = 30f;

    [Tooltip("Velocidade de resposta da inclinação")]
    public float tiltSpeed = 2f;

    // Estado interno
    private Quaternion _defaultWorldRotation;
    private Vector3 _defaultNormalWorld;

    private void Start()
    {
        if (panelSurface == null)
        {
            panelSurface = transform; // fallback: usa o próprio objeto
        }

        // Guarda a orientação base do painel
        _defaultWorldRotation = panelSurface.rotation;
        _defaultNormalWorld = panelSurface.up; // normal "em repouso"

        // Tenta achar o Sol automaticamente, se não tiver sido atribuído
        if (sunTransform == null)
        {
            GameObject sunObj = GameObject.FindWithTag("SunTarget");
            if (sunObj != null)
            {
                sunTransform = sunObj.transform;
            }
        }
    }

    private void Update()
    {
        if (sunTransform == null || panelSurface == null)
            return;

        // Direção do Sol (do painel para o Sol)
        Vector3 toSun = (sunTransform.position - panelSurface.position).normalized;
        if (toSun.sqrMagnitude <= 0.0001f)
            return;

        // Normal "desejada" seria diretamente apontando para o Sol
        Vector3 targetNormal = toSun;

        // Clampa o ângulo entre a normal base e a normal desejada
        float angle = Vector3.Angle(_defaultNormalWorld, targetNormal);

        if (angle > maxTiltAngle)
        {
            float t = maxTiltAngle / angle;
            targetNormal = Vector3.Slerp(_defaultNormalWorld, targetNormal, t);
        }

        // Calcula rotação alvo que leva a normal base até a normal desejada
        Quaternion rotationDelta = Quaternion.FromToRotation(_defaultNormalWorld, targetNormal);
        Quaternion targetWorldRotation = rotationDelta * _defaultWorldRotation;

        // Interpola suavemente entre a rotação atual e a alvo
        panelSurface.rotation = Quaternion.Slerp(
            panelSurface.rotation,
            targetWorldRotation,
            Time.deltaTime * tiltSpeed
        );
    }
}

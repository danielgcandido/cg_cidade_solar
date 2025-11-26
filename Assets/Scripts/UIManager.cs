using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Referências de UI")]
    public TextMeshProUGUI textEnergia;
    public TextMeshProUGUI textPontos;
    public TextMeshProUGUI textTempo;
    public Slider sliderEnergia;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AtualizarEnergia(0);
        AtualizarPontos(0);
        AtualizarTempo(120f);
    }

    public void AtualizarEnergia(float valor)
    {
        // Clampa de 0 a 100
        valor = Mathf.Clamp(valor, 0f, 100f);

        if (sliderEnergia != null)
            sliderEnergia.value = valor;

        if (textEnergia != null)
            textEnergia.text = $"Energia: {valor:0}%";
    }

    public void AtualizarPontos(int pontos)
    {
        if (textPontos != null)
            textPontos.text = $"Pontuação: {pontos}";
    }

    public void AtualizarTempo(float segundosRestantes)
    {
        if (textTempo != null)
            textTempo.text = $"Tempo: {segundosRestantes:0}s";
    }
}

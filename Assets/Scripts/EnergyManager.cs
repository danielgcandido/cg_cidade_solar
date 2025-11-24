using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance;

    [Header("Configuração de Energia")]
    [Range(0f, 100f)]
    public float energiaAtual = 0f;
    public int pontuacaoAtual = 0;
    public float tempoTotal = 120f; // em segundos

    [Header("Ganhos por instalação")]
    public float energiaPorPainel = 10f;
    public float energiaPorTurbina = 15f;
    public int pontosPorPainel = 50;
    public int pontosPorTurbina = 80;

    private float tempoRestante;

    private void Awake()
    {
        // Singleton simples
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
        tempoRestante = tempoTotal;

        // Atualiza HUD inicial
        UIManager.Instance.AtualizarEnergia(energiaAtual);
        UIManager.Instance.AtualizarPontos(pontuacaoAtual);
        UIManager.Instance.AtualizarTempo(tempoRestante);
    }

    private void Update()
    {
        AtualizarTempoDecrescente();
        
        // DEBUG: testar HUD sem objetos ainda
        if (Input.GetKeyDown(KeyCode.Alpha1))
            InstalarPainelSolar();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            InstalarTurbinaEolica();
    }

    private void AtualizarTempoDecrescente()
    {
        if (tempoRestante <= 0f)
            return;

        tempoRestante -= Time.deltaTime;

        if (tempoRestante < 0f)
            tempoRestante = 0f;

        UIManager.Instance.AtualizarTempo(tempoRestante);

        if (tempoRestante <= 0f)
        {
            Debug.Log("FIM DE JOGO: tempo esgotado.");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseGame();
            }
        }
    }


    public void InstalarPainelSolar()
    {
        energiaAtual = Mathf.Clamp(energiaAtual + energiaPorPainel, 0f, 100f);
        pontuacaoAtual += pontosPorPainel;

        UIManager.Instance.AtualizarEnergia(energiaAtual);
        UIManager.Instance.AtualizarPontos(pontuacaoAtual);

        // Verifica condição de vitória
        if (energiaAtual >= 100f && GameManager.Instance != null)
        {
            GameManager.Instance.WinGame();
        }

        Debug.Log("Painel solar instalado!");
    }


    public void InstalarTurbinaEolica()
    {
        energiaAtual = Mathf.Clamp(energiaAtual + energiaPorTurbina, 0f, 100f);
        pontuacaoAtual += pontosPorTurbina;

        UIManager.Instance.AtualizarEnergia(energiaAtual);
        UIManager.Instance.AtualizarPontos(pontuacaoAtual);

        if (energiaAtual >= 100f && GameManager.Instance != null)
        {
            GameManager.Instance.WinGame();
        }

        Debug.Log("Turbina eólica instalada!");
    }

}

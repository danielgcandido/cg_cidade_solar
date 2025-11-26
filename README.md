# 🌞 Cidade Solar  
Jogo 3D desenvolvido em Unity para a disciplina de **Computação Gráfica**, com foco na **ODS 7 – Energia Limpa e Acessível**.  
O objetivo é instalar painéis solares e turbinas eólicas em uma cidade low-poly, atingindo 100% de energia renovável antes do tempo acabar.

---

## 🎮 Gameplay

Você explora a cidade em primeira pessoa (FPS) e encontra **InstallPoints** onde é possível instalar:

- **Painéis Solares** (inclinação dinâmica em direção ao Sol)
- **Turbinas Eólicas** (pás girando e cabeça orientando-se ao vento)

Cada instalação aumenta a energia total e a pontuação.  
O jogo termina quando:

- A energia chega a **100%** (vitória), ou  
- O tempo esgota (derrota).

---

## 🧭 Controles

| Ação | Tecla |
|------|--------|
| Movimento | W / A / S / D |
| Olhar | Mouse |
| Pular | Espaço |
| Instalar equipamento | **E** |
| Voltar ao menu | **Esc** |

---

## 🗺️ Estrutura das Cenas

```

Scenes/
├── MenuPrincipal
├── Instrucoes
└── MainCityScene

```

- **MenuPrincipal** — Jogar, Instruções, Sair  
- **Instrucoes** — Objetivo do jogo e controles  
- **MainCityScene** — Gameplay completo  

---

## 🛠️ Principais Sistemas

### ✔ EnergyManager  
Gerencia energia total, pontuação, HUD e condições de vitória/derrota.

### ✔ InstallPoint  
Detecta o jogador, lida com instalação e instanciamento dos prefabs.

### ✔ SolarPanelVisual  
Inclina o painel solar em direção ao Sol, com limite de ângulo.

### ✔ WindTurbineVisual  
Gira as pás e alinha a turbina à direção do vento.

### ✔ WindManager  
Gera direção de vento suave e aleatória ao longo do tempo.

### ✔ SFXPlayer  
Singleton responsável pela reprodução de efeitos sonoros.

### ✔ MainMenuController / InstructionsController  
Reproduzem sons de clique **por completo** antes de trocar de cena (via coroutine).

---

## 🔊 Áudio

### Sons Utilizados (Freesound – Creative Commons)

- “Spacey 1UP Power Up” — *gameaudio*  
  https://freesound.org/s/220173/ — **CC BY 3.0**

- “VS Short Whoosh 8” — *Vilkas_Sound*  
  https://freesound.org/s/460473/ — **CC BY 3.0**

- “Button Click 3” — *mellau*  
  https://freesound.org/s/506052/ — **CC BY 4.0**

- “Wind turbine in Lozère 1” — *Virgile_Loiseau*  
  https://freesound.org/s/751744/ — **CC BY 4.0**

- “Calm city ambience 02” — *klankbeeld*  
  https://freesound.org/s/593833/ — **CC BY 4.0**

---

## 🧩 Assets Visuais

- SimplePoly City – Low Poly Pack (Unity Asset Store)  
- Modelos próprios: Painel Solar, Turbina Eólica, SunLogo, WindLogo  
- Skybox + pós-processamento via URP

---

## 📂 Estrutura do Projeto

```

Assets/
├── Audio/
│   ├── Ambient/
│   │   └── city_ambience.wav
│   ├── Music/
│   └── SFX/
│       ├── button_click.wav
│       ├── power_up.wav
│       ├── whoosh_short.mp3
│       └── wind_turbine.wav
├── Materials/
│   ├── M_PainelSolar.mat
│   ├── M_SunLogo.mat
│   ├── M_Turbina.mat
│   ├── M_WindLogo.mat
│   ├── New Actions.inputactions
│   └── RoadMat.mat
├── Prefabs/
│   ├── SolarPanelPrefab.prefab
│   └── WindTurbinePrefab.prefab
├── Scenes/
│   ├── Instrucoes.unity
│   ├── MainCityScene.unity
│   ├── MenuPrincipal.unity
│   └── SampleScene.unity
├── Scripts/
│   ├── EnergyManager.cs
│   ├── EscapeToMenu.cs
│   ├── GameManager.cs
│   ├── InstallPoint.cs
│   ├── InstructionsController.cs
│   ├── MainMenuController.cs
│   ├── SFXPlayer.cs
│   ├── SolarPanelVisual.cs
│   ├── SunController.cs
│   ├── SunMarkerRotator.cs
│   ├── UIManager.cs
│   ├── WindManager.cs
│   ├── WindMarkerRotator.cs
│   ├── WindTurbineAudio.cs
│   └── WindTurbineVisual.cs
├── Textures/
│   ├── sun_logo.png
│   └── wind_logo.png
└── UI/


```

---

## 🔧 Build

**Plataforma:** Windows (x86_64)  
**Pipeline:** URP  
**Versão do Unity:** Unity 6 (6000.0.X ou compatível)

Para executar:

1. Baixe o build na seção Releases  
2. Extraia o arquivo `.zip`  
3. Execute `CidadeSolar.exe`

---

## 📹 Vídeo de Demonstração

**Link para o vídeo:** https://drive.google.com/file/d/1y7SVm0SuwPB0j7dpvF66TWR6frvlgvVb/view?usp=sharing

---

## 📘 Documentação

O GDD completo está disponível em:

- `docs/GDD___Cidade_Solar.pdf`

---

## 🌱 Conexão com a ODS 7

O jogo reforça conceitos de:

- energia solar e eólica,  
- eficiência energética,  
- uso de fontes renováveis na infraestrutura urbana,  
- planejamento espacial de geradores,  
- conscientização ambiental.

---

## 👤 Autor

**Daniel G. Cândido**  
Disciplina: Computação Gráfica  
UNESP – Bauru

---

## 📄 Licença

Código-fonte sob **MIT License**.  

Assets externos sob suas respectivas licenças.  

using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static SFXPlayer Instance;

    private AudioSource audioSource;

    [Header("Sons")]
    public AudioClip installSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayInstallSound()
    {
        if (installSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(installSound);
        }
    }
}

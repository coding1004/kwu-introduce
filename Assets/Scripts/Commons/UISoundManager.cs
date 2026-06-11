using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    public static UISoundManager Instance;

    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip btnClickSound;
    [SerializeField] private AudioClip btnHoverSound;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayClick()
    {
        sfxSource.PlayOneShot(btnClickSound);
    }

    public void PlayHover()
    {
        sfxSource.PlayOneShot(btnHoverSound);
    }
}

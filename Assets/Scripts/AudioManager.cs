using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource drawSource;
    [SerializeField] AudioSource shuffleSource;
    [SerializeField] List<AudioClip> drawClip = new List<AudioClip>();
    [SerializeField] List<AudioClip> shuffleClip = new List<AudioClip>();
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void DrawSFX()
    {

        drawSource.PlayOneShot(drawClip[0]);
    }

    public void ShuffleSFX()
    {
        shuffleSource.PlayOneShot(shuffleClip[0]);
    }
}

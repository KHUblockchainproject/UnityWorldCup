using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public AudioClip[] Music = new AudioClip[4];
    AudioSource AS;

    void Awake()
    {
        AS = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!AS.isPlaying)
            RandomPlay();
    }

    void RandomPlay()
    {
        AS.clip = Music[Random.Range(0, Music.Length)];
        AS.Play();
    }
}

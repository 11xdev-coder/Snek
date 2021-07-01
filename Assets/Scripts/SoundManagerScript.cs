using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip eatSound, gameOverSound, boomSound;

    private static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        eatSound = Resources.Load<AudioClip>("EatSound");
        gameOverSound = Resources.Load<AudioClip>("GameOverSound");
        boomSound = Resources.Load<AudioClip>("explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "eat":
                audioSrc.PlayOneShot(eatSound);
                break;
            case "game over":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "boom":
                audioSrc.PlayOneShot(boomSound);
                break;
        }
    }
}

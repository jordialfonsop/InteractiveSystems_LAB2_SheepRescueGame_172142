using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // 1

    public AudioClip shootClip; // 2
    public AudioClip sheepHitClip1;
    public AudioClip sheepHitClip2;
    public AudioClip sheepHitClip3;
    public AudioClip sheepDroppedClip;
    public AudioClip gameOverClip;

    private Vector3 cameraPosition;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this; // 1
        cameraPosition = Camera.main.transform.position;
    }

    private void PlaySound(AudioClip clip) // 1
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition); // 2
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlayGameOverClip()
    {
        PlaySound(gameOverClip);
    }

    public void PlaySheepHitClip1()
    {
        PlaySound(sheepHitClip1);
    }

    public void PlaySheepHitClip2()
    {
        PlaySound(sheepHitClip2);
    }

    public void PlaySheepHitClip3()
    {
        PlaySound(sheepHitClip3);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}

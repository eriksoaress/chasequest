using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public AudioClip sfx1, sfx2, sfx3;


    public void PlayDamageSFX()
    {
        audioSource.PlayOneShot(sfx1);
    }


    public void PlayAttackSFX()
    {
        audioSource.PlayOneShot(sfx2);
    }

    public void PlayOpenBookSFX()
    {
        audioSource.PlayOneShot(sfx3);
    }
   
}

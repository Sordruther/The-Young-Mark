using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgPlay : MonoBehaviour
{
    private AudioSource bgm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    public void PlayBgm()
    {
        bgm.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayBgm();
    }
}

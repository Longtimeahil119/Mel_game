using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawrScript : MonoBehaviour
{

    public AudioClip rawrSound;
    public AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rawr()
    {
        audioS.PlayOneShot(rawrSound);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioRandomPitch : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().pitch = Random.Range(.8f, 1.2f);
    }
}

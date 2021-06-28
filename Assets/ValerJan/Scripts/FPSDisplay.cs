using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSDisplay : MonoBehaviour
{
    public int FrameArray = 10;

    float[] delta;
    int index;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        delta = new float[FrameArray];
    }

    void Update()
    {
        text.text = GetFPS() + " FPS";
    }

    public float GetFPS()
    {
        delta[index] = Time.deltaTime;
        index++;
        if (index == FrameArray) index = 0;
        float midleDelta = 0;
        foreach(var e in delta) midleDelta += e;
        midleDelta /= FrameArray;
        return (int)(1 / midleDelta);
    }
}

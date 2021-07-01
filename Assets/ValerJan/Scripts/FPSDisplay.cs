using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSDisplay : MonoBehaviour
{
    public int FrameArray = 10;

    float[] _delta;
    int _index;
    Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
        _delta = new float[FrameArray];
    }

    void Update()
    {
        _text.text = GetFPS() + " FPS";
    }

    public float GetFPS()
    {
        _delta[_index] = Time.deltaTime;
        _index++;
        if (_index == FrameArray) _index = 0;
        float midleDelta = 0;
        foreach(var e in _delta) midleDelta += e;
        midleDelta /= FrameArray;
        return (int)(1 / midleDelta);
    }
}

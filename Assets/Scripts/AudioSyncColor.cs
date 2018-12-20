using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncColor : AudioSyncer
{
    /*//Renderer rend;
    public Color beatColor;
    public Color restColor;
    public float duration = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        if (_isBeat)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            this.GetComponent<Renderer>().material.color = Color.Lerp(restColor, beatColor, lerp);
        }
        else if (!_isBeat)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            this.GetComponent<Renderer>().material.color = Color.Lerp(beatColor, restColor, lerp);
        }

    }*/


    /*
    public Color startColor;
    public Color endColor;

    public float fadeInTime = 1f;
    public float fadeOutTime = 2f;
    public float fadeDelay = 3f;

    public SpriteRenderer _spriteRender;

    void Awake()
    {
        _spriteRender = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(colorLerpIn());
    }

    IEnumerator colorLerpIn()
    {
        for(float t = 0.01f; t < fadeInTime; t += 0.1f)
        {
            _spriteRender.material.color = Color.Lerp(startColor, endColor, t / fadeInTime);
            yield return null;
        }
        StartCoroutine(colorLerpOut());
    }

    IEnumerator colorLerpOut()
    {
        for (float t = 0.01f; t < fadeOutTime; t += 0.1f)
        {
            _spriteRender.material.color = Color.Lerp(startColor, endColor, t / fadeOutTime);
            yield return null;
        }
    }*/
}

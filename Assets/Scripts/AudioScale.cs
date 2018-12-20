using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

//derive from AudioSyncer
public class AudioScale : AudioTriggerSpectrum
{
    //scale values
    public Vector3 beatScale;   //when beat occors
    public Vector3 restScale;   //after beat is done

    //colour values
    public Color beatColor;
    public Color restColor;
    public float duration = 1.0f;



    // Use this for initialization
    void Start () {

    }//end start



    /*void FixedUpdate()
    {
        if (_isBeat)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            this.GetComponent<Image>().color = Color.Lerp(restColor, beatColor, lerp);
        }
        if (!_isBeat)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            this.GetComponent<Image>().color = Color.Lerp(beatColor, restColor, lerp);
        }

    }*/



    // overrides virtual SetTriggerSpectrum (checks if currently in a beat)
    public override void SetTriggerSpectrum () {
        base.SetTriggerSpectrum();

        if (_isBeat)
        {
            return;     //if currently in beat then return
        }//end if

        //else if not currently in a beat then lerp to restScale
        transform.localScale = Vector3.Lerp(transform.localScale, restScale, timeToRestBeat * Time.deltaTime);

        //lerps color to restColor
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        this.GetComponent<Image>().color = Color.Lerp(this.GetComponent<Image>().color, restColor, lerp);
    }//end override on update



    // overrides virtual Beat
    public override void Beat()
    {
        base.Beat();
        StopCoroutine("Scale");
        StartCoroutine("Scale", beatScale);
    }//end override on beat




    //coroutine to get scale to beatScale
    private IEnumerator Scale(Vector3 _targetScale)
    {

        Vector3 _currentScale = transform.localScale;   //calculate currentScale
        Vector3 _initalScale = _currentScale;                //calculate initialScale
        float _timer = 0;       //initialize timer

        //while currentScale is not the targetScale then lerp to targetScale
        while (_currentScale != _targetScale)
        {
            

            _currentScale = Vector3.Lerp(_initalScale, _targetScale, _timer / timeToFullScaledBeat);
            _timer += Time.deltaTime;   //increment timer

            transform.localScale = _currentScale; //assign currentScale to localScale 
                                          //does this until currentScale = targetScale. when this happens the beat is complete

            

            yield return null;
        }
        //lerps color to beatColor
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        this.GetComponent<Image>().color = Color.Lerp(this.GetComponent<Image>().color, beatColor, lerp*10);

        _isBeat = false; //beat is complete. now lerp to restScale in SetTriggerSpectrum
    }//end movetoscale
}

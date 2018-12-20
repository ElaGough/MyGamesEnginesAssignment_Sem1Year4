using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

//derive from AudioSyncer
public class AudioSyncScale : AudioSyncer {
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
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        this.GetComponent<Image>().color = Color.Lerp(this.GetComponent<Image>().color, restColor, lerp);
    }//end override on update



    // overrides virtual OnBeat
    public override void OnBeat()
    {
        base.OnBeat();
        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
    }//end override on beat




    //coroutine to get scale to beatScale
    private IEnumerator MoveToScale(Vector3 _target)
    {

        Vector3 _curr = transform.localScale;   //calculate currentScale
        Vector3 _inital = _curr;                //calculate initialScale
        float _timer = 0;       //initialize timer

        //while currentScale is not the targetScale then lerp to targetScale
        while (_curr != _target)
        {
            

            _curr = Vector3.Lerp(_inital, _target, _timer / timeToFullScaledBeat);
            _timer += Time.deltaTime;   //increment timer

            transform.localScale = _curr; //assign currentScale to localScale 
                                          //does this until currentScale = targetScale. when this happens the beat is complete

            

            yield return null;
        }
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        this.GetComponent<Image>().color = Color.Lerp(this.GetComponent<Image>().color, beatColor, lerp*10);

        _isBeat = false; //beat is complete. now lerp to restScale in SetTriggerSpectrum
    }//end movetoscale
}

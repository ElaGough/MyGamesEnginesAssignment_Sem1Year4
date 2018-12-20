using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour {

    public float triggerSpectrum;                //what spectrum value will trigger a beat
    public float minIntervalTime = 0.15f;        //min interval between each beat
    public float timeToFullScaledBeat = 0.05f;   //how much time before scale is full (viaualization completes)
    public float timeToRestBeat = 2f;            //after a beat, how much time it'll take to go to rest

    //determines if value goes above or below triggerSpectrum in current frame (this triggers a beat)
    private float _prevAudioValue; 
    private float _audioValue;

    private float _timer;          //keeps track of time step interval

    protected bool _isBeat=false;  //is a beat currently happening


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //calls virtual update base function: SetTriggerSpectrum()
        SetTriggerSpectrum();
	}



    public virtual void SetTriggerSpectrum()
    {
        _prevAudioValue = _audioValue;
        _audioValue = AudioSpectrum.spectrumValue;

        //if below triggerSpectrum
        if (_prevAudioValue > triggerSpectrum && _audioValue <= triggerSpectrum)
        {
            if (_timer > minIntervalTime)
                OnBeat();
        }//end if

        //if above triggerSpectrum
        if (_prevAudioValue <= triggerSpectrum && _audioValue > triggerSpectrum)
        {
            if (_timer > minIntervalTime)
                OnBeat();
        }

        _timer += Time.deltaTime;
    }

    public virtual void OnBeat()
    {
        Debug.Log("beat");  //print to log that a beat happened
        _timer = 0;         //reset timer interval
        _isBeat = true;     //set bool to beat is happening
    }
}

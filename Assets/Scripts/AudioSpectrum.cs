using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour {

    public static float spectrumValue { get; private set; } //generalized from spectrum data array

    private float[] m_audioSpectrum; //array to hold spectrum beats


	// Use this for initialization
	private void Start () {
        m_audioSpectrum = new float[128]; //power of 2^size
	}
	
	// Update is called once per frame
	private void Update () {
        AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming); //fills spectrum array

        //check if anythings in the spectrum array. if so then assign
        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0)
        {
            spectrumValue = m_audioSpectrum[0] * 100; //*100 => used to denormalize
        }
	}
}

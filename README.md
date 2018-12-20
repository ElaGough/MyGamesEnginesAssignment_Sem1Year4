# MyGamesEnginesAssignment_Sem1Year4 - Scaling Objects in Unity UI based on frequency in Audio

## Assignment is found in the AssignmentScene

##### this scales objects on Canvas so that they increase whenever specifications are met in the audio

##### it uses lerp method to scale the objects

### three main C# scripts are used:

###### AudioGetSpectrum: 
###### this uses AudioListener.GetSpectrumData to get the range of spectrum triggers and assigns them to an array (_audioSpectrum). It also uses FFTWindow.Hamming for this

###### AudioTriggerSpectrum: 
###### this determins when to call the Beat() function. If it is below or above the triggerSpectrum in the current frame and the timer is more then the minIntervalTime then this is called. Prints "beat" to the log when a beat happens.

###### AudioScale: 
###### uses override functions to scale the objects using Vector3.lerp. If _isBeat is true (a beat is happening) then it lerps from previous scale to target scale until the current scale is the target. This target scale is determined when the coroutine starts (beatScale). If a beat is not happening then it lerps back to restScale. These values are determined in the UI of unity and each object has their own beatScale and restScale. The same is done for colour so that it changes whenever there is a beat.

###### AudioColor: 
###### IGNORE. not used. This was used for testing purposes. This functionality was instead added to AudioScale.

### Audio

###### Audio was aquired from an empty game object called audio using AudioClip in Audio Source. The music samples included were sourced from no copywrite sources. https://www.youtube.com/watch?v=BuHIfIyT6MU. https://www.youtube.com/watch?v=0nI6qJeqFcc. https://www.youtube.com/watch?v=Ssvu2yncgWU.

### Algorithms:
###### //used when geting time for lerping colour of object. Sourced from Unity Resources
###### float lerp = Mathf.PingPong(Time.time, duration) / duration

###### //set lerp to current. Incerement timer. assign currentScale to localScale. Does this until currentScale = targetScale. when this happens the beat is complete
###### _currentScale = Vector3.Lerp(_initialScale, _targetScale, _timer / timeToFullScaledBeat); 
###### _timer += Time.deltaTime; 
###### transform.localScale = _currentScale; 

# Video:

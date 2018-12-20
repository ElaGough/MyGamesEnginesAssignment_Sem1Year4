# MyGamesEnginesAssignment_Sem1Year4 - Scaling Objects in Unity UI based on frequency in Audio

## Assignment is found in the AssignmentScene

##### this scales objects on Canvas so that they increase whenever specifications are met in the audio

##### it uses lerp method to scale the objects

### three main C# scripts are used:

###### AudioGetSpectrum: this uses AudioListener.GetSpectrumData to get the range of spectrum triggers and assigns them to an array (_audioSpectrum). It also uses FFTWindow.Hamming for this

###### AudioTriggerSpectrum: this determins when to call the Beat() function. If it is below or above the triggerSpectrum in the current frame and the timer is more then the minIntervalTime then this is called. Prints "beat" to the log when a beat happens.

###### AudioScale:

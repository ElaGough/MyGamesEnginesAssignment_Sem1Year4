# MyGamesEnginesAssignment_Sem1Year4 - Scaling Objects in Unity UI based on frequency in Audio

## Assignment is found in the AssignmentScene

##### this scales objects on Canvas so that they increase whenever specifications are met in the audio

##### it uses lerp method to scale the objects

### three main C# scripts are used:
###### AudioGetSpectrum: this uses AudioListener.GetSpectrumData to get the range of spectrum triggers and assigns them to an array (_audioSpectrum). It also uses FFTWindow.Hamming for this
###### AudioTriggerSpectrum:
###### AudioScale:

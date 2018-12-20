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
[![YouTube](data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAATYAAACjCAMAAAA3vsLfAAAAe1BMVEX///8AAABTU1NmZmb19fW+vr5JSUmQkJCAgID7+/uNjY2FhYXu7u7T09P4+Pinp6fa2tp0dHTExMSysrItLS1fX1/Ozs5AQECcnJzl5eXf39+goKA5OTmVlZW0tLQSEhIhISEZGRkoKChsbGwNDQ1PT08gICA9PT0RERG1bWmZAAAGO0lEQVR4nO2d61rjIBBAG+0t2samt7VXbVe7+/5PuLLaJoEBBhoSIHN+F4XzhQSGAXo9giAIoinSzWw6nW3StusREJNjvkx+WObHSdv1CYLBKuF4GLRdJ+9ZXHhpjMui7Xp5zWwPSWPsZ23XzV8OMmmMQ9u185UHlbWvV1zb9fOSvrSD3jpqv+06+ke61Fn7Go3QMI5nqLeWJMO2a9kIk/VgcRxMMX1rjLGWJGPndW6beX66da7nqebHA5y1JIl75JvxYwn1gDXFWkuSmF9vC6C957n89894bc/NtaJh+pIBmPTF1MdbS5JYRyEbaYv/ZHCJJxNtT822pim2iiafYW8m1pKk4fY0w0TZ5D1UZG6mTfGODBfNFCkHiuRm2qA/ETra19RRLPNmpu2t+Va5RvVi+0EYeMk/IRI2bbTMKUJAW0SIm61Nta3baJlLUA8O/7i9mGp7aaVtDkENwPi3m9GojRHdyO0D0+oVV8hgZvVNbPMrxAeBwZVCxowKYoseQTN4AC6K1PmnDfmW4l5uI1Nto3Za5wzE8ANoNvIZLYhtrVmzYneF62SdH7chtXGvdKNoGyO2iBuyk/LjLsRSX5llK21zyG9cu1+5Yoaf0tg+pL1XXLv5gNnUTJtuFSw4kMt2QgTj3cTae/Ptcow6sntFjJcZTeajm8j3er8w7QbmRibamm+Vc1CPDfBuMnjcInzYUKvr4CqMNklLWTp4EPNLcOFphtUWZy5qqo24fcIFkd00xi7K0K55ytZPUFG32CJtBZohP7De98Oj3tpjg+1oGuXEVLUMoF1ljnFduUARB1F3Mk2UM7qVFw7pY8PP4XmUkbfYomwiR7DdH/qGZ1LjuSTHKyr6QAgJ18e24Jfhceu4wr6wqQ4oLgd0SHZyOFednQ9d2hqZrkcP/yNCy9WrYYhss8g//6chvX3mL/ElyiBI7TO77yhKEAQRP+lxPI5u3cY538kSsYacHJFdp8hdGvzdTbEGu2u7KgGxK03Q2q6LnrTvCqMhcFaO/fl+QsFihUrhteSSozcPTf+WC/qtbXBy6OybIS4esquW8lqbcba8FYit3ykfnPdZGzLn6G60o1dx4dVjbehV4rvRBHt3YgmPtaFSZ2pBGSvOoNUzf7U197ApE49mJ6iAv9qaerMx5Os5QAf1Wxsyd7cWZFNz4QvqvzZkgv375/Bufkm0zaRboYPX5jDVW9JBo9DmLG9I2kFJmwL4C0ra1GgyC0kbiC6vkLRBaLPjSBuA8uxZ0iYBsSeVtAlkiHhy8NpW88H9VDYoYLZWBq+tFsqRI9RhN6SNUT6nALWngbQxStpwm+1JG6OkDXciBmljjEz/LWljFNoyXAHSxii0IY9fIW2MQhtyTyVpYxTakIkApI1RaEOe/0baGKTNCtJmBWmzgrRZQdqsIG1WkDYrSJsVpM0K0mYFabOCtFlB2qwgbVaQNitImxWkzQrSZkUntO0Pg+l6Ued2jw5oG173Mab6pEfSdqWSU2V07HqXtVWPVuyfSBsHqI0/SAJ5GVbXtQmnvRjfa9VFbWJ+s/GVOV3UBpzaMSRtFSBtwIlMtfTSuLV9AD8zvpC0e9pOwM+Mb59Ta0M+vEFpgzppLSfTFNqQM4+wtAHnwyAvX8Nqg4/iDlybeM4J5sIYE23I8XNY2sQL0RXHAFhpQ173FJg2/nGrZ7Rb1ob7lAamjT81rJbBbkUbLsM+NG0Vb2ldEeDyVjXUTZ3BaUvGt1P/52fJT+7ShhoIhqctSfL5NptMdzUeVFa5wPkSqbb6qWjD3PBJ2hjV68IRl2SRNkZVG2JUQ9oY3OX0+qkCaWNw2vSXB5I2Bq9NezAmaWMI2noT9fyDtDFEbZpAHmljQNqULzjSxgC1qTqqv9pqCdsikd0+Ke2o/mrTHj1XI9JrdWUd1V9tyKh+Lciv9pvAAQN/tdUUuMWgvF8eXAL0V1tNWTEY1BdNQB3VY231LEohWGkqAnRUj7XVlbym46y/gEh48H3W1tueGrD2gLmIme+oXmvrpSPX0t4WuJpwHdVvbV/i5k/5oyvyg8Hdj88hafOIckfVfUWIgsn+ps3ZdQNRcuuoiCvFiIKfjvredj1CI2OpNctOXk9/H9lspv8RQRBE5/kHNs5ggtOtg9QAAAAASUVORK5CYII=)](https://youtu.be/tr_o0Tm0uiY)

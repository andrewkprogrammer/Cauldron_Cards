using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerControllerBehaviour : MonoBehaviour {


    int increments = 10;

    int[] musicSFXVols = new int[2] { 10, 10 };

    FMOD.Studio.Bus musicBus;
    FMOD.Studio.Bus SFXBus;


    // Use this for initialization
    void Start() {
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/music");
        SFXBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
       

    }


    public void setVolSettings(string name, int value)
    {
        if (name == "music")
        {
            musicSFXVols[0] = value;
        }
        else if (name == "SFX")
        {
            musicSFXVols[1] = value;
        }
        updateAudioVols();
    }

    void updateAudioVols()
    {
        float musicSetting = musicSFXVols[0];
        float musicVol_prcnt = musicSetting / (float)increments;
        musicBus.setVolume(musicVol_prcnt);

        float SFXSetting = musicSFXVols[1];
        float SFXVol_prcnt = SFXSetting / (float)increments;
        SFXBus.setVolume(SFXVol_prcnt);
    }

    public void setVolSettings(string name, float value)
    {
        if (name == "music")
        {
            musicBus.setVolume(value);
        }
        else if (name == "sfx")
        {
            SFXBus.setVolume(value);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Dynamic;

public class AudioManager : MonoBehaviour
{
    #region references
    private EventInstance bgmInstance;
    #endregion
    #region properties
    private static AudioManager instance;
    public static AudioManager Instance {  get { return instance; } }
    #endregion

    #region methods
    public void PlayOneShot(EventReference sound, Vector3 point)
    {
        RuntimeManager.PlayOneShot(sound, point);
    }
    private EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
    private void PlayBGM(EventReference sound)
    {
        bgmInstance = CreateInstance(sound);
        bgmInstance.start();
    }
    public void SetMusicLoopEnum(MusicLoopEnum loop)
    {
        bgmInstance.setParameterByName("loop", (float)loop);
    }
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    private void Start()
    {
        PlayBGM(FMODEvents.Instance.level1);
    }
}

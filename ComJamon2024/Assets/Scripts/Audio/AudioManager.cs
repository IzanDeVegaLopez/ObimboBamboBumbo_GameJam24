using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    #region properties
    private static AudioManager instance;
    public static AudioManager Instance {  get { return instance; } }
    #endregion

    #region methods
    public void PlayOneShot(EventReference sound, Vector3 point)
    {
        RuntimeManager.PlayOneShot(sound, point);
    }
    private void PlayBGM(EventReference sound)
    {

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
}

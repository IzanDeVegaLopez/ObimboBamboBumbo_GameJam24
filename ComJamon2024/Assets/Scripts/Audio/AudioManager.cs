using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region parameters
    [SerializeField]
    public float playerCTR = 1;
    [SerializeField]
    public float enemyCTR = 1;
    #endregion

    #region reference
    private AudioSource audioSource;
    #endregion
    #region properties
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    
    private float actualBGMTime = 0;
    #endregion

    #region methods
    public void PlayBGM()
    {
        audioSource.Play();
    }
    public void PlaySFX(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }
    public void StopBGM()
    {
        actualBGMTime = audioSource.time;
        audioSource.Stop();
    }
    public void ChangeBGM(AudioClip newBGM)
    {
        audioSource.clip = newBGM;
        PlayBGM();
    }
    public void ContinueBGM()
    {
        audioSource.time = actualBGMTime;
        audioSource.Play();
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
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        PlayBGM();
    }
}

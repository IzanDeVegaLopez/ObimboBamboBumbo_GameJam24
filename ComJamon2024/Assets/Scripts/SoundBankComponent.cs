using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBankComponent : MonoBehaviour
{
    #region references
    public AudioClip[] playerAttack;
    public AudioClip playerDash;
    public AudioClip playerHeal;
    public AudioClip playerStun;
    public AudioClip playerParry;
    public AudioClip[] playerShoot;
    public AudioClip playerGotHit;

    public AudioClip[] enemyAttack;
    public AudioClip enemyDead;

    public AudioClip[] BGM;
    #endregion

    #region properties
    private static SoundBankComponent instance;
    public static SoundBankComponent Instance {  get { return instance; } }
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

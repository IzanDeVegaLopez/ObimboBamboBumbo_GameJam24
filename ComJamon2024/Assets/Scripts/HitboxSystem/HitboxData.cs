using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HitboxData", order = 0)]
public class HitboxData : ScriptableObject
{
    public int Damage;
    public Vector3 HitboxPosition;
    public Vector3 HitboxSize;
    public float ExtraVariable; //Esto depende del tipo de Overlap

    public float HitstopTime;
    public LayerMask TargetLayerMask;
}

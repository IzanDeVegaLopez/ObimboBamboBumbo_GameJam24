using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HitboxData", order = 0)]
public class HitboxData : ScriptableObject
{
    public Vector3 HitboxPosition;
    public Vector3 HitboxSize;
    public float ExtraVariable; //Esto depende del tipo de Overlap
    public LayerMask TargetLayerMask;
}

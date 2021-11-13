using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    private AudioClip attackSound;
    [SerializeField]
    protected float atack=5;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    protected GameObject parti;
    private float cd=1;
    [SerializeField]
    private float cdt=0;
  
    public virtual void Hit()
    {
        if (cdt > Time.timeSinceLevelLoad) return;
        cdt = Time.timeSinceLevelLoad + cd;
        AudioMaster.PlaySFX2D(attackSound);
        
    }

}

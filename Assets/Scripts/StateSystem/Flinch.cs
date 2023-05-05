using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flinch : IEntityState
{
    private float duration = 0.5f;
    private float timer = 0;
    public EntityContext context { get; }

    public Flinch(EntityContext context,  float duration) {
        this.context = context;
        this.duration = duration;
        timer = duration;
    }
    public void Enter() {
        timer = duration;
     //   context.playerAnimator.Play("Base Layer.Flinch",0,1);
    }

    public void Exit() {
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            context.setDefault();
        }
    }

}

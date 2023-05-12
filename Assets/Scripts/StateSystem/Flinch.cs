using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flinch : IEntityState
{
    private float duration = 0.5f;
    private float timer = 0;
    private Vector2 pushDir;
    public EntityContext context { get; }

    public Flinch(EntityContext context,  float duration, Vector2 hitdir) {
        this.context = context;
        this.duration = duration;
        timer = duration;
        pushDir = ((Vector2)context.transform.position - hitdir).normalized;
    }
    public void Enter() {
        timer = duration;
        context.playerAnimator.Play("CharaFlinch");
        //   context.playerAnimator.Play("Base Layer.Flinch",0,1);
    }

    public void Exit() {
    }

    public void Update()
    {
        context.transform.position += (Vector3)pushDir * Time.deltaTime;
        timer -= Time.deltaTime;
        if (timer < 0) {
            context.setDefault();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReleaseAttack : IEntityState
{
    public EntityContext context {get;}
    private float cooldown = 0.25f;
    private float timer;
    private float releasePower;

    public PlayerReleaseAttack(EntityContext context, float releasePower ){
        this.context = context;        
        timer = cooldown;
        this.releasePower = releasePower;
    }

    public void Enter(){
        timer = cooldown;
        context.playerAnimator.Play("CharaRelease");
        
        Attack();
        
    }

    public void Exit(){

    }


    // Update is called once per frame
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            context.setDefault();
        }
    }

    private void Attack(){
        List<Collider2D> hits = new List<Collider2D> ();
        //Physics2D.OverlapCircleNonAlloc(context.transform.position,1 ,hits);        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(context.transform.position, 0.35f);

        foreach (Collider2D hit in hitColliders) {
         //   Debug.Log("Found stuff!");
            var t = hit.GetComponent<IDamageable>();
            if (t !=null) {
                if (t.team == Team.Enemy) { t.isHit(releasePower,context.transform.position); Debug.Log("Hit an enemy!"); }
                if (t.team == Team.Neutral) {
                    var dir = (hit.transform.position - context.transform.position).normalized;
                    t.isHit(releasePower, dir);
                    Debug.Log("Hit spirit!");
                }
            }
        }
    }

}

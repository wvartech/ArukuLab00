using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityContext : MonoBehaviour {

    protected IEntityState currentState;
    protected IEntityState defaultState;
    
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    //public ParticleSystem attackParticles;


    public Transform target {get; protected set; }
    public float speed { get; protected set; }
       
    public virtual void Update()
    {
        currentState.Update();
    }

    public void setState(IEntityState state) {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void setFacing(Vector3 facing) {
        if ((facing.x - transform.position.x ) > 0) {
            playerSprite.flipX = true;
        } else {
            playerSprite.flipX= false;
        }
    }

    public void setDefault() {
        currentState.Exit();
        currentState = defaultState;
        currentState.Enter();
    }

}

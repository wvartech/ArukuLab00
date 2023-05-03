using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityContext : MonoBehaviour {

    protected IEntityState currentState;
    protected IEntityState defaultState;
    
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;


    public Transform target {get; protected set; }
    public float speed { get; protected set; }

    void Start()
    {
    /*    Debug.Log(name + " started!");
        target = GameManager.instance.getPlayer();
        if (defaultState == null) {
            defaultState = new WaitFor(this, 1f);
            currentState = new MoveToTarget(this);
        } */
    }

    // Update is called once per frame
    public virtual void Update()
    {
        currentState.Update();
    }

    public void setState(IEntityState state) {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void setDefault() {
        currentState.Exit();
        currentState = defaultState;
        currentState.Enter();
    }

}

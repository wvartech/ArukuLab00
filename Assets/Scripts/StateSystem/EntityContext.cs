using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityContext : MonoBehaviour {

    protected IEntityState currentState;
    protected IEntityState defaultState;

    public EntityContext(IEntityState defaultState) {
        this.defaultState = defaultState;
    }

    void Start()
    {
        if (defaultState == null) {
            defaultState = new WaitFor(this, 1f);
            currentState = new MoveToTarget(this, GameManager.instance.getPlayer());
        } 
    }

    // Update is called once per frame
    public void Update()
    {
        currentState.Update();
    }

    public void setState(IEntityState state) {
        currentState = state;
        currentState.Enter();
    }

    public void setDefault() {
        currentState = defaultState;
        currentState.Enter();
    }

}

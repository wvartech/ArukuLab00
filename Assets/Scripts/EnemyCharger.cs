using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : EntityContext,IDamageable
{
    private float repositionCooldown = 1f;
    private float timer;
    public Team team {get; private set;}

    public void Start() {
        team = Team.Enemy;
        target = GameManager.instance.getPlayer();
        defaultState = new WaitFor(this, 0.65f);
        currentState = defaultState;
        timer = repositionCooldown;
    }    


    // Update is called once per frame
    new void Update()
    {
        if (currentState == defaultState) {
            timer -= Time.deltaTime;
            //Debug.Log("Timer lowering");
            if (timer < 0) {
            //    Debug.Log("Timer down");
                timer = repositionCooldown;
                setState(new Reposition(this,target.transform.position,1,0.55f));
            }
        }

        base.Update();
    }

    public void isHit(float value, Vector2 hitDir) {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var other = collision.gameObject.GetComponent<IDamageable>();
        if (other == null) { return; }
        if (other.team == Team.Player) {
            Debug.Log("Bumped into player!");
            other.isHit(0.25f, transform.position);

        }

    }
}

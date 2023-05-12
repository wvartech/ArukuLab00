using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPossesor : EntityContext, IDamageable
{    
    public Team team { get; private set; }

    

    void Start()
    {
        team = Team.Enemy;
        target = GameManager.instance.closestPossesable(transform);
        //Debug.Log(target.name);
        defaultState = new MoveToTarget(this);
        currentState = defaultState;
        speed = 0.35f;        
        
    }

    // Update is called once per frame
    new void Update()
    {
        currentState.Update();
        if (Vector3.Distance(transform.position, target.position) < 0.35f) {
         //   Debug.Log("Within range!");
         target.GetComponent<IPossesable>().Possess();
         Destroy(gameObject);
        }


    }

    public void isHit(float value, Vector2 hitDir) {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var other = collision.gameObject.GetComponent<IDamageable>();
        if (other == null) { return; }
        if (other.team == Team.Player) {
            Debug.Log("Bumped into player!");
            other.isHit(0.5f, transform.position);

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EntityContext, IDamageable
{
    private float shootingCooldown = 2;
    protected float shootingTimer;
    public GameObject bulletPrefab;

    public Team team { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        team = Team.Enemy;
        target = GameManager.instance.getPlayer();
        defaultState = new MoveToTarget(this);
        currentState = defaultState;

        shootingTimer = shootingCooldown;
        speed = 0.5f;        
    }

    // Update is called once per frame
    new void Update()
    {
        
        if (currentState == defaultState) { shootingTimer -= Time.deltaTime; }
        
        if (shootingTimer <= 0) {
            //Debug.Log("Shooting mode engage!");
            shootingTimer = shootingCooldown;
            //currentState = new Shoot(this,0.5f,3);
            setState(new Shoot(this,bulletPrefab, 0.5f, 3));
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
            other.isHit(0.5f, transform.position);

        }

    }
}

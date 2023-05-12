using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : EntityContext, IPossesable, IDamageable {
    private float shootingCooldown = 2f;
    private float shootingTimer = 0f;
    private int _chargeLevel = 0;
    [SerializeField]
    private GameObject bulletPrefab;

    private int CHARGELEVEL {
        get { return _chargeLevel; }
        set {
            _chargeLevel = value;
            //Debug.Log("Charge Level Changed");
            switch (_chargeLevel) {
                case 0:
                    playerAnimator.Play("Lantern0");
                    break;
                case 1:
                    playerAnimator.Play("Lantern1");
                    break;
                default:
                    playerAnimator.Play("Lantern2");
                    break;
            }
        }
    }

    public Team team { get; set; }

    void Start() {
        team = Team.Possessable;
        target = GameManager.instance.getPlayer();
        defaultState = new WaitFor(this, 1);
        currentState = defaultState;
    }

    // Update is called once per frame
    new void Update() {

        if (currentState == defaultState) {

            if (CHARGELEVEL == 1) {
                shootingTimer -= Time.deltaTime;
                if (shootingTimer < 0) {
                    shootingTimer = shootingCooldown;
                    setState(new ShootRandom(this, bulletPrefab, 0.35f, 3));
                }
            } else {
                if (CHARGELEVEL >= 2) {
                    shootingTimer -= Time.deltaTime * 2f;
                    if (shootingTimer < 0) {
                        shootingTimer = shootingCooldown;
                        setState(new ShootRandom(this, bulletPrefab, 0.1f, 7));
                    }
                }
            }
        }
        base.Update();
    }

    public void Possess() {
        if (CHARGELEVEL < 2) { CHARGELEVEL++; } else {
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        if (Random.value < 0.5f) {
            GameManager.instance.spawnEnemy(transform.position, 1);
        } else {
            GameManager.instance.spawnEnemy(transform.position, 2);
        }
    }

    public void isHit(float non, Vector2 hitDir) {
        if (CHARGELEVEL == 0) return;
        CHARGELEVEL = 0;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (CHARGELEVEL < 2) { return; }
        var other = collision.gameObject.GetComponent<IDamageable>();
        if (other == null) { return; }
        if (other.team == Team.Player) {
         //   Debug.Log("Bumped into player!");
            other.isHit(0.5f, transform.position);

        }

    }

}

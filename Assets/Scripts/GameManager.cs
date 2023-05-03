using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public static GameManager instance;
    public Transform[] possesables;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }
    public void Start() {
        var iDamageable = FindObjectsOfType<MonoBehaviour>().OfType<IPossesable>();
        if (iDamageable == null) { Debug.Log("Its null"); return; }
        foreach (MonoBehaviour t in iDamageable) {

            Debug.Log(t.gameObject.name);
        }
    }

    public Transform getPlayer() { return player; }

}

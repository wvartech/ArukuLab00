using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public GameObject GameOverMenu;
    public TextMeshProUGUI Ready;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI gameOverText;

    public bool timerOnline;

    public static GameManager instance;
    public List<Transform> possesables = new List<Transform>();
    private float roundTime = 60f;
    private float timer;

    //enemy prefabs
    public GameObject shooterPrefab;
    public GameObject chargerPrefab;
    public GameObject possessorPrefab;
    public GameObject bossPrefab;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(instance);
            instance = this;
        }
        var iDamageable = FindObjectsOfType<MonoBehaviour>().OfType<IPossesable>();
        if (iDamageable == null) { Debug.Log("Its null"); return; }
        foreach (MonoBehaviour t in iDamageable) {
            possesables.Add(t.transform);
            Debug.Log(t.transform.position);
            Debug.Log(t.gameObject.name);
        }
        timer = roundTime;        
        Time.timeScale = 0f;
        StartCoroutine(getReady());
    }
    
    public Transform closestPossesable(Transform requester) {
        Transform target = null;
        foreach (Transform t in possesables) {
            if (target == null) { target = t; continue; }
            if (Vector3.Distance(requester.position, t.position) < Vector3.Distance(requester.position, target.position)) {
                target = t;
            }
        }
        return target;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void RestartGame() {
        Time.timeScale = 1;
        timer = roundTime;
        LoadManager.instance.StartGame();        
    }

    public void GameOver(string text) {
        Time.timeScale = 0;
        gameOverText.text= text;
        GameOverMenu.SetActive(true);
    }

    public void Update() {
        if (timerOnline) {
            if (timer > 0) {
                timer -= Time.deltaTime;
                TimerText.text = ((int)timer).ToString();
            } else {
                TimerText.gameObject.SetActive(false);
                timerOnline = false;
                StartCoroutine(SpawnBoss());
            }
        }
    }

    public IEnumerator DisplayMessage(string text, float duration) {
        displayText.text = text;
        displayText.gameObject.SetActive(true) ;
        yield return new WaitForSeconds(duration);
        displayText.gameObject.SetActive(false);
    }

    private IEnumerator SpawnBoss() {
        yield return StartCoroutine(DisplayMessage("Now listen here you little shit. .", 3.5f));
        yield return new WaitForSeconds(2f);
        Instantiate(bossPrefab,new Vector3(0,0),Quaternion.identity);
        //Debug.Log("Boss spawned!");
    }

    public GameObject spawnEnemy(Vector2 position, int type) {
        GameObject a = null;
        switch(type) {
            case 0:
                a = Instantiate(possessorPrefab, position, Quaternion.identity);
            break;
            case 1:
                a = Instantiate(shooterPrefab, position, Quaternion.identity);
                break; 
            case 2:
                a = Instantiate(chargerPrefab, position, Quaternion.identity);
                break;
        }
        return a;
    }

    private IEnumerator getReady() {
        yield return new WaitForSecondsRealtime(0.5f);
        Ready.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        Ready.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        Ready.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        Ready.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        Ready.text = "Survive";
        Ready.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        Ready.gameObject.SetActive(false);
        timerOnline = true;

        Time.timeScale = 1;
    }

    public Transform getPlayer() { return player; }

}

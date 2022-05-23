using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject enemyPrefab;

    private GameObject player;
    private GameObject enemy;

    [SerializeField]
    private ScoreCounter    scoreCounter;
    [SerializeField]
    private Countdown       countdownPanel;
    [SerializeField]
    private ExitGame        exitGameWindow;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        enemy = Instantiate(enemyPrefab);
        player = Instantiate(playerPrefab);
        enemy.name = "Enemy";
        player.name = "Player";

        // Detect the moment when one of the units dies
        enemy.GetComponent<OnDestroyEvent>().OnDestroyEvnt += RestartGame;
        player.GetComponent<OnDestroyEvent>().OnDestroyEvnt += RestartGame;

        // Set player as the victim to the enemy
        enemy.GetComponent<MoveTo>().SetGoal(player.transform);
        StartCoroutine(StartCountdown());
    }

    private void RestartGame(GameObject go)
    {
        scoreCounter.UpdateScore(go);
        DestroyAllProjectiles();

        if (go.name == "Player")
        {
            PlayerDies(go);
        }
        else if (go.name == "Enemy")
        {
            EnemyDies(go);
        }

        enemy.GetComponent<MoveTo>().SetGoal(player.transform);
        StartCoroutine(StartCountdown());
    }

    private void PlayerDies(GameObject go)
    {
        // Bring back enemy to the starting point
        SpawningPoint sp = enemy.GetComponent<SpawningPoint>();
        enemy.transform.position = sp.spawnPoint;
        enemy.transform.eulerAngles = sp.spawnRotation;

        // Instantiate new player
        player = Instantiate(playerPrefab);
        player.name = "Player";
        player.GetComponent<OnDestroyEvent>().OnDestroyEvnt += RestartGame;
    }

    private void EnemyDies(GameObject go)
    {
        // Bring back player to the starting point
        SpawningPoint sp = player.GetComponent<SpawningPoint>();
        player.transform.position = sp.spawnPoint;
        player.transform.eulerAngles = sp.spawnRotation;

        // Instantiate new enemy
        enemy = Instantiate(enemyPrefab);
        enemy.name = "Enemy";
        enemy.GetComponent<OnDestroyEvent>().OnDestroyEvnt += RestartGame;
    }

    private void DestroyAllProjectiles()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject p in projectiles)
            Destroy(p);
    }

    private IEnumerator StartCountdown()
    {
        PrepareCountdown();

        yield return countdownPanel.StartCountdown(4);

        FinishCountdown();
    }

    private void PrepareCountdown()
    {
        // Disable all nececcery components before starting the countdown
        player.GetComponent<PlayerShooting>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        enemy.GetComponent<NavMeshAgent>().enabled = false;
        enemy.GetComponent<EnemyShooting>().enabled = false;

        countdownPanel.gameObject.SetActive(true);
        exitGameWindow.enabled = false;
    }

    private void FinishCountdown()
    {
        // Unable back all components when the countdown is finished
        exitGameWindow.enabled = true;
        countdownPanel.gameObject.SetActive(false);

        player.GetComponent<PlayerShooting>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;

        enemy.GetComponent<NavMeshAgent>().enabled = true;
        enemy.GetComponent<EnemyShooting>().enabled = true;
    }

    private void OnApplicationQuit()
    {
        if (player)
            player.GetComponent<OnDestroyEvent>().OnDestroyEvnt -= RestartGame;
        if (enemy)
            enemy.GetComponent<OnDestroyEvent>().OnDestroyEvnt -= RestartGame;
    }
    
    private void OnDestroy()
    {
        if (player)
            player.GetComponent<OnDestroyEvent>().OnDestroyEvnt -= RestartGame;
        if (enemy)
            enemy.GetComponent<OnDestroyEvent>().OnDestroyEvnt -= RestartGame;
    }
}

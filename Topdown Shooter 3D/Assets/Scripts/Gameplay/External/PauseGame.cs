using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void Pause()
    {
        GameObject player = GameObject.Find("Player");
        GameObject enemy = GameObject.Find("Enemy");

        // Disable the ability to shoot from both player and enemy while game is paused
        if (player)
            player.GetComponent<PlayerShooting>().enabled = false;
        if (enemy)
            enemy.GetComponent<EnemyShooting>().enabled = false;
        
        // Set timeScale to 0 to stop all projectiles midair
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        GameObject player = GameObject.Find("Player");
        GameObject enemy = GameObject.Find("Enemy");

        // Enable ability to shoot
        if (player)
            player.GetComponent<PlayerShooting>().enabled = true;
        if (enemy)
            enemy.GetComponent<EnemyShooting>().enabled = true;
        
        // Bring back physics
        Time.timeScale = 1;
    }
}

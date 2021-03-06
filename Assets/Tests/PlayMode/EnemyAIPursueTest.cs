using Unity;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyAIPursueTest 
{
    string SceneName = "MandonEnemyAITestPursue";
    float EnemyDistanceFromPlayer;
    float PreviousEnemyDistanceFromPlayer;

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene(SceneName);
    }

    [UnityTest]
    public IEnumerator DoesEnemyPursuePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        
        Assert.IsNotNull(enemy);
        Assert.IsNotNull(player);

        enemy.transform.position = new Vector3(12.3f, 2.5f, -2.2f); //resets enemy position
        player.transform.position = new Vector3(3.9f, 2.5f, -1.3f); //Position of player close enough so the enemy range is triggered (simulates player movement) 

        EnemyDistanceFromPlayer =Vector3.Distance(player.transform.position, enemy.transform.position);
        PreviousEnemyDistanceFromPlayer = EnemyDistanceFromPlayer;
        Debug.Log("Enemy Distance Test: " + EnemyDistanceFromPlayer);

        yield return new WaitForSeconds(0.3f);

        EnemyDistanceFromPlayer = Vector3.Distance(player.transform.position, enemy.transform.position);
        Debug.Log("Enemy Distance Test: " + EnemyDistanceFromPlayer);
        Assert.Less(EnemyDistanceFromPlayer, PreviousEnemyDistanceFromPlayer); //If the enemy is moving closer to the player, their distances should be smaller each .3 seconds. if not, enemy isnt moving towards player
        //the previous distance (1 second ago) should be BIGGER than the current distance
        //because the enemy is getting closer as the time advances, meaning the current distance (EnemyDistanceFromPlayer) is smaller than the previous!

        yield return new WaitForSeconds(0.3f);
        PreviousEnemyDistanceFromPlayer = EnemyDistanceFromPlayer;

        EnemyDistanceFromPlayer = Vector3.Distance(player.transform.position, enemy.transform.position);
        Debug.Log("Enemy Distance Test: " + EnemyDistanceFromPlayer);
        Assert.Less(EnemyDistanceFromPlayer, PreviousEnemyDistanceFromPlayer); //If the enemy is moving closer to the player, their distances should be smaller each 0.3 seconds.


        //if every second the enemy is getting closer, then the test will succeed! (and ofcourse, both the player and the enemy must exist for it to pass)
    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }

}


using Unity;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;



public class EnemyAITests 
{
    string SceneName = "MandonEnemyAITests";
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
        yield return null; //wait one frame
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        
        Assert.IsNotNull(enemy);
        Assert.IsNotNull(player);

        player.transform.position = new Vector3(3.2f, 2.5f, -3.3f); //Position of player close enough so the enemy range is triggered (simulates player movement) 
        yield return null; //wait one frame

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

        yield return new WaitForSeconds(0.3f);

        //if every second the enemy is getting closer, then the test will succeed! (and ofcourse, both the player and the enemy must exist for it to pass)
    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }

}


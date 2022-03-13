using Unity;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyAIAttackTest
{
    string SceneName = "MandonEnemyAITestAttack";

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene(SceneName);
    }

    [UnityTest]
    public IEnumerator DoesEnemyAttackPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").transform.Find("PlayerArmature").gameObject;
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        int playerOriginalHealth = player.GetComponent<PlayerStats>().CurrentHealth;
        int playerActualHealth = playerOriginalHealth;

        Assert.IsNotNull(enemy);
        Assert.IsNotNull(player);

        enemy.transform.position = new Vector3(12.3f, 2.5f, -2.2f); //resets enemy position
        player.transform.position = new Vector3(3.2f, 2.5f, -3.3f); //Position of player close enough so the enemy range is triggered (simulates player movement) 

        yield return new WaitForSeconds(6f); //wait so the enemy goes towards the player and attacks it 
        playerActualHealth = player.GetComponent<PlayerStats>().CurrentHealth;

        Assert.Less(playerActualHealth, playerOriginalHealth); //if the enemy effectively lowered the player health, this means he tracked and attacked the player effectively (code logic works)
    }

    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }
}
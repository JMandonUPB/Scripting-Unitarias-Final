using Unity;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoesPickUpHeal : MonoBehaviour
{
    string SceneName = "PickUps_TestScene";

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene(SceneName);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator DoesMyPickupHeal()
    {
        //Probar que la posición al ser usada restaure 10 de vida
       
        //Arange:
        GameObject player;        
        player = GameObject.FindGameObjectWithTag("Player");
       
        int playerOriginalHealth = player.GetComponent<PlayerStats>().CurrentHealth;
        int playerActualHealth = playerOriginalHealth;
        
        Assert.IsNotNull(player); //Me aseguro que el player exista

        player.transform.position = Vector3.zero;   
        yield return new WaitForSeconds(2);
        //Act:
        
        Assert.Greater(playerActualHealth, playerOriginalHealth); //Se asegura que haya subido la vida
        Assert.AreEqual(playerActualHealth, playerOriginalHealth + 10); //Confirma que haya subido la vida 10 unidades

        /*var healObject = new GameObject("Trigger");
        healObject.transform.position = Vector3.zero;
        healObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        var PlayerStats = healObject.AddComponent(typeof(PlayerStats)) as PlayerStats;
        var triggerBoxCollider = healObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        triggerBoxCollider.isTrigger = true;
        
        var player = new GameObject("Collider");
        player.AddComponent(typeof(BoxCollider)) as BoxCollider;
        player.AddComponent(typeof(RigidBody)) as RigidBody;
        player.transform.position = healObject.transform.position;
        *//
        //Assert.IsTrue(PlayerStats.IsTriggered);
    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }

}


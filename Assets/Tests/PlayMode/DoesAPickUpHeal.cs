using UnityEditor.SceneManagement;
using Unity;
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
        //Probar que el pick up al ser recogido restaure 10 de vida

        //Arange:
        GameObject player;
        GameObject healObject;
        healObject = GameObject.FindGameObjectWithTag("HealingPickup");
        player = GameObject.FindGameObjectWithTag("Player");
        yield return new WaitForSeconds(2);
        //Act:

        //Assert.AreEqual(10, ); //Probar que si cura 10 de daño

    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }

}


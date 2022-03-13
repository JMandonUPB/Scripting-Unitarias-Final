using UnityEditor.SceneManagement;
using Unity;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class IsPlayerInScene
{
    string SceneName = "Mandon Enemy AI Scene";

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene(SceneName);
    }
    // A Test behaves as an ordinary method
    //[Test] ESTE ES PARA EDIT MODE, NO LO USEN
    //public void IsPlayerInSceneSimplePasses()
    //{
    //    // Use the Assert class to test conditions
    //}

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator IsPlayerCurrentlyInScene()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
        GameObject gameObject;
        gameObject = GameObject.FindGameObjectWithTag("Player");

        Assert.IsNotNull(gameObject);
    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }

}

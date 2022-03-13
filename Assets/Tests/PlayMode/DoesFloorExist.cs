using UnityEditor.SceneManagement;
using Unity;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class DoesFloorExist : MonoBehaviour
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
    public IEnumerator DoesMyFloorExist()
    {
        yield return new WaitForSeconds(2);

        GameObject floor;

        floor = GameObject.FindGameObjectWithTag("Ground");
        Assert.NotNull(floor);

    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }

}
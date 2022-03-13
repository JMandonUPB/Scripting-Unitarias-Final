using UnityEditor.SceneManagement;
using Unity;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class iteamDroping 
{
    private GameObject myChest;
    private GameObject Player;
    private GameObject objeto;
    // A Test behaves as an ordinary method
    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene("Ciceri_Usuario");
       
    }
    [TearDown]
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync("Ciceri_Usuario");
    }
    [UnityTest]
    public IEnumerator TestItemDropTier1()
    {
      
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = new Vector3(-0.968f, 2f, 2.76f);

        yield return new WaitForSeconds(1);
        objeto = GameObject.FindWithTag("item");

        Assert.AreEqual(0, objeto.GetComponent<ItemLevel>().Level);
    }

 
}

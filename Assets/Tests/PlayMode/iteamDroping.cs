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
        myChest = GameObject.Find("ChestV1");
    }
    [UnityTest]
    public IEnumerator TestIteamDropLevel1()
    {
        yield return null; //wait one frame
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player);


        player.transform.position = new Vector3(-0.968f, 2f, 2.76f); 
        yield return new WaitForSeconds(2);

        objeto = GameObject.FindWithTag("item");


        Assert.IsNotNull(objeto);
        Assert.AreEqual(0, objeto.GetComponent<ItemLevel>().Level);
    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync("Ciceri_Usuario");
    }
}

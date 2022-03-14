using UnityEditor.SceneManagement;
using Unity;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class ItemChestDropinngTest 
{
    private GameObject myChest;
    private GameObject Player;
    private GameObject objeto;
    // A Test behaves as an ordinary method
    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene("CiceriTestCofreTier123");
       
    }
    [TearDown]
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync("CiceriTestCofreTier123");
    }
    [UnityTest]
    public IEnumerator TestItemDropTier1()
    {
      
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = new Vector3(-0.968f, 2f, 2.76f);

        yield return new WaitForSeconds(1);
        Assert.IsNotNull(player);
      
        objeto = GameObject.FindWithTag("item");
        Assert.IsNotNull(objeto);
        Assert.AreEqual(0, objeto.GetComponent<ItemLevel>().Level);
    }
    [UnityTest]
    public IEnumerator TestItemDropTier2()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject zone = GameObject.Find("zone_1");
        player.transform.position = new Vector3(-0.968f, 7f, 2.76f);
        zone.transform.position = new Vector3(-0.968f, 2f, 2.76f);
        yield return new WaitForSeconds(3);
        Assert.IsNotNull(player);
        objeto = GameObject.FindWithTag("item1");

        Assert.IsNotNull(objeto);
        Assert.AreEqual(1, objeto.GetComponent<ItemLevel>().Level);
    }

    [UnityTest]
    public IEnumerator TestItemDropTier3()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject zone = GameObject.Find("zone_2");
        player.transform.position = new Vector3(-0.968f, 7f, 2.76f);
        zone.transform.position = new Vector3(-0.968f, 2f, 2.76f);
        yield return new WaitForSeconds(3);
        Assert.IsNotNull(player);
        objeto = GameObject.FindWithTag("item2");
        Assert.IsNotNull(objeto);
        Assert.AreEqual(2, objeto.GetComponent<ItemLevel>().Level);
    }


}

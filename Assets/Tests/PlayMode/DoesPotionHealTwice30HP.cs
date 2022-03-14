using Unity;
using UnityEditor.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoesPotionHealTwice30HP 
{
    string SceneName = "PotionTestHealTwice";

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
        //Probar que la posición solo puede ser usada 3 veces durante 2 segundo  
        //Arange:
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");

        int playerOriginalHealth = player.GetComponent<PlayerStats>().CurrentHealth;
        int playerActualHealth = playerOriginalHealth;
        //Vamos a ver si lo siguiente es legal
        //ActiveSkillItems[] skillItems = player.GetComponent<ItemSlotsHandler>().activeSkillItems;
        Assert.IsNotNull(player); //Me aseguro que el player exista

        //imito el imput 1 a traves del get set?
        //skillItems[0].Activate(); //posición donde se encuentra la posición de regeneración
        player.GetComponent<ItemSlotsHandler>().IsInputSimulated = true; //Simula undir 1 (activar pocion) dos veces

        //player.transform.position = Vector3.zero;   
        yield return new WaitForSeconds(5);

        player.GetComponent<ItemSlotsHandler>().IsInputSimulated = false; //DEJA DE Simular undir 1 (activar pocion) dos veces

        playerActualHealth = player.GetComponent<PlayerStats>().CurrentHealth; //Actualizo la vida actual
        Assert.Greater(playerActualHealth, playerOriginalHealth); //Se asegura que haya subido la vida

        int playerHealthPlus2Potions = playerOriginalHealth + 60; //cada pocion aumenta 30, si se usan dos veces la vida deberia subir +60
        Assert.AreEqual(playerActualHealth, playerHealthPlus2Potions); //Confirma que haya subido la vida original +60 puntos (dos veces usar pocion)
    }
    public void Teardown()
    {
        EditorSceneManager.UnloadSceneAsync(SceneName);
    }

}


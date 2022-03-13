using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{


    [SerializeField]private LootTable LootTable;

    public static LootSystem Intance { get;  set; }
    [SerializeField] private int Probability;
    [SerializeField]  private int Total;


    private LootTable.Probability[] localProp;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Intance == null)
        {
            Intance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame


    private void Start()
    {

        localProp = LootTable.Prob;
        System.Array.Sort(localProp, new RarityComparator());
        System.Array.Reverse(localProp);
       
        foreach (var accountant in LootTable.Prob)
        {
            Total += accountant.rarity;
        } 
    }
    public void SpwanLoot(Transform spawnPoint, int Additional_Factor, int QuantityItem, int DropChance, bool? Repeated = null)
    {
        Probability = Random.Range(0, (Total + 1));
        int miProp = Probability * Additional_Factor;
        if (Repeated !=null)
        {
            if (Repeated == true)
            {
                for (int i = 0; i < localProp.Length; i++)
                {
                    if (miProp <= localProp[i].rarity)
                    {
                        GameObject go = Instantiate(localProp[i].Item, spawnPoint.position, Quaternion.identity);
                        if (QuantityItem == 1)
                        {
                            return;
                        }
                        QuantityItem--;
                    }
                    else
                    {
                        miProp -= localProp[i].rarity;
                    }
                }
            }
        }

        //revisamos si tengo loot o no , hay chance de 0 al 100

        int dropChanceCalculo = Random.Range(0,101);
        if (dropChanceCalculo>= DropChance)
        {
            return;
        }
        //se repite 

        if (miProp>=Total)
        {
            miProp = Total;
        }
        for (int i=0; i< localProp.Length; i++)
        {
            if(miProp<= localProp[i].rarity )
            {
                GameObject go = Instantiate(localProp[i].Item,spawnPoint.position,Quaternion.identity);
                if (QuantityItem == 1)
                {
                    return;
                }
                QuantityItem--;
            }
            else
            {

                miProp -= localProp[i].rarity;
            }
        }
        if (QuantityItem >= 1)
        {
            SpwanLoot(spawnPoint,Additional_Factor,QuantityItem,DropChance,true);
        }
        
    }
  
}

public class RarityComparator : IComparer
{
    public int Compare(object x, object y)
    {
        int n1 = ((LootTable.Probability)x).rarity;
        int n2 = ((LootTable.Probability)y).rarity;
        if(n1>n2)
        {
            return 1;
        }
        else if (n1==n2)
        {
            return 0;
        }
        else 
        {
            return -1;
        }
    }
}

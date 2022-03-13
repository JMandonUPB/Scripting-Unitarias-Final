using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{

    public int Level = 0;
    [SerializeField] int leveOn = 0;
    [SerializeField] bool Cambio = false;

    [SerializeField] private LootTable LootTable;
    [SerializeField] private LootTable[] Loots;

    public static LootSystem Intance { get; set; }
    [SerializeField] private int Probability;
    [SerializeField] private int Total;


    private LootTable.Probability[] localProp;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Intance == null)
        {
            Intance = this;
            DontDestroyOnLoad(gameObject);

            localProp = Loots[Level].Prob;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame


    private void Start()
    {
        listDrops();
    }
    private void Update()
    {

        if (Level != leveOn)
        {
            leveOn = Level;
            localProp = Loots[Level].Prob;
            listDrops();

        }
        //if (Cambio)
        //{
        //    Total = 0;
        //    leveOn = Level+1;
        //    if (leveOn >=Loots.Length)
        //    {
        //        Level = 0;
        //    }
        //    else
        //    {
        //        Level++;
        //    }
        //    localProp = Loots[Level].Prob;
        //    Start();
        //    Cambio =false;
        //}


    }
    private void listDrops()
    {

        System.Array.Sort(localProp, new RarityComparator());
        System.Array.Reverse(localProp);

        foreach (var accountant in Loots[Level].Prob)
        {
            Total += accountant.rarity;
        }
    }
    public void SpwanLoot(Transform spawnPoint, int Additional_Factor, int QuantityItem, int DropChance, bool? Repeated = null)//se hace una especie de ruleta con la probabilidad
    {
        Probability = Random.Range(0, (Total + 1));
        int miProp = Probability * Additional_Factor;
        if (Repeated != null)
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

        int dropChanceCalculo = Random.Range(0, 101);
        if (dropChanceCalculo >= DropChance)
        {
            return;
        }
        //se repite 

        if (miProp >= Total)
        {
            miProp = Total;
        }
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
        if (QuantityItem >= 1)
        {
            SpwanLoot(spawnPoint, Additional_Factor, QuantityItem, DropChance, true);
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

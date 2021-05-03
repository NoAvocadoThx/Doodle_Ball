using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostGenerator : MonoBehaviour
{
    [Header("Normal Boosts")]
    public int MAXBoostsOnScreen = 10;
    public List<GameObject> NormalBoosts;
    public float SpawnRate = 1.5f;
    public int MaxBoostsGenerateSameTime = 2;
    public Vector3 SpawnOffset = new Vector3(0, 0,-6.2f);
    public float SpawnXOffset = 2;
    public Vector2 SpawnY = new Vector2(0,0);
    [Header("Special Boosts")]
    public GameObject BoostDamage;
    public int MaxDamageGenerateSameTime = 2;
    public float UpSpawnRate = 3;
    public float DamageSpawnRate = 3;
    public float DamageSpawnXOffset = 2;
    public Vector2 DamageSpawnY = new Vector2(0, 0);

    private float timer = 0;
    private float DamageTimer = 0;
    private float PrevXPos;
    private float DamagePrevXPos;
    private float XOffset = 0;
    private float DamageXOffset = 0;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Boost").Length > MAXBoostsOnScreen)
        {
            return;
        }
        timer += Time.deltaTime;
        XOffset = Screen.width + 10;
        if (timer >= SpawnRate)
        {
            for (int i = 0; i < MaxBoostsGenerateSameTime; i++)
            {
               
                GameObject boost = NormalBoosts[Random.Range(0, NormalBoosts.Count - 1)];
                BoxCollider2D col = boost.GetComponentInChildren<BoxCollider2D>();
               
                
                Instantiate(boost, Camera.main.ScreenToWorldPoint(new Vector3(XOffset, Random.Range(SpawnY.y,Screen.height - SpawnY.x), 6)), Quaternion.identity);
                XOffset += Random.Range(0,SpawnXOffset);
                PrevXPos = boost.transform.position.x;
                if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 10, Random.Range(Screen.height - 5, 5), -6.2f))))
                {

                    DestroyImmediate(boost);
                }
            }
            timer = 0;
            SpawnRate = Random.Range(2, SpawnRate);
        }


        // for damage 
        if (GameObject.FindGameObjectsWithTag("Death").Length - 3 > MAXBoostsOnScreen )
        {
            return;
        }

        DamageTimer += Time.deltaTime;
        DamageXOffset = Screen.width + 10;
        if (DamageTimer >= DamageSpawnRate)
        {
            for (int i = 0; i < MaxDamageGenerateSameTime; i++)
            {



                Instantiate(BoostDamage, Camera.main.ScreenToWorldPoint(new Vector3(DamageXOffset, Random.Range(DamageSpawnY.y,Screen.height - DamageSpawnY.x), 6)), Quaternion.identity);
                DamageXOffset += Random.Range(0, DamageSpawnXOffset);
                DamagePrevXPos = BoostDamage.transform.position.x;
            }
            DamageTimer = 0;
            DamageSpawnRate = Random.Range(1, DamageSpawnRate);
        }

    }
}

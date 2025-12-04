using UnityEngine;

public class EnemySpawner_sc : MonoBehaviour
{
    public GameObject dusmanPrefab; 
    public float dogmaSikligi = 7f; 
    public float alanBoyutu = 50f; 


    private float zamanSayaci = 0f;

    void Update()
    {

        if (Time.time >= zamanSayaci)
        {
            Dogur();

            zamanSayaci = Time.time + dogmaSikligi;
        }
    }

    void Dogur()
    {


        float rasgeleX = Random.Range(-alanBoyutu / 2, alanBoyutu / 2);

        float rasgeleZ = Random.Range(-alanBoyutu / 2, alanBoyutu / 2);


        Vector3 dogumYeri = new Vector3(rasgeleX, 0, rasgeleZ);


        Instantiate(dusmanPrefab, dogumYeri, Quaternion.identity);
    }
}
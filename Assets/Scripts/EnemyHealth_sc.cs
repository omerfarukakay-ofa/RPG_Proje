using UnityEngine;

public class EnemyHealth_sc : MonoBehaviour
{
    public float can = 60f; 

    public GameObject[] oduller;
    public void HasarAl(float miktar)
    {
        can -= miktar;
        

        Debug.Log("Düşman hasar aldı! Kalan Can: " + can);

        if (can <= 0)
        {
            Ol();
        }
    }

    void Ol()
    {

        if(Random.value > 0.5f) 
        {

            int rasgeleIndex = Random.Range(0, oduller.Length);
            

            Instantiate(oduller[rasgeleIndex], transform.position + Vector3.up, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
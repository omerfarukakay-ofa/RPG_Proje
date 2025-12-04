using UnityEngine;

public class Ok_sc : MonoBehaviour
{
    public float hasar = 20f; 

    void Start()
    {
        
        Destroy(gameObject, 5f); 
    }


    void OnCollisionEnter(Collision collision)
    {
        // 1. Çarptığımız objenin etiketi "Enemy" mi?
        if(collision.gameObject.CompareTag("Enemy")) 
        {
            // 2. O objenin üzerindeki "DusmanSaglik" scriptine ulaş
            EnemyHealth_sc dusman = collision.gameObject.GetComponent<EnemyHealth_sc>();
            
            // 3. Script varsa hasar ver
            if(dusman != null)
            {
                dusman.HasarAl(hasar);
            }

            // 4. Oku yok et
            Destroy(gameObject); 
        }
        
        // Player'a çarpınca yok olmasın
        else if(!collision.gameObject.CompareTag("Player"))
        {
             Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class PowerUps_sc : MonoBehaviour
{
    [Header("0=Can, 1=Hiz, 2=Guc")]
    [Range(0, 2)] 
    public int gucTuruID = 0; 

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerController_sc oyuncu = other.GetComponent<PlayerController_sc>();
            PlayerController_sc oyuncuSaglik = other.GetComponent<PlayerController_sc>();

            if (oyuncu != null && oyuncuSaglik != null)
            {

                switch (gucTuruID)
                {
                    case 0: 
                        oyuncuSaglik.Iyiles(30); 
                        Debug.Log("Can Yenilendi!");
                        break;

                    case 1: 
                        oyuncu.AtisHiziniArttir();
                        Debug.Log("Atış Hızlandı!");
                        break;

                    case 2:
                        oyuncu.HasariArttir();
                        Debug.Log("Oklar Güçlendi!");
                        break;
                }
                
                Destroy(gameObject);
            }
        }
    }
}
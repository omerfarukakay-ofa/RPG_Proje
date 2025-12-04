using UnityEngine;

public class EnemyController_sc : MonoBehaviour
{
    public Transform hedef; 
    public float hiz = 3f;
    public float saldiriMesafesi = 2f;
    public int hasar = 10;
    public float saldiriHizi = 1.5f;

    private float sonrakiSaldiriZamani = 0f;

    void Start()
    {
       
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            hedef = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (hedef == null) return; 


        float mesafe = Vector3.Distance(transform.position, hedef.position);

        if (mesafe > saldiriMesafesi)
        {
   
            Vector3 hedefPozisyon = new Vector3(hedef.position.x, transform.position.y, hedef.position.z);
            transform.LookAt(hedefPozisyon);


            transform.Translate(Vector3.forward * hiz * Time.deltaTime);
        }
        else
        {

            if (Time.time >= sonrakiSaldiriZamani)
            {
                Saldir();
                sonrakiSaldiriZamani = Time.time + saldiriHizi;
            }
        }
    }

    void Saldir()
    {
        Debug.Log("Barbar sana vurdu!");

        PlayerController_sc oyuncuCan = hedef.GetComponent<PlayerController_sc>();
        if(oyuncuCan != null)
        {
            oyuncuCan.HasarAl(hasar);
        }
    }
}
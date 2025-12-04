using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController_sc : MonoBehaviour

{   
    public int can = 100;
    public float Zemin;


    [Header("Hareket Ayarları")]
    public float hareketHizi = 6f;
    public float fareHassasiyeti = 150f;
    public float ziplamaGucu = 5f;


    [Header("Güçlendirme Zamanlayıcıları")]
    public float gucSuresi = 10f;
    private float temelOkHasari;
    private float temelAtisHizi;
    
    private float hasarBitisZamani = 0f;
    private float hizBitisZamani = 0f;


    [Header("Saldırı Ayarları")]
    public GameObject okPrefab;       
    public Transform okCikisNoktasi;  
    public float okHizi = 30f;       
    public float atisHizi = 0.5f; 
    public float okHasari = 20f;    
    private float sonrakiAtisZamani = 0f;

    private Rigidbody rb;
    private bool yerdeMi = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        temelOkHasari = okHasari;
        temelAtisHizi = atisHizi;
    }




    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * fareHassasiyeti * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        
        if (Input.GetKeyDown(KeyCode.Space) && yerdeMi)
        {
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            yerdeMi = false;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= sonrakiAtisZamani)
        {
            AtesEt();
            sonrakiAtisZamani = Time.time + atisHizi;
        }
        GucKontrol();
    }


    void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        Vector3 hareket = transform.right * yatay + transform.forward * dikey;
        Vector3 yeniHiz = hareket * hareketHizi;
        yeniHiz.y = rb.linearVelocity.y; 
        rb.linearVelocity = yeniHiz;
    }


    void AtesEt()
    {
        GameObject atilanOk = Instantiate(okPrefab, okCikisNoktasi.position, okCikisNoktasi.rotation);
        Rigidbody okRb = atilanOk.GetComponent<Rigidbody>();
        okRb.linearVelocity = okCikisNoktasi.forward * okHizi;


        Ok_sc okScripti = atilanOk.GetComponent<Ok_sc>();
        if(okScripti != null)
        {
            okScripti.hasar = okHasari; 
        }
    }

    public void AtisHiziniArttir()
    {
        atisHizi = temelAtisHizi - 0.3f;
        if(atisHizi < 0.1f) atisHizi = 0.1f;
        
        hizBitisZamani = Time.time + gucSuresi;
        Debug.Log("Hız buff'ı aktif! Bitiş: " + hizBitisZamani);
    }


    public void HasariArttir()
    {
        okHasari = temelOkHasari + 30f; 
        

        hasarBitisZamani = Time.time + gucSuresi; 
        Debug.Log("Hasar buff'ı aktif! Bitiş: " + hasarBitisZamani);
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Zemin") || collision.gameObject.name == "Zemin")
        {
            yerdeMi = true;
        }

    }


public void HasarAl(int miktar)
    {
        can -= miktar;
        Debug.Log("AH! Canın azaldı: " + can);

        if(can <= 0)
        {
            Ol();
        }
    }


    public void Iyiles(int miktar)
    {
        can += miktar;
        if(can > 100) can = 100; 
        Debug.Log("İyileştin! Yeni Can: " + can);
    }

    void Ol()
    {
        Debug.Log("OYUNCU ÖLDÜ! Ana Menüye Dönülüyor.");
        
        SceneManager.LoadScene("AnaMenu");
    }
void GucKontrol()
    {
        if (okHasari != temelOkHasari && Time.time > hasarBitisZamani)
        {
            okHasari = temelOkHasari; 
            Debug.Log("Hasar buff'ı bitti. Hasar: " + okHasari);
        }
        if (atisHizi != temelAtisHizi && Time.time > hizBitisZamani)
        {
            atisHizi = temelAtisHizi; 
            Debug.Log("Hız buff'ı bitti. Atış Hızı: " + atisHizi);
        }
    }
}

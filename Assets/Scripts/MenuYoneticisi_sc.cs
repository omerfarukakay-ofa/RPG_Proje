using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.Audio;     

public class MenuYoneticisi_sc : MonoBehaviour
{
    public AudioMixer anaMixer;

    public void OyunuBaslat()
{
    Debug.Log("Oyun yükleniyor...");
    
    Destroy(gameObject); 

    SceneManager.LoadScene("OyunSahnesi");
}
    public void MuzikSesiAyarla(float volume)
    {
        anaMixer.SetFloat("MuzikVolume", Mathf.Log10(volume) * 20);
    }

    public void SFXSesiAyarla(float volume)
    {
        anaMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    public void OyundanCik()
{
    Debug.Log("Uygulama Kapatılıyor.");

    Application.Quit();
}
}
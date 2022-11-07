using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    const int CoinPoints = 1;
    [Header("Item")]
    [SerializeField] private AudioClip collectionSoundEffect;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            SoundManager.instance.PlaySound(collectionSoundEffect);
            Destroy(collision.gameObject);
            
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddCoin(CoinPoints);
           
        } 
    }
}

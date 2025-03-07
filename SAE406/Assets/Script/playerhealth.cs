using System.Collections;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public PlayerData dataplayer;
    public int maxLifePoints = 3;
    public int currentLifePoints = 3;
    public bool isInvulnerable = false;
    public float invulnerableTime = 2.25f;
    public float invulnerableFlash = 0.2f;
    public SpriteRenderer sr;
    public VoidEventChannel onPlayerDeath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dataplayer.currentLifePoints = dataplayer.maxLifePoints;
    }
    public void Hurt(int damage = 1) {
        
        if (isInvulnerable) {
            return;
        }
        dataplayer.currentLifePoints = dataplayer.currentLifePoints - damage;
        if (dataplayer.currentLifePoints <= 0) {
            onPlayerDeath.Raise();
        } else {
            StartCoroutine(Invulnerable());
        }
    }

    IEnumerator Invulnerable () {
        isInvulnerable = true;
        Color startColor = sr.color;
        WaitForSeconds invulnerableFlashWait = 
            new WaitForSeconds (invulnerableFlash);

        for (float i = 0; i <= invulnerableTime; i += invulnerableFlash)
    {
        if(sr.color.a ==1) {
            sr.color = Color.clear;
        } else {
            sr.color = startColor;
        }
        yield return invulnerableFlashWait;
    }

        sr.color = startColor;
        isInvulnerable = false;
        yield return null;
    }
}

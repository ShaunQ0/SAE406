using UnityEngine;
using UnityEngine.UI;
public class HP : MonoBehaviour
{
    public Image fillImage;
    public PlayerData dataplayer;
    public Gradient lifeColorGradient;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float lifeRatio = (float) dataplayer.currentLifePoints / (float)dataplayer.maxLifePoints;
        fillImage.fillAmount = lifeRatio;
        fillImage.color = lifeColorGradient.Evaluate(lifeRatio);
    }
}

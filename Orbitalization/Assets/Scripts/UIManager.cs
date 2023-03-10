using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Slider sliderExp;
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private TMP_Text textKills;
    
 
    [SerializeField] float sliderSpeed = 5f;

    //ItemSelector
    [SerializeField] private GameObject itemSelectorCanvas;

    private float maxHealth;
    private float currentH;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        maxHealth = GameObject.Find("Planet").GetComponent<PlanetController>().statsPlayer.health;
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = maxHealth;
        textLevel.text = $"Lv.1";
        sliderExp.maxValue = ExpManager.Instance.xpForLevels[0];
        sliderExp.value = 0;
        
    }

    private void Update()
    {
        sliderExp.value = Mathf.MoveTowards(sliderExp.value, ExpManager.Instance.currentXP, Time.deltaTime * 5);
        sliderHealth.value = Mathf.MoveTowards(sliderHealth.value, currentH, Time.deltaTime * 5);
        sliderHealth.transform.position = new Vector3(0, -10, 0) + GameObject.Find("Planet").transform.position;
        textKills.text = GameManager.instance.kills.ToString();
    }

    public void ShowExp(int xpForLevel)
    {
        sliderExp.maxValue = xpForLevel;
    }

    public void FillResetXp(int currentXp)
    {
        sliderExp.value = currentXp;
    }

    public void ShowLevel(int currentLevel)
    {
        textLevel.text = $"Lv.{currentLevel + 1}";
    }

    public void ActivateItemSelector()
    {
        itemSelectorCanvas.SetActive(true);
    }

    public void DeactivateItemSelector()
    {
        itemSelectorCanvas.SetActive(false);
    }
    public void ShowHealth(float currentHealth, float maxHealth)
    {
        sliderHealth.maxValue = maxHealth;
      
        currentH = currentHealth;
        
    }

}

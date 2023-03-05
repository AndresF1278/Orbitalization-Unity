using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance;

    [SerializeField] public int CurrentXP;
    [SerializeField] private List<int> XPForLevels;
    [SerializeField] private int currentLevel;
    


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CurrentXP = 0;
        currentLevel = 0;
      
    }
    

    public void SetXPValue(int InputXP)
    {
        if (InputXP > 0)
        {
            CurrentXP += InputXP;
            UIManager.Instance.ShowExp( XPForLevels[currentLevel]);
        }
        LevelUp();
        
    }

    void LevelUp()
    {
        if (CurrentXP >= XPForLevels[currentLevel])
        {
            currentLevel++;
            CurrentXP = 0;
            UIManager.Instance.ShowExp(XPForLevels[currentLevel]);
            UIManager.Instance.FillResetXp(CurrentXP);
        }
    }







}

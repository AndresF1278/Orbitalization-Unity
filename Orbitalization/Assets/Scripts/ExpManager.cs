using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance;

     public int currentXP = 0;
    [SerializeField] public List<int> xpForLevels = new List<int>();
    [SerializeField] private int currentLevel = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentXP = 0;
        currentLevel = 0;
    }

    public void SetXPValue(int inputXP)
    {
        if (inputXP <= 0) return;

        currentXP += inputXP;
        if (currentXP >= xpForLevels[currentLevel])
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentXP = 0;

        UIManager.Instance.ShowExp(xpForLevels[currentLevel]);
        UIManager.Instance.ShowLevel(currentLevel);
        UIManager.Instance.ActivateItemSelector();
        ItemSelector.instance.SelectionItem();
        GameManager.instance.TogglePause();
        UIManager.Instance.FillResetXp(currentXP);
    }
}

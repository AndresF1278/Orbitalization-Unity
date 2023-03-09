using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public static ItemSelector instance;
    [SerializeField] List<GameObject> items;
    [SerializeField] Transform[] posItems;
   

    private void Awake()
    {
        instance = this;
    }

    
        public void SelectionItem()
        {
            foreach (GameObject item in items)
            {
                if (item.activeSelf)
                {
                    item.SetActive(false);
                }
            }

            List<int> selectedItems = new List<int>();

            while (selectedItems.Count < 3)
            {
                int itemSelected = Random.Range(0, items.Count);
                if (!items[itemSelected].activeInHierarchy && !selectedItems.Contains(itemSelected))
                {
                    items[itemSelected].transform.position = posItems[selectedItems.Count].position;
                    items[itemSelected].SetActive(true);
                    selectedItems.Add(itemSelected);
                }
            }
            selectedItems.Clear();
        }

    }

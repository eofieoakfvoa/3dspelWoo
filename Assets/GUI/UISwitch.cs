using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UISwitch : MonoBehaviour
{
    [Serializable]
    private class Info
    {
        public GameObject Origin;
        public GameObject Output;
        public bool expandOnSelection;
        public float Scale;
    }
    [SerializeField] private Info[] m_Info;


    private int Count;
    private int CurrentlySelected = 0;
    private int previousSelected;


    void Start()
    {
        Count = m_Info.Length;
    }

    // Update is called once per frame
    void Update()
    {
        print(CurrentlySelected);
        print("Count is currently " + Count);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CurrentlySelected += 1;
            if (CurrentlySelected >= Count)
            {
                CurrentlySelected = 0;
            }
            ExpandOnSelection();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CurrentlySelected -= 1;
            if (CurrentlySelected < 0)
            {
                CurrentlySelected = Count - 1;
            }
            ExpandOnSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            m_Info[CurrentlySelected].Output.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void ExpandOnSelection()
    {
        if (previousSelected != null)
        {
            UISwitch.Info previousSelectedInfo = m_Info[previousSelected];
            Vector3 UpdatedSize = new(
                1,
                1,
                1
            );
            previousSelectedInfo.Origin.transform.localScale = UpdatedSize;
        }
        UISwitch.Info currentlySelectedInfo = m_Info[CurrentlySelected];
        if (currentlySelectedInfo.expandOnSelection == true)
        {
            Vector3 currentSize = currentlySelectedInfo.Origin.transform.localScale;
            Vector3 newSize = new(
                currentSize.x + 0.05f,
                currentSize.y + 0.05f,
                currentSize.z
            );
            currentlySelectedInfo.Origin.transform.localScale = newSize;
        }

        previousSelected = CurrentlySelected;
    }
}

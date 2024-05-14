using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUItoggle : MonoBehaviour
{
    [SerializeField] private bool onByDefault;
    [SerializeField] private KeyCode key;
    [SerializeField] private GameObject Target;
    bool previousFrame;
    void Start()
    {
        previousFrame = onByDefault;
        Target.SetActive(previousFrame);

    }
    void Update()
    {
        bool CheckForButtonPress = Input.GetKeyDown(key);
        if (CheckForButtonPress)
        {
            previousFrame = !previousFrame;
            Target.SetActive(previousFrame);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevels : MonoBehaviour
{
    [SerializeField]
    private GameObject lockLevel2, lockLevel3;

    [SerializeField]
    private Button level2Button, level3Button;
    void Start()
    {
        if (!PlayerPrefs.HasKey("level1Complete") || PlayerPrefs.GetString("level1Complete").Equals("False"))
        {
            lockLevel2.SetActive(true);
            level2Button.enabled = false;
        }
        else
        {
            lockLevel2.SetActive(false);
            level2Button.enabled = true;
        }

        if (!PlayerPrefs.HasKey("level2Complete") || PlayerPrefs.GetString("level2Complete").Equals("False"))
        {
            lockLevel3.SetActive(true);
            level3Button.enabled = false;
        }
        else
        {
            lockLevel3.SetActive(false);
            level3Button.enabled = true;
        }
    }
}

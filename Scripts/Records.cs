using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Records : MonoBehaviour
{
    [SerializeField]
    private JSONHandler jsonHandler;

    [SerializeField]
    private TMP_Text[] names;

    [SerializeField]
    private TMP_Text[] scores;

    private List<PlayerData> listOfRecords;

    void Start()
    {
        listOfRecords = jsonHandler.ReadFile();

        List<PlayerData> SortedList = listOfRecords.OrderByDescending(o => o.score).ToList();

        /*if (listOfRecords == null)
        {
            for (int i = 0; i < names.Length; i++)
            {
                names[i].text = "Vazio";
                scores[i].text = "0000";
            }
        }*/
        if (listOfRecords.Count < 5)
        {
            for (int i = 0; i < SortedList.Count; i++)
            {
                names[i].text = SortedList[i].name;
                scores[i].text = SortedList[i].score.ToString();
            }
        }
        else if (listOfRecords.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                names[i].text = SortedList[i].name;
                scores[i].text = SortedList[i].score.ToString();
            }
        }
    }
}

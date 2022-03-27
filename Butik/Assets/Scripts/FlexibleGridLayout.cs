using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleGridLayout : MonoBehaviour
{
    private int postCount;
    private Vector2 position;
    private float scale = 350;
    private float space = 15;
    private int rowCount = 0;

    private void Start()
    {
        position = new Vector2(175, -175);
        postCount = transform.childCount;

        for (int i = (postCount - 1); i >= 0; i--)
        {
            transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = position;

            position.x += (scale + space);

            rowCount++;

            if (rowCount % 3 == 0)
            {
                position.y -= (scale + space);
                position.x = 175;
            }
        }
    }

    private void Update()
    {
    }
}

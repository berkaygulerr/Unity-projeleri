using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Navigation navigation;

    public void NavigationButton(string state)
    {
        switch (state)
        {
            case "home":
                navigation.SetNavState(NavState.Home);
                break;

            case "direct":
                navigation.SetNavState(NavState.Direct);
                break;

            case "like":
                navigation.SetNavState(NavState.Like);
                break;

            case "add":
                navigation.SetNavState(NavState.Add);
                break;

            case "profile":
                navigation.SetNavState(NavState.Profile);
                break;
        }
    }
}

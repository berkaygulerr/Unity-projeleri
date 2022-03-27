using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    [Header("Icons")]
    public Image homeIcon;
    public Image directIcon;
    public Image likeIcon;
    public Image addIcon;
    public Image profileIcon;

    [Header("Selected Icons")]
    public Sprite homeIconSelected;
    public Sprite directIconSelected;
    public Sprite likeIconSelected;
    public Sprite addIconSelected;
    public Sprite profileIconSelected;

    [Header("Empty Icons")]
    public Sprite homeIconEmpty;
    public Sprite directIconEmpty;
    public Sprite likeIconEmpty;
    public Sprite addIconEmpty;
    public Sprite profileIconEmpty;

    [Header("Pages")]
    public GameObject profilePage;

    [Header("Top Side Elements")]
    public Image titleImage;
    public TMP_Text nameText;

    private void Start()
    {
        SetNavState(NavState.Home);
    }

    public void SetNavState(NavState navState)
    {
        switch (navState)
        {
            case NavState.Home:
                SetSelectedIcon("home");
                SetActivePage("home");
                break;

            case NavState.Direct:
                SetSelectedIcon("direct");
                SetActivePage("direct");
                break;

            case NavState.Like:
                SetSelectedIcon("like");
                SetActivePage("like");
                break;

            case NavState.Add:
                SetSelectedIcon("add");
                SetActivePage("add");
                break;

            case NavState.Profile:
                SetSelectedIcon("profile");
                SetActivePage("profile");
                break;
        }
    }

    private void SetSelectedIcon(string page)
    {
        switch (page)
        {
            case "home":
                homeIcon.sprite = homeIconSelected;
                directIcon.sprite = directIconEmpty;
                likeIcon.sprite = likeIconEmpty;
                addIcon.sprite = addIconEmpty;
                profileIcon.sprite = profileIconEmpty;
                break;

            case "direct":
                homeIcon.sprite = homeIconEmpty;
                directIcon.sprite = directIconSelected;
                likeIcon.sprite = likeIconEmpty;
                addIcon.sprite = addIconEmpty;
                profileIcon.sprite = profileIconEmpty;
                break;

            case "like":
                homeIcon.sprite = homeIconEmpty;
                directIcon.sprite = directIconEmpty;
                likeIcon.sprite = likeIconSelected;
                addIcon.sprite = addIconEmpty;
                profileIcon.sprite = profileIconEmpty;
                break;

            case "add":
                homeIcon.sprite = homeIconEmpty;
                directIcon.sprite = directIconEmpty;
                likeIcon.sprite = likeIconEmpty;
                addIcon.sprite = addIconSelected;
                profileIcon.sprite = profileIconEmpty;
                break;

            case "profile":
                homeIcon.sprite = homeIconEmpty;
                directIcon.sprite = directIconEmpty;
                likeIcon.sprite = likeIconEmpty;
                addIcon.sprite = addIconEmpty;
                profileIcon.sprite = profileIconSelected;
                break;
        }
    }

    private void SetActivePage(string page)
    {
        switch (page)
        {
            case "home":
                SetActiveProfilePage(false);
                break;

            case "direct":
                SetActiveProfilePage(false);
                break;

            case "like":
                SetActiveProfilePage(false);
                break;

            case "add":
                SetActiveProfilePage(false);
                break;

            case "profile":
                SetActiveProfilePage(true);
                break;
        }
    }

    private void SetActiveProfilePage(bool value)
    {
        if (value)
        {
            profilePage.SetActive(true);
            titleImage.enabled = false;
            nameText.enabled = true;
        }
        else
        {
            profilePage.SetActive(false);
            titleImage.enabled = true;
            nameText.enabled = false;
        }
    }
}

public enum NavState
{
    Home, Direct, Like, Add, Profile
}

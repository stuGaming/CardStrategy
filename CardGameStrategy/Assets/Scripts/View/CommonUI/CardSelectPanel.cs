using UnityEngine;
using System.Collections;
using Assets.Scripts.Communication.Controllers;
using Assets.Scripts.Communication.Models;

public class CardSelectPanel : MonoBehaviour
{
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        Communicator.RegisterHandler(CommonUIEvents.ShowCardSelectPanel, this, showCardPanel);
    }

    private void ResetAllTriggers()
    {
        anim.ResetTrigger("ShowPanel");
        anim.ResetTrigger("HidePanel");
    }

    private void showCardPanel(Message msg)
    {
        ResetAllTriggers();
        anim.SetTrigger("ShowPanel");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HidePanel()
    {
        ResetAllTriggers();
        anim.SetTrigger("HidePanel");
    }
}

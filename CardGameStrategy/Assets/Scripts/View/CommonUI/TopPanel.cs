using Assets.Scripts.Communication.Controllers;
using Assets.Scripts.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.View.CommonUI
{
    class TopPanel:MonoBehaviour
    {
        private void Awake()
        {
            Communicator.RegisterHandler(CommonUIEvents.TestEvent, this, TestEvent);
        }

        private void TestEvent(Message message)
        {
            this.gameObject.SetActive(false);
        }
    }
}

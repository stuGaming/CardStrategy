using Assets.Scripts.Communication.Controllers;
using Assets.Scripts.Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.View.CommonUI
{
    class CommonUI:MonoBehaviour
    {
        public void OnTestButtonClick()
        {
            Communicator.SendMessage(CommonUIEvents.TestEvent);
        }

    }
}

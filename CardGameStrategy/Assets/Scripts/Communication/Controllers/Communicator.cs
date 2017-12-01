using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Communication.Controllers
{
    class Communicator : MonoBehaviour
    {
        public static Communicator instance;

        public static Dictionary<object, List<CommunicationHandler>> RegisteredHandlers = new Dictionary<object, List<CommunicationHandler>>();
        public static Dictionary<object, List<object>> RegisteredObjects = new Dictionary<object, List<object>>();

        public delegate void CommunicationHandler(Message message);
        private void Awake()
        {
            if (Communicator.instance != null)
            {
                Communicator.instance = null;
                Communicator.instance = this;
            }
            else
            {
                Communicator.instance = this;
            }
        }

        public static void SendMessage(object Identification, params object[] args)
        {
            Message msg = new Message();
            if (args.Length > 1)
            {
                
                msg.CreatePayload(args);
              
            }
            if (RegisteredHandlers.ContainsKey(Identification))
            {
                foreach (CommunicationHandler handler in RegisteredHandlers[Identification])
                {
                    handler(msg);
                }
            }
        }

        public static void RegisterHandler(object Identification, object baseObject, CommunicationHandler funct)
        {
            if (RegisteredHandlers.ContainsKey(Identification))
            {
                RegisteredHandlers[Identification].Add(funct);
            }
            else
            {
                RegisteredHandlers.Add(Identification, new List<CommunicationHandler>());
                RegisteredHandlers[Identification].Add(funct);
            }
            if (RegisteredObjects.ContainsKey(baseObject))
            {
                RegisteredObjects[baseObject].Add(Identification);
            }
            else
            {
                RegisteredObjects.Add(baseObject,new List<object>());
                RegisteredObjects[baseObject].Add(Identification);
            }


        }
    }
    public class CommunicationPair
    {
        public object key;
        public object value;


    }
    
}


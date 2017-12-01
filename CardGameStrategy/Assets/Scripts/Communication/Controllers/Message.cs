using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Communication.Controllers
{
    class Message
    {
        public Hashtable Properties = new Hashtable();

        public object this[object value]
        {
            get { return Properties[value]; }
        }

        public Message CreatePayload(params object[] args)
        {
            if (args.Length > 0)
            {
                Properties = new Hashtable();

                int counter = 0;

                if ((args.Length % 2) == 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (counter == i && i > 0)
                        {
                            counter = 0;
                        }
                        else
                        {
                            Properties.Add(args[i], args[i + 1]);
                            counter = i + 1;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            return this;
        }


    }
}

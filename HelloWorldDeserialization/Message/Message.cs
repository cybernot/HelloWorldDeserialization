using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldDeserialization
{
    [Serializable]
    public class Message
    {
        public object message;

        public Message()
            {
            char[] msg = { 'h', 'e', 'l', 'l', 'o' };
            message = new String(msg);
            }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    [System.Serializable]
    public class PlayerException : Exception
    {
        public PlayerException() { }
        public PlayerException(string message) : base(message) { }
        public PlayerException(string message, Exception inner) : base(message, inner) { }
        protected PlayerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    }

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Db4objects.Db4o;

namespace BoC.Persistence.db4o.DataContext
{
    public class Db4oDataContextSessionManager : ISessionManager
    {
        public IObjectContainer Session
        {
            get
            {
                if (Db4oDataContext.OuterDataContext == null)
                {
                    throw new DataContextException("You are using DataContextSessionManager but are accessing a session outside a unit of work");
                }
                return ((Db4oDataContext)Db4oDataContext.OuterDataContext).Session;
            }
        }
    }

    public class DataContextException : Exception
    {
        public DataContextException() { }
        public DataContextException(string message) : base(message) { }
        public DataContextException(string message, Exception innerException) : base(message, innerException) { }
        protected DataContextException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

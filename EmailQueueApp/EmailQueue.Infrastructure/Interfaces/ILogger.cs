﻿using System;
using EmailQueueApp.Infrastructure.Enums;

namespace EmailQueueApp.Infrastructure.Interfaces
{
    public interface ILogger
    {
        void WriteMessage(string message, MessageLevel msgLevel, Exception exception = null);
        void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, Exception exception, params object[] values);
        void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, params object[] values);
    }
}

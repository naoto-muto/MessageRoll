﻿using System;

namespace MessageRoll
{
    class MessageSendEvent
    {
        public void OnMessageSend(MessageEventArgs e)
        {
            CommentEventHander?.Invoke(this, e);
        }

        public event EventHandler<MessageEventArgs> CommentEventHander;
    }
}

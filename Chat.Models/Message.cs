﻿namespace Chat.Models
{
    class Message
    {
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}

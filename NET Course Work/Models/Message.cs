﻿public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
}
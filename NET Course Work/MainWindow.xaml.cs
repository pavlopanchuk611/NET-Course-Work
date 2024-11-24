using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

public partial class MainWindow : Window
{
    private AppDbContext _context;

    public MainWindow()
    {
        InitializeComponent();
        _context = new AppDbContext();
        LoadChats();
    }

    private void LoadChats()
    {
        var chats = _context.Chats.ToList();
        ChatList.ItemsSource = chats;
    }

    private void SendButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedChat = (Chat)ChatList.SelectedItem;
        if (selectedChat != null && !string.IsNullOrWhiteSpace(MessageInput.Text))
        {
            var message = new Message
            {
                Content = MessageInput.Text,
                Timestamp = DateTime.Now,
                ChatId = selectedChat.Id
            };

            _context.Messages.Add(message);
            _context.SaveChanges();
            MessageInput.Clear();
            LoadMessages(selectedChat.Id);
        }
    }

    private void LoadMessages(int chatId)
    {
        var messages = _context.Messages.Where(m => m.ChatId == chatId).ToList();
        MessageList.ItemsSource = messages;
    }
}
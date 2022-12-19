using TelegaramMessager.DAL;
using TelegaramMessager.Domain.Interface;
using TelegaramMessager.Domain.Models;
using TelegaramMessager.Domain.ViewModel;
using TelegaramMessager.Service.Implementions;
using TelegaramMessager.Service.Interface;

using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TelegramMessager
{
    public partial class Form1 : Form
    {
        private TelegramBotClient botClient;
        private readonly ApplicationDbContext _db;
        private IUserService _userService;

        public Form1()
        {
            InitializeComponent();

            _db = new ApplicationDbContext(@"host=localhost;port=5432;database=Terock_Db;username=postgres;password=gD9g)hEwZs");
            _userService = new UserService(_db);


            StartBot("5881182146:AAEBgm3Tu5AcqKMhSwavNd1OrbHujoh1NcM");
        }

        #region TelegramBot
        public async Task StartBot(string token)
        {
            botClient = new TelegramBotClient(token);
            botClient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync);
        }
        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken token)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HandleMessage(botClient, update.Message);
                return;
            }
            if (update.Type == UpdateType.CallbackQuery)
            {
                await HandleCallbackQuery(botClient, update.CallbackQuery);
                return;
            }
        }
        private async Task HandleMessage(ITelegramBotClient botClient, Telegram.Bot.Types.Message message)
        {
            var chatId = message.Chat.Id;
            var Nick = message.Chat.FirstName;
            string? messageText = message.Text;

            IUser? user = _userService.GetAllUsers(). FirstOrDefault(x => x.Id == chatId);
            if (user == null)
            {
                await Users.AddUserToDB(new TelegramUser
                {
                    Id = chatId,
                    UserName = Nick,
                    Message = new()
                    {
                        new TelegramUserMessage
                        {
                            Id = message.MessageId,
                            Message = messageText,
                            MessageId = message.MessageId
                        }
                    }
                });
            }
            else
            {
                Users.GetAllUsers().FirstOrDefault(x => x.Id == chatId)?
                    .Message.Add(new TelegramUserMessage
                    {
                        Id = message.MessageId,
                        Message = messageText,
                        MessageId = message.MessageId
                    });
            }
            TelegramUserViewModel userViewModel = new() { TelegramUser = Users.GetAllUsers().FirstOrDefault(x => x.Id == chatId) };

            sendButton.Click += delegate { SendMessage(chatId); };

            userBox.BeginInvoke(new Action(() =>
            {
                if (userBox.FindString(userViewModel.ToString()) == -1)
                {
                    userBox.Items.Add(userViewModel);
                }

            }));
            MessageBox.BeginInvoke(new Action(() =>
            {
                if (userBox.SelectedItem != null)
                {
                    string curItem = userBox.SelectedItem.ToString();
                    int index = userBox.FindString(curItem);
                    TelegramUserViewModel user = (TelegramUserViewModel)userBox.Items[index];
                    TelegramUserMessageViewModel messageViewModel = new TelegramUserMessageViewModel();

                    messageViewModel.UserMessage = new TelegramUserMessage
                    {
                        Id = message.MessageId,
                        Message = messageText,
                        MessageId = message.MessageId
                    };
                    messageViewModel.TelegramUser = user.TelegramUser;

                    MessageBox.Items.Add(messageViewModel);
                }
            }));

            userBox.Click += delegate { SelectedUser(); };


            foreach (var item in adminId)
            {
                if (chatId == item)
                {
                    isAdmin = true;
                    continue;
                }
            }
            if (!isAdmin)
            {
                await botClient.SendTextMessageAsync(chatId, $"You said:\n{messageText}", replyMarkup: CreateButtonDefault());
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId, $"{messageText}", replyMarkup: CreateButtonAdmin());

            }


        }

        private async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery? callbackQuery)
        {
            if (callbackQuery.Data.StartsWith("OK"))
            {
                await botClient.SendTextMessageAsync
                    (
                    callbackQuery.Message.Chat.Id,
                    $"OK"
                    );
                foreach (var item in adminId)
                {
                    await botClient.SendTextMessageAsync
                    (
                    item,
                    $"Задание {callbackQuery.Message.Text} принял {callbackQuery.Message.Chat.FirstName}_{callbackQuery.Message.Chat.Id}"
                    );
                }

                await botClient.DeleteMessageAsync(callbackQuery.Message.Chat.Id, callbackQuery.Message.MessageId);
                //LogBox.BeginInvoke(new Action(() => { LogBox.Text += $"{}"});
                return;
            }
            if (callbackQuery.Data.StartsWith("NO"))
            {
                await botClient.SendTextMessageAsync
                    (
                    callbackQuery.Message.Chat.Id,
                    $"NO"
                    );
                return;
            }
            if (callbackQuery.Data.StartsWith("AllSends"))
            {
                foreach (var item in Users.GetAllUsers())
                {
                    if (item.Id != callbackQuery.Message.Chat.Id)
                    {
                        await botClient.SendTextMessageAsync
                            (
                            item.Id,
                            callbackQuery.Message.Text,
                            replyMarkup: CreateButtonDefault()
                            );
                    }
                }
                return;
            }
        }


        private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private InlineKeyboardMarkup CreateButtonDefault()
        {
            return new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("OK","OK"),
                    InlineKeyboardButton.WithCallbackData("NO","NO"),
                }
            });
        }
        private InlineKeyboardMarkup CreateButtonAdmin()
        {
            return new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("OK","OK"),
                    InlineKeyboardButton.WithCallbackData("NO","NO"),
                    InlineKeyboardButton.WithCallbackData("Отправить всем","AllSends"),
                }
            });
        }


        private void SendMessage(long id)
        {
            string text = textToSend.Text;
            string sendText = textToSend.Text;
            if (text != null && text.Replace(" ", "") != "")
            {
                botClient.SendTextMessageAsync(id, sendText);
                Users.GetAllUsers().FirstOrDefault(x => x.Id == id).Message.LastOrDefault().Answer = text;
                MessageBox.Items.Add($"Support: {Users.GetAllUsers().FirstOrDefault(x => x.Id == id).Message.LastOrDefault().Answer}");
                textToSend.Text = string.Empty;
            }
            else
            {
                LogBox.Text = $"[{id}]: Текст небил отправлен поскольку он пустой\n";
            }
        }

        private void SelectedUser()
        {
            if (userBox.SelectedItem != null)
            {
                string curItem = userBox.SelectedItem.ToString();
                int index = userBox.FindString(curItem);
                TelegramUserViewModel user = (TelegramUserViewModel)userBox.Items[index];
                List<TelegramUserMessageViewModel> message = new List<TelegramUserMessageViewModel>();

                foreach (var item in user.TelegramUser.Message)
                {
                    message.Add(new TelegramUserMessageViewModel { UserMessage = item, TelegramUser = user.TelegramUser });
                }

                MessageBox.Items.Clear();

                MessageBox.Items.AddRange(message.ToArray());
            }
        }


        #endregion


        private void sendButton_Click(object sender, EventArgs e)
        {

        }
    }
}
﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LeagueActivityBot.Notifications.OnSoloGameStarted;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LeagueActivityBot.Telegram.Handlers
{
    public class OnSoloGameStartedNotificationHandler : INotificationHandler<OnSoloGameStartedNotification>
    {
        private readonly TelegramOptions _options;
        private readonly TelegramBotClient _tgClient;

        public OnSoloGameStartedNotificationHandler(TelegramOptions options, TelegramBotClient tgClient)
        {
            _options = options;
            _tgClient = tgClient;
        }

        public async Task Handle(OnSoloGameStartedNotification notification, CancellationToken cancellationToken)
        {
            var messageBuilder = new OnSoloGameStartedMessageBuilder();
            var message = messageBuilder.Build(notification);

            await _tgClient.SendTextMessageAsync(new ChatId(_options.TelegramChatId), message, disableNotification: true, parseMode:ParseMode.Html);
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Net.Mail;

using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using System;


namespace EchoBot1.Bots
{
    public class EchoBot : ActivityHandler
    {
        public static int message_count = 0;


        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await SendWelcomeMessageAsync(turnContext, cancellationToken);
                }
            }
        }


        private static async Task SendWelcomeMessageAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in turnContext.Activity.MembersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(
                        $"Hello {member.Name}! I am the SETH 2020 Support chatbot.",
                        cancellationToken: cancellationToken);
                    await turnContext.SendActivityAsync(
                        $"How can I help you today?",
                        cancellationToken: cancellationToken);
                    await SendInitialSuggestedActionsAsync(turnContext, cancellationToken);
                }
            }
        }

        private static async Task SendInitialSuggestedActionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Video", Type = ActionTypes.ImBack, Value = "Video" },
                    new CardAction() { Title = "Audio", Type = ActionTypes.ImBack, Value = "Audio" },
                    new CardAction() { Title = "Event Links", Type = ActionTypes.ImBack, Value = "Event Links" },
                    new CardAction() { Title = "Other", Type = ActionTypes.ImBack, Value = "Other" }
                },
            };
            message_count = 0;
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }

        private static string ProcessInput(string text, int message_count)
        {
            //const string confirmationText = "Confirmed. You are requesting help with";
            switch (message_count)
            {
                case 1:
                    {
                        return $"{message_count} What seems to be the video problem?";
                    }
                case 2:
                    {
                        return $"{message_count} Wired connections are more reliable than wireless connections. If possible, try to find a wired connection.";
                    }

                //research how to insert pictures - case 3 will be adjusting the HLS settings (picture required)

                case 3:
                    {
                        return $"{message_count} Try changing your webcast video settings from multicast to HLS. The change is demonstrated below. " +
                            $"(Note - you may not have a gear icon to click on as shown in the video below. " +
                            $"If you do not have a gear icon, select \"No\" when asked if this step worked.";
                    }
                //case 4:
                //    {
                //        return $"{message_count} This step is part 2 of the HLS suggestion. It will be written once images are confirmed to be included.";
                //    }
                case 4:
                    {
                        return $"{message_count} Try refreshing your window. This can be done by pressing the Function (Fn) and F5 keys together on your keyboard, " +
                            $"or by clicking the fresh icon in your browser (commonly found in the top left corner. Below is what Microsoft Edge's browser refresh button looks like.";
                    }
                case 5:
                    {
                        return $"{message_count} Try closing other tabs on your browser and programs on your computer. These can often take up bandwidth or processing power.";
                    }
                case 6:
                    {
                        return $"{message_count} Try using a different web browser. Chevron recommends using Microsoft Edge for the best viewing experience.";
                    }
                case 7:
                    {
                        return $"{message_count} I'm sorry to hear that none of the suggested solutions worked. " +
                            $"Click the link below to escalate your issue to a member of the Webcast Team.";
                    }
                case 10:
                    {
                        return $"{message_count} Try changing your webcast video settings from multicast to HLS. The change is demonstrated below. " +
                            $"(Note - you may not have a gear icon to click on as shown in the video below. " +
                            $"If you do not have a gear icon, select \"No\" when asked if this step worked.";
                    }
                case 11:
                    {
                        return $"{message_count} I'm sorry to hear that none of the suggested solutions worked. " +
                            $"Click the link below to escalate your issue to a member of the Webcast Team.";
                    }

                case 100:
                    {
                        return $"{message_count} What seems to be the audio problem?";
                    }
                case 101:
                    {
                        return $"{message_count} Ensure that your output device is set to functional hardware. " +
                            $"This can be accomplished by right-clicking the sound icon on your taskbar and clicking \"opening sound settings\" " +
                            $"Make sure the drop-down box under \"Choose your output device\" is a device that is powered, connected, and working.";
                    }
                case 102:
                    {
                        return $"{message_count} Adjust the volume on the webcast media player to a comfortable level.";
                    }
                case 103:
                    {
                        return $"{message_count} The volume slider on your device may be too low. Left-click on the sound icon on your task bar and adjust the slider to a comfortable volume.";
                    }
                case 104:
                    {
                        return $"{message_count} The volume of your browser might be too low. " +
                            $"Right click on the sound icon on your task bar and select \"Open Volume Mixer.\" Under the \"device\" column, adjust the slider to a comfortable volume.";
                    }
                case 105:
                    {
                        return $"{message_count} I'm sorry to hear that none of the suggested solutions worked. " +
                            $"Click the link below to escalate your issue to a member of the Webcast Team.";
                    }


                //webcast sound icon to be inserted
                case 150:
                    {
                        return $"{message_count} The webcast defaults to being muted. Click the mute icon within the media player to unmute the stream. For an unmute stream, refer to the image of the media player icon below." +
                            $"Adjust the volume to a comfortable level";
                    }
                case 151:
                    {
                        return $"{message_count} Ensure that your output device is set to functional hardware. " +
                            $"This can be accomplished by right-clicking the sound icon on your taskbar and clicking \"opening sound settings\" " +
                            $"Make sure the drop-down box under \"Choose your output device\" is a device that is powered, connected, and working.";
                    }
                case 152:
                    {
                        return $"{message_count} The volume slider on your device may be too low. Left-click on the sound icon on your task bar and adjust the slider to a comfortable volume.";
                    }

                case 153:
                    {
                        return $"{message_count} The volume of your browser might be too low. " +
                            $"Right click on the sound icon on your task bar and select \"Open Volume Mixer.\" Under the \"device\" column, adjust the slider to a comfortable volume.";
                    }
                case 154:
                    {
                        return $"{message_count} I'm sorry to hear that none of the suggested solutions worked. " +
                            $"Click the link below to escalate your issue to a member of the Webcast Team.";
                    }
                case 200:
                    {
                        return $"{message_count} Which event link are you looking for?";
                    }
                case 205:
                    {
                        return $"{message_count} The Live Stream link is {{insert live stream link here}}";
                    }
                case 206:
                    {
                        return $"{message_count} What were you looking for?";
                    }
                case 210:
                    {
                        return $"{message_count} The WebEx Audio Only link is {{insert audio only link here}}";
                    }
                case 211:
                    {
                        return $"{message_count} What were you looking for?";
                    }
                case 300:
                    {
                        return $"{message_count} What are you looking to do?";
                    }
                case 305:
                    {
                        return $"{message_count} For a mobile device to connect, you must be in a Chevron office and connected to the CMA2 WiFi network. " +
                            $"Each user is limited to receiving one stream, meaning that if you connect to a second device, the stream will end on the first device.";
                    }
                case 306:
                    {
                        return $"{message_count} What were you looking for?";
                    }
                case 310:
                    {
                        return $"{message_count} This is meant to escalate to the Webcast Teams chat immediately";
                    }
                case 311:
                    {
                        return $"{message_count} What were you looking for?";
                    }
                case 315:
                    {
                        return $"{message_count} This is meant to provide a way for the user to email the webcast team. Possibly provide a link or open Outlook on click.";
                    }
                case 316:
                    {
                        return $"{message_count} What were you looking for?";
                    }
                case 500:
                    {
                        return $"{message_count} Great! Happy to help!";
                    }
                default:
                    {
                        return $"{message_count} Please select one of the options below.";
                    }
            }
        }

        private static async Task SendVideoSuggestedActions1Async(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Low Quality Video", Type = ActionTypes.ImBack, Value = "Low Quality Video" },
                    new CardAction() { Title = "Choppy Video/Buffering", Type = ActionTypes.ImBack, Value = "Choppy Video/Buffering" },
                    new CardAction() { Title = "No Video/Black Screen", Type = ActionTypes.ImBack, Value = "No Video/Black Screen" }
                },
            };
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }

        private static async Task SendAudioSuggestedActions1Async(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Low Volume", Type = ActionTypes.ImBack, Value = "Low Volume" },
                    new CardAction() { Title = "No Volume", Type = ActionTypes.ImBack, Value = "No Volume" }
                },
            };
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }

        private static async Task UserConfirmationActionMethodAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Yes", Type = ActionTypes.ImBack, Value = "Yes" },
                    new CardAction() { Title = "No", Type = ActionTypes.ImBack, Value = "No" }
                },
            };
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }

        private static async Task SendEventLinkSuggestedActionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Live Stream", Type = ActionTypes.ImBack, Value = "Live Stream" },
                    new CardAction() { Title = "WebEx Audio Only", Type = ActionTypes.ImBack, Value = "WebEx Audio Only" }
                },
            };
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }

        private static async Task SendOtherSuggestedActionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Stream to Mobile Device", Type = ActionTypes.ImBack, Value = "Stream to Mobile Device" },
                    new CardAction() { Title = "Escalate to Webcast Team Chat", Type = ActionTypes.ImBack, Value = "Escalate to Webcast Team Chat" },
                    new CardAction() { Title = "Email the Webcast Team", Type = ActionTypes.ImBack, Value = "Email the Webcast Team" }
                },
            };
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }

        private static async Task SendRepeatedInitialSuggestionActionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Video", Type = ActionTypes.ImBack, Value = "Video" },
                    new CardAction() { Title = "Audio", Type = ActionTypes.ImBack, Value = "Audio" },
                    new CardAction() { Title = "Event Links", Type = ActionTypes.ImBack, Value = "Event Links" },
                    new CardAction() { Title = "Other", Type = ActionTypes.ImBack, Value = "Other" }
                },
            };
            message_count = 0;

            await turnContext.SendActivityAsync(reply, cancellationToken);
        }


        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {


            //Extract text from message activity sent by user
            var text = turnContext.Activity.Text;

            //Video

            if (text == "Video")
            {
                message_count += 1;
            }
            if (text.Equals("Low Quality Video") || text.Equals("Choppy Video/Buffering")) //|| text.Equals("No Video/Black Screen")) - this requires a seperate, shorter process
            {
                message_count += 1;
            }
            if (text.Equals("No Video/Black Screen"))
            {
                message_count = 10;
            }
            if (text.Equals("Yes"))
            {
                message_count = 500;
            }
            if (text.Equals("No"))
            {
                message_count += 1;
            }

            //Audio

            if (text == "Audio")
            {
                message_count += 100;
            }

            if (text.Equals("Low Volume"))
            {
                message_count += 1;
            }

            if (text.Equals("No Volume"))
            {
                message_count += 50;
            }

            //Event Links
            if (text.Equals("Event Links"))
            {
                message_count += 200;
            }
            if (text.Equals("Live Stream"))
            {
                message_count += 5;
            }
            if (text.Equals("WebEx Audio Only"))
            {
                message_count += 10;
            }

            //Other
            if (text.Equals("Other"))
            {
                message_count += 300;
            }
            if (text.Equals("Stream to Mobile Device"))
            {
                message_count += 5;
            }
            if (text.Equals("Escalate to Webcast Team Chat"))
            {
                message_count += 10;
            }
            if (text.Equals("Email the Webcast Team"))
            {
                message_count += 15;
            }

            // Take the input from the user and create the appropriate response.
            var responseText = ProcessInput(text, message_count);


            // Respond to the user.
            await turnContext.SendActivityAsync(responseText, cancellationToken: cancellationToken);


            if (message_count == 0)
            {
                await SendInitialSuggestedActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 1)
            {
                //Process Skype = new Process();
                //Skype.StartInfo.FileName = "C:\Program Files (x86)\Microsoft\Skype for Desktop\Skype.exe";

                await SendVideoSuggestedActions1Async(turnContext, cancellationToken);
            }
            if (message_count == 2)
            {
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            //HLS step
            if (message_count == 3)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/W3mDi4A3QIETGxYDlS/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Change_To_HLS.gif"
                });

                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            //HLS step part 2
            //if (message_count == 4)
            //{
            //    await turnContext.SendActivityAsync(
            //            $"Did this work?", cancellationToken: cancellationToken);
            //    await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            //}
            if (message_count == 4)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/Stj6LlBZ2FoFDiFsf0/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Refresh_Browser.gif"
                });

                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 5)
            {

                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 6)
            {
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 7)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://teams.microsoft.com/l/channel/19%3ae02f2529bef6451e95b8b17309766cbd%40thread.skype/General?groupId=199f405b-50c5-416b-a8af-0175aa4ccda0&tenantId=36565c3f-77e6-4025-bbb2-53e8d1a55e02",
                    ContentType = "link",
                    Name = "Join Teams Support Channel"

                });
                await turnContext.SendActivityAsync(message);

                await turnContext.SendActivityAsync(
                        $"Is there anything else I can help you with?", cancellationToken: cancellationToken);
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }



            if (message_count == 10)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/W3mDi4A3QIETGxYDlS/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Change_To_HLS.gif"
                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            //escalate if message_count = 9
            //if (message_count == 9)
            //{

            //}

            if (message_count == 11)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://teams.microsoft.com/l/channel/19%3ae02f2529bef6451e95b8b17309766cbd%40thread.skype/General?groupId=199f405b-50c5-416b-a8af-0175aa4ccda0&tenantId=36565c3f-77e6-4025-bbb2-53e8d1a55e02",
                    ContentType = "link",
                    Name = "Join Teams Support Channel"

                });
                await turnContext.SendActivityAsync(message);

                await turnContext.SendActivityAsync(
                        $"Is there anything else I can help you with?", cancellationToken: cancellationToken);
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }

            if (message_count == 100)
            {
                await SendAudioSuggestedActions1Async(turnContext, cancellationToken);
            }
            if (message_count == 101)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/ZcoPGuCKel2b7qoYOK/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Functional_Hardware.gif"
                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 102)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/Kx8SqbkkKMIabG6DPj/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Webcast_Media_Unmute.gif"
                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 103)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/jnhW6iGlhZThhwSklZ/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Increase_Windows_Volume.gif"
                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 104)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/mEcFW9WNaQYrT374ek/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Increase_Volume_Mixer.gif"

                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 105)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://teams.microsoft.com/l/channel/19%3ae02f2529bef6451e95b8b17309766cbd%40thread.skype/General?groupId=199f405b-50c5-416b-a8af-0175aa4ccda0&tenantId=36565c3f-77e6-4025-bbb2-53e8d1a55e02",
                    ContentType = "link",
                    Name = "Join Teams Support Channel"

                });
                await turnContext.SendActivityAsync(message);

                await turnContext.SendActivityAsync(
                        $"Is there anything else I can help you with?", cancellationToken: cancellationToken);
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }

            if (message_count == 150)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/Kx8SqbkkKMIabG6DPj/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Webcast_Media_Unmute.gif"
                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                    $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 151)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/ZcoPGuCKel2b7qoYOK/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Functional_Hardware.gif"
                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 152)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/jnhW6iGlhZThhwSklZ/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Increase_Windows_Volume.gif"
                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 153)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://media.giphy.com/media/mEcFW9WNaQYrT374ek/giphy.gif",
                    ContentType = "image/gif",
                    Name = "Increase_Volume_Mixer.gif"

                });
                await turnContext.SendActivityAsync(message);
                await turnContext.SendActivityAsync(
                        $"Did this work?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }

            if (message_count == 154)
            {
                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://teams.microsoft.com/l/channel/19%3ae02f2529bef6451e95b8b17309766cbd%40thread.skype/General?groupId=199f405b-50c5-416b-a8af-0175aa4ccda0&tenantId=36565c3f-77e6-4025-bbb2-53e8d1a55e02",
                    ContentType = "link",
                    Name = "Join Teams Support Channel"

                });
                await turnContext.SendActivityAsync(message);

                await turnContext.SendActivityAsync(
                        $"Is there anything else I can help you with?", cancellationToken: cancellationToken);
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 200)
            {
                await SendEventLinkSuggestedActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 205)
            {
                await turnContext.SendActivityAsync(
                        $"Is this what you were looking for?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 210)
            {
                await turnContext.SendActivityAsync(
                        $"Is this what you were looking for?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 206)
            {
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 211)
            {
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 300)
            {
                await SendOtherSuggestedActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 305)
            {
                await turnContext.SendActivityAsync(
                        $"Is this what you were looking for?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 306)
            {
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 310)
            {

                IMessageActivity message = Activity.CreateMessageActivity();
                message.Attachments.Add(new Microsoft.Bot.Schema.Attachment()
                {
                    ContentUrl = "https://teams.microsoft.com/l/channel/19%3ae02f2529bef6451e95b8b17309766cbd%40thread.skype/General?groupId=199f405b-50c5-416b-a8af-0175aa4ccda0&tenantId=36565c3f-77e6-4025-bbb2-53e8d1a55e02",
                    ContentType = "link",
                    Name = "Join Teams Support Channel"

                });
                await turnContext.SendActivityAsync(message);

                await turnContext.SendActivityAsync(
                        $"Is this what you were looking for?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 311)
            {
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 315)
            {
                //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                //oMsg.HTMLBody = "Hello, Jawed your message body will go here!!";
                //oMsg.Subject = "Your Subject will go here.";
                //Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg.Recipients;
                //Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add("kevin.ong@utexas.edu");
                //oMsg.Display(true);
                //oMsg.Send();

                //Microsoft.Office.Interop.Outlook.Application Application = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.MailItem mailItem = Application.CreateItem(OlItemType.olMailItem);
                //mailItem.Subject = "This is the subject";
                //mailItem.To = "someone@example.com";
                //mailItem.Body = "This is the message.";
                ////mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
                //mailItem.Display(true); //THIS IS THE CHANGE;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("kong9714@gmail.com");
                mail.To.Add("MBurk@chevron.com");
                mail.To.Add("Karl.Allen@chevron.com");
                mail.To.Add("Gary.Nishida@chevron.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("kong9714@gmail.com", "kong1697");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                await turnContext.SendActivityAsync(
                        $"Is this what you were looking for?", cancellationToken: cancellationToken);
                await UserConfirmationActionMethodAsync(turnContext, cancellationToken);
            }
            if (message_count == 316)
            {
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }
            if (message_count == 500)
            {
                await turnContext.SendActivityAsync(
                        $"Is there anything else I can help you with?", cancellationToken: cancellationToken);
                await SendRepeatedInitialSuggestionActionsAsync(turnContext, cancellationToken);
            }
        }

            //public async Task<User> AddMemberToTeam(GraphServiceClient graphClient, string userID, string groupID)
            //{
            //    User userToAdd = await graphClient.Users["objectID"].Request().GetAsync();
            //    await graphClient.Groups["groupObjectID"].Members.References.Request().AddAsync(userToAdd);

            //}
        

    }
}

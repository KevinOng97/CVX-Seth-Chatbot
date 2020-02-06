// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace EchoBot1
{
    public static class Cards
    {
        public static AnimationCard GetAnimationCard()
        {
            var changeToHLS = new AnimationCard
            {
                Title = "Change to HLS",
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "https://media.giphy.com/media/IhOfSZ95jrPHA2sVCC/giphy.gif",
                    },
                },
            };

            return changeToHLS;
        }

        
    }
}

﻿using Programatica.VerySimpleLogger.Data.Models;
using System;
using System.Threading.Tasks;

namespace Programatica.VerySimpleLogger.Client.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            VerySimpleLogger.ServerUrl = "https://localhost:44339/api/logs/";
            await VerySimpleLogger.LogAsync("caller", "level", "message " + DateTime.Now );

        }
    }
}

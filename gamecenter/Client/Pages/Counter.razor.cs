using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gamecenter.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace gamecenter.Client.Pages
{
    public partial class Counter 
    {
        private int currentCount = 0;
        public void IncrementCount()
        {
            currentCount++;
        }
    }
}
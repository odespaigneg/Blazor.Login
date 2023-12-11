using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Login.Client.Pages.Test
{
    public partial class ToDoList
    {
        public List<ToDo> ToDos { get; set; }
        public int TotalMinutes { get; set; }

        protected override void OnInitialized()
        {
            ToDos = new List<ToDo>()
            {
                    new ToDo() { Title = "Analysis", Minutes = 40 },
                    new ToDo() { Title = "Design", Minutes = 30 },
                    new ToDo() { Title = "Implementation", Minutes = 75 },
                    new ToDo() { Title = "Testing", Minutes = 40 }
            };

            UpdateTotalMinutes();
        }

        public void UpdateTotalMinutes()
        {
            TotalMinutes = ToDos.Sum(x => x.Minutes);
        }

        public void OnMinutesAddedHandler(MouseEventArgs e)
        {
            UpdateTotalMinutes();
        }

        public void OnMinutesSubtractedHandler(MouseEventArgs e)
        {
            UpdateTotalMinutes();
        }
    }
}

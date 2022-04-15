using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bebezor.Cards
{
    public abstract class BaseCard: ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public string Src { get; set; }

        [Parameter]
        public Action Click { get; set; }
    }
}

using Microsoft.AspNetCore.Components;

namespace Bebezor.Collapse
{
    public partial class BebezorCollapse: ComponentBase
    {
		[Parameter]
		public string? Text { get; set; }

		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		[Parameter]
		public bool Collapsed { get; set; }

		void ClickCollapse() =>
			Collapsed = !Collapsed;

		string ClassActive() =>
			Collapsed ? "bbezor-collapse-active" : "";
    }
}

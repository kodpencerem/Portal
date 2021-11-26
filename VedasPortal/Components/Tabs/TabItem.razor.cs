using Microsoft.AspNetCore.Components;

namespace VedasPortal.Components.Tabs
{
    public partial class TabItem
    {

        [CascadingParameter]
        public Tabs Parent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public bool IsActive { get; set; }

        [Parameter]
        public string Id { get; set; }

        public int Index { get; set; }

        protected override void OnInitialized()
        {
            Parent.AddItem(this);
            base.OnInitialized();
        }

    }
}
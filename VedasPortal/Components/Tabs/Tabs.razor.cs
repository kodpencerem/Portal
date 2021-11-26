using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace VedasPortal.Components.Tabs
{
    public partial class Tabs
    {

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private List<TabItem> _items = new();


        int index = 1;

        internal void AddItem(TabItem tabItem)
        {
            if (index == 1)
                tabItem.IsActive = true;
            tabItem.Index = index++;
            _items.Add(tabItem);
            StateHasChanged();
        }

        public void ActivateItem(string index)
        {
            DeactivateAll();
            var item = _items.SingleOrDefault(i => i.Id == index);
            item.IsActive = true;
            StateHasChanged();
        }

        public void MoveNext()
        {

        }

        public void MoveBack()
        {

        }

        private void DeactivateAll()
        {
            foreach (var item in _items)
            {
                item.IsActive = false;
            }
        }

    }
}
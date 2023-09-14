using Syncfusion.Maui.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewMaui
{
    public class Behavior :Behavior<SfTreeView>
    {
        private SfTreeView sftreeView;

        protected override void OnAttachedTo(SfTreeView bindable)
        {
            sftreeView = bindable;
            sftreeView.QueryNodeSize += SftreeView_QueryNodeSize;
            base.OnAttachedTo(bindable);
        }

        private void SftreeView_QueryNodeSize(object sender, QueryNodeSizeEventArgs e)
        {
            // Returns item height based on the content loaded.
            e.Height = e.GetActualNodeHeight();
            e.Handled = true;
        }

        protected override void OnDetachingFrom(SfTreeView bindable)
        {
            sftreeView.QueryNodeSize -= SftreeView_QueryNodeSize;
            sftreeView = null;
            base.OnDetachingFrom(bindable);
        }
    }
}

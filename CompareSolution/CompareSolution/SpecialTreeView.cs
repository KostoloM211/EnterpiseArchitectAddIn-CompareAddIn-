﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EA;


namespace CompareSolution
{
    class SpecialTreeView : TreeView
    {
        public SpecialTreeView()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e) {
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = e.Node.ForeColor;
            if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;
            if (e.Node == e.Node.TreeView.SelectedNode) {
                fore = SystemColors.HighlightText;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, SystemColors.Highlight);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
            else {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
        }
    }
}

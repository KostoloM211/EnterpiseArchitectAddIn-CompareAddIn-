using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EA;


namespace CompareSolution.Forms
{
    public partial class Choise : Form
    {
        HashSet<Color> existColors = new HashSet<Color>();
        List<Tuple<List<Package>, List<Package> > > pairs = new List<Tuple<List<Package>,List<Package> > >();
        public Choise()
        {
            InitializeComponent();
        }

        private void processNode(TreeNodeCollection nodes, Package p)
        {
            TreeNode node = new TreeNode();
            node.Text = p.Name;
            node.Tag = p;
            nodes.Add(node);
            if (p.Packages.Count != 0)
            {
                foreach (Package el in p.Packages)
                {
                    processNode(node.Nodes, el);
                }
            }

        }

        public Choise(Repository r)
        {
            InitializeComponent();
            var models = r.Models;
            foreach (Package el in models)
            {
                processNode(leftTreeView.Nodes, el);
                processNode(rightTreeView.Nodes, el);
            }
        }

        private void okButtonClicked(object sender, EventArgs e)
        {
            if (pairs.Count != 0)
            {
                Hide();
                Preview prev = new Preview(pairs);
                prev.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не выбрано моделей для сравнения");
            }
        }

        private void cancelButtonClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void leftTreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        private void leftTreeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
       //из правой в левую
        private void leftTreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = leftTreeView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = leftTreeView.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (targetNode != null)
            {
                if (targetNode.BackColor == Color.Empty && draggedNode.BackColor == Color.Empty)
                {
                    Color c = generateRandomColor();
                    while (existColors.Contains(c))
                    {
                        c = generateRandomColor();
                    }
                    existColors.Add(c);
                    List<Package> rightList = new List<Package>() { draggedNode.Tag as Package };
                    List<Package> leftList = new List<Package>() { targetNode.Tag as Package };

                    targetNode.BackColor = c;
                    draggedNode.BackColor = c;
                    pairs.Add(new Tuple<List<Package>, List<Package>>(leftList, rightList));
                }
                else if (targetNode.BackColor == Color.Empty && draggedNode.BackColor != Color.Empty)
                {
                    Tuple<List<Package>, List<Package>> t = searchTuple(draggedNode);
                    t.Item1.Add(targetNode.Tag as Package);
                    targetNode.BackColor = draggedNode.BackColor;

                }
                else if (draggedNode.BackColor == Color.Empty && targetNode.BackColor != Color.Empty)
                {
                    Tuple<List<Package>, List<Package>> t = searchTuple(targetNode);
                    t.Item2.Add(draggedNode.Tag as Package);
                    draggedNode.BackColor = targetNode.BackColor;
                }
            }
            
        }

        private Color generateRandomColor()
        {
            Random rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); //empty color exeption
            return randomColor;
        }

        private void rightTreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        private void rightTreeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private Tuple<List<Package>, List<Package> > searchTuple(TreeNode node)
        {
            foreach (Tuple<List<Package>, List<Package> > t in pairs)
            {
                List<Package> leftSide = t.Item1;
                List<Package> rightSide = t.Item2;
                foreach (Package p in leftSide)
                {
                    if (p == node.Tag as Package)
                    {
                        return t;
                    }

                }
                foreach (Package p in rightSide)
                {
                    if (p == node.Tag as Package)
                    {
                        return t;
                    }
                }
            }
            return null;
        }

        //из левой части в правую
        private void rightTreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = rightTreeView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = rightTreeView.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (targetNode != null)
            {
                if (targetNode.BackColor == Color.Empty && draggedNode.BackColor == Color.Empty)
                {
                    Color c = generateRandomColor();
                    while (existColors.Contains(c))
                    {
                        c = generateRandomColor();
                    }
                    existColors.Add(c);
                    List<Package> leftList = new List<Package>() { draggedNode.Tag as Package };
                    List<Package> rightList = new List<Package>() { targetNode.Tag as Package };

                    targetNode.BackColor = c;
                    draggedNode.BackColor = c;
                    pairs.Add(new Tuple<List<Package>, List<Package> >(leftList, rightList));
                }
                else if (targetNode.BackColor == Color.Empty && draggedNode.BackColor != Color.Empty)
                {
                    Tuple<List<Package>, List<Package>> t = searchTuple(draggedNode);
                    t.Item2.Add(targetNode.Tag as Package);
                    targetNode.BackColor = draggedNode.BackColor;

                }
                else if (draggedNode.BackColor == Color.Empty && targetNode.BackColor != Color.Empty)
                {
                    Tuple<List<Package>, List<Package>> t = searchTuple(targetNode);
                    t.Item1.Add(draggedNode.Tag as Package);
                    draggedNode.BackColor = targetNode.BackColor;
                }
            }

        }
     
    }
}

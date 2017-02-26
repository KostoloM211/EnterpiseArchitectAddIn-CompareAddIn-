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
    enum Data {
        Requirement, 
        Class,
        UseCase
    };

    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }
        public Preview(List<Tuple<List<Package>, List<Package>>> pairs)
        {
            InitializeComponent();

            int i = 0;
            foreach (Tuple<List<Package>, List<Package>> t in pairs) {
                List<Package> leftSide = t.Item1;
                List<Package> rightSide = t.Item2;

                TreeNode nodeTop = new TreeNode();
                nodeTop.Text = "Сравнение " + i.ToString();
                nodeTop.Tag = t;

                TreeNode nodeBot = new TreeNode();
                nodeBot.Text = "Сравнение " + i.ToString();
                nodeBot.Tag = t;

                topTreeView.Nodes.Add(nodeTop);
                botTreeView.Nodes.Add(nodeBot);

                foreach (Package p in leftSide)
                {
                    TreeNode node = new TreeNode();
                    node.Text = p.Name;
                    node.Tag = p;
                    topTreeView.Nodes[i].Nodes.Add(node);
                }

                foreach (Package p in rightSide)
                {
                    TreeNode node = new TreeNode();
                    node.Text = p.Name;
                    node.Tag = p;
                    botTreeView.Nodes[i].Nodes.Add(node);
                }

                i++;
            }
        }

        private void processElement<T>(Element el, List<T> forAdd) {
            if (el.GetType() is Package)
            {
                foreach (Element i in el.Elements)
                {
                    processElement<T>(i, forAdd);
                }
            }
            else
            {
                if (el.GetType() is T)
                {
                    forAdd.Add((T)el);
                }
            }
        }

        private Tuple<List<T>, List<T>> extractData<T>(List<Package> l, List<Package> r)
        {
            List<T> leftRes = new List<T>();
            List<T> rightRes = new List<T>();
            foreach (Package p in l)
            {
                processElement(p as Element, leftRes);
            }
            foreach (Package p in r)
            {
                processElement(p as Element, rightRes);
            }
            return new Tuple<List<T>, List<T>>(leftRes, rightRes);
        }

        private void showRequirements(List<Package> l, List<Package> r) 
        {
            Tuple<List<Requirement>, List<Requirement>> data = extractData<Requirement>(l, r);

        }


        private void showDataInListBox(Data d, ListBox lb) {
            Tuple<List<Package>, List<Package>> t = topTreeView.SelectedNode.Tag as Tuple<List<Package>, List<Package>>;
            switch (d) { 
                case Data.Requirement:
                    showRequirements(t.Item1, t.Item2);
                    break;
            }
                

        }

        private void topTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {           
            TreeNode clickedNode = e.Node;
            if (clickedNode.Parent != null)
            {
                topTreeView.SelectedNode = clickedNode.Parent;
            }
            else
            {
                TreeNode selNode = botTreeView.Nodes[clickedNode.Index];
                botTreeView.SelectedNode = selNode;
            }
            int idx = PreviewTab.SelectedIndex;
            showDataInListBox((Data)idx, );
        }
        private void botTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode clickedNode = e.Node;
            if (clickedNode.Parent != null)
            {
                botTreeView.SelectedNode = clickedNode.Parent;
            }
            else
            {
                TreeNode selNode = topTreeView.Nodes[clickedNode.Index];
                topTreeView.SelectedNode = selNode;
            }
            int idx = PreviewTab.SelectedIndex;
            showData((Data)idx);
        }

      

    }
}

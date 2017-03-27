using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using EA;
using Solution;

namespace Solution.Forms
{
    enum Data {
        Requirement, 
        UseCase,
        Class
    };

    enum Action
    {
        Changed, 
        New, 
        Deleted,
        Equal
    }

    public partial class Preview : Form
    {
        List<List<Tuple<ListBox, ListBox>>> listboxes = new List<List<Tuple<ListBox,ListBox>>>();
        List<TabControl> tabControls = new List<TabControl>();
 
        List<Tuple<List<Element>, List<Element>>> reqs = new List<Tuple<List<Element>, List<Element>>>();
        List<Tuple<List<Element>, List<Element>>> useCases = new List<Tuple<List<Element>, List<Element>>>();
        List<Tuple<List<Element>, List<Element>>> classes = new List<Tuple<List<Element>, List<Element>>>();
        List<Tuple<List<Package>, List<Package>>> data;


        public Preview()
        {
            InitializeComponent();
        }
        public Preview(List<Tuple<List<Package>, List<Package>>> pairs)
        {
            InitializeComponent();
            data = pairs;
            int i = 0;
            //Построение дерева
            foreach (Tuple<List<Package>, List<Package>> t in pairs) {
                List<Package> leftSide = t.Item1;
                List<Package> rightSide = t.Item2;

                TreeNode nodeTop = new TreeNode();
                nodeTop.Text = "Сравнение " + i.ToString();
                nodeTop.Tag = i;

                TreeNode nodeBot = new TreeNode();
                nodeBot.Text = "Сравнение " + i.ToString();
                nodeBot.Tag = i;

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

            //инициализация массивов
            for (int j = 0; j < data.Count; j++)
            {
                reqs.Add(new Tuple<List<Element>, List<Element>>(new List<Element>(), new List<Element>()));
                useCases.Add(new Tuple<List<Element>, List<Element>>(new List<Element>(), new List<Element>()));
                classes.Add(new Tuple<List<Element>, List<Element>>(new List<Element>(), new List<Element>()));
            }

            //настройка listboxes
            
            listboxes.Add(new List<Tuple<ListBox, ListBox>>());
            listboxes.Add(new List<Tuple<ListBox, ListBox>>());
            listboxes.Add(new List<Tuple<ListBox, ListBox>>());

            listboxes[0].Add(new Tuple<ListBox, ListBox>(RequirementChangedLeftListBox, RequirementChangedRightListBox));
            listboxes[0].Add(new Tuple<ListBox, ListBox>(RequirementNewLeftListBox, RequirementNewRightListBox));
            listboxes[0].Add(new Tuple<ListBox, ListBox>(RequirementDeletedLeftListBox, RequirementDeletedRightListBox));
            listboxes[0].Add(new Tuple<ListBox, ListBox>(RequirementEqualLeftListBox, RequirementEqualRightListBox));

            listboxes[1].Add(new Tuple<ListBox, ListBox>(UseCaseChangedLeftListBox, UseCaseChangedRightListBox));
            listboxes[1].Add(new Tuple<ListBox, ListBox>(UseCaseNewLeftListBox, UseCaseNewRightListBox));
            listboxes[1].Add(new Tuple<ListBox, ListBox>(UseCaseDeletedLeftListBox, UseCaseDeletedRightListBox));
            listboxes[1].Add(new Tuple<ListBox, ListBox>(UseCaseEqualLeftListBox, UseCaseEqualRightListBox));

            listboxes[2].Add(new Tuple<ListBox, ListBox>(ClassChangedLeftListBox, ClassChangedRightListBox));
            listboxes[2].Add(new Tuple<ListBox, ListBox>(ClassNewLeftListBox, ClassNewRightListBox));
            listboxes[2].Add(new Tuple<ListBox, ListBox>(ClassDeletedLeftListBox, ClassDeletedRightListBox));
            listboxes[2].Add(new Tuple<ListBox, ListBox>(ClassEqualLeftListBox, ClassEqualRightListBox));

            tabControls.Add(RequirementTabControl);
            tabControls.Add(UseCaseTabControl);
            tabControls.Add(ClassTabControl);


            //извлечение даты
            for (int j = 0; j < data.Count; j++)
            {
                Tuple<List<Package>, List<Package>> t = data[j];
                extractData(t.Item1, t.Item2, j);
            }


        }
    
        private void processLeftElement(Package p, int i)
        {
            foreach (Element el in p.Elements)
            {  
                if (el.Type == "Requirement")
                {
                    reqs[i].Item1.Add(el);
                }
                else if (el.Type == "UseCase") {
                    useCases[i].Item1.Add(el);
                }
                else if (el.Type == "Class") {
                    classes[i].Item1.Add(el);
                }
            }
            foreach (Package pack in p.Packages)
            {
                processLeftElement(pack, i);
            }
        }
        private void processRightElement(Package p, int i)
        {

            foreach (Element el in p.Elements)
            {

                if (el.Type == "Requirement")
                {
                    reqs[i].Item2.Add(el);
                }
                else if (el.Type == "UseCase")
                {
                    useCases[i].Item2.Add(el);
                }
                else if (el.Type == "Class")
                {
                    classes[i].Item2.Add(el);
                }
            }
            foreach (Package pack in p.Packages)
            {
                processRightElement(pack, i);
            }
        }

        private void extractData(List<Package> l, List<Package> r, int i)
        {
        
            foreach (Package p in l)
            {
                processLeftElement(p, i);              
            }
            foreach (Package p in r)
            {
                processRightElement(p, i);
            }
        }

        private void topTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {           
            TreeNode clickedNode = e.Node;
            if (clickedNode.Parent != null)
            {
                topTreeView.SelectedNode = clickedNode.Parent;
                return;
            }
            else
            {
                TreeNode selNode = botTreeView.Nodes[clickedNode.Index];
                botTreeView.SelectedNode = selNode;
            }
            int elementTypeIdx = ElementTypeTabControl.SelectedIndex;
            int modIdx = tabControls[elementTypeIdx].SelectedIndex;

            ListBox leftListBox = listboxes[elementTypeIdx][modIdx].Item1;
            ListBox rightListBox = listboxes[elementTypeIdx][modIdx].Item2;

            switch ((Data)elementTypeIdx) {
                case Data.Requirement:
                    showData((int)clickedNode.Tag, elementTypeIdx, modIdx, leftListBox, rightListBox, reqs);
                    break;
                case Data.UseCase:
                    showData((int)clickedNode.Tag, elementTypeIdx, modIdx, leftListBox, rightListBox, useCases);
                    break;
                case Data.Class:
                    showData((int)clickedNode.Tag, elementTypeIdx, modIdx, leftListBox, rightListBox, classes);
                    break;

            }
                                  
        }
        private void botTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode clickedNode = e.Node;
            if (clickedNode.Parent != null)
            {
                botTreeView.SelectedNode = clickedNode.Parent;
                return;
            }
            else
            {
                TreeNode selNode = topTreeView.Nodes[clickedNode.Index];
                topTreeView.SelectedNode = selNode;
            }
        }
        private void showChanged(Compare comparator, List<string> stats, ListBox left, ListBox right)
        {
            List<Tuple<Element, Element>> modifyed = comparator.getModifyed();
            List<Dictionary<string, object>> dstat = comparator.getStats();

            for (int i = 0; i < modifyed.Count; i++)
            {
                Tuple<Element, Element> cur = modifyed.ElementAt(i);
                Dictionary<string, object> d = dstat.ElementAt(i);
                Element l = cur.Item1;
                Element r = cur.Item2;

                Type dispatchType = TestDispatchUtility.DispatchUtility.GetType(l, true);
                PropertyInfo[] props = (from c in dispatchType.GetProperties() where stats.Contains(c.Name) select c).ToArray();

                foreach (PropertyInfo p in props)
                {
                    string lvalue = (string)p.GetValue(l, null);
                    string rvalue = (string)p.GetValue(r, null);
                    string name = p.Name;
                    CompareResult res = (CompareResult)d[name];
                    if (res == CompareResult.Changed)
                    {
                        left.Items.Add(name + " : " + lvalue + ":r");
                        right.Items.Add(name + " : " + rvalue + ":g");
                    }
                    else
                    {
                        left.Items.Add(name + " : " + lvalue);
                        right.Items.Add(name + " : " + rvalue);
                    }
                }
            }
        }

        private void showNew(Compare comparator, List<string> stats, ListBox right)
        {
            List<Element> newElements = comparator.getNewest();
            for (int i = 0; i < newElements.Count; i++)
            {
                Element el = newElements.ElementAt(i);
                Type dispatchType = TestDispatchUtility.DispatchUtility.GetType(el, true);
                PropertyInfo[] props = (from c in dispatchType.GetProperties() where stats.Contains(c.Name) select c).ToArray();
                foreach (PropertyInfo p in props)
                {
                    string rvalue = (string)p.GetValue(el, null);
                    string name = p.Name;
                    right.Items.Add(name + " : " + rvalue);
                }
            }
        }

        private void showDeleted(Compare comparator, List<string> stats, ListBox left)
        {
            List<Element> deleted = comparator.getDeleted();
            for (int i = 0; i < deleted.Count; i++)
            {
                Element el = deleted.ElementAt(i);
                Type dispatchType = TestDispatchUtility.DispatchUtility.GetType(el, true);
                PropertyInfo[] props = (from c in dispatchType.GetProperties() where stats.Contains(c.Name) select c).ToArray();
                foreach (PropertyInfo p in props)
                {
                    string lvalue = (string)p.GetValue(el, null);
                    string name = p.Name;
                    left.Items.Add(name + " : " + lvalue);
                }
            }
        }


        private void showData(int idx, int elementTypeIdx, int actionIdx, ListBox left, ListBox right, List<Tuple<List<Element>, List<Element>>> data)
        {
            if (left.Items.Count != 0 || right.Items.Count != 0)
            {
                return;
            }
            Tuple<List<Element>, List<Element>> t = data[idx];
            Compare comparator = new Compare(t.Item1, t.Item2);
            List<string> stats = comparator.allStats[elementTypeIdx];

            switch ((Action)actionIdx)
            {
                case Action.Changed:
                    showChanged(comparator, stats, left, right);
                    break;
                case Action.Deleted:
                    showDeleted(comparator, stats, left);
                    break;
                case Action.New:
                    showNew(comparator, stats, right);
                    break;
                case Action.Equal:
                    break;
            }  
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox lst = sender as ListBox;
            
            string txt = (string)lst.Items[e.Index];
            // Draw the background.
            e.DrawBackground();
            Graphics g = e.Graphics;

            if (txt[txt.Count() - 2] == ':')
            {
                switch (txt[txt.Count() - 1])
                {
                    case 'r':
                        g.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                        break;
                    case 'g':
                        g.FillRectangle(new SolidBrush(Color.LightGreen), e.Bounds);
                        break;
                }
                txt = txt.Substring(0, txt.Length - 2);
            }
   
            using (SolidBrush br = new SolidBrush(Color.Black))
            {
                g.DrawString(txt, this.Font, br,
                    e.Bounds.Left, e.Bounds.Top);
            }
            

            // Draw the focus rectangle if appropriate.
            e.DrawFocusRectangle();
        }

        private void tabControl_SelectedIndexChanged(object sender, TabControlEventArgs e)
        {
            int elementTypeIdx = ElementTypeTabControl.SelectedIndex;
            int modIdx = tabControls[elementTypeIdx].SelectedIndex;

            ListBox leftListBox = listboxes[elementTypeIdx][modIdx].Item1;
            ListBox rightListBox = listboxes[elementTypeIdx][modIdx].Item2;

            if (topTreeView.SelectedNode == null)
            {
                return;
            }

            TreeNode clickedNode = topTreeView.SelectedNode;

            switch ((Data)elementTypeIdx)
            {
                case Data.Requirement:
                    showData((int)clickedNode.Tag, elementTypeIdx, modIdx, leftListBox, rightListBox, reqs);
                    break;
                case Data.UseCase:
                    showData((int)clickedNode.Tag, elementTypeIdx, modIdx, leftListBox, rightListBox, useCases);
                    break;
                case Data.Class:
                    showData((int)clickedNode.Tag, elementTypeIdx, modIdx, leftListBox, rightListBox, classes);
                    break;

            }
        }

    }
}

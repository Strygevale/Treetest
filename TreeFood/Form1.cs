using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ServiceStack.Text;

namespace TreeFood
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = new TreeNode(textBox1.Text);
                treeView1.SelectedNode.Nodes.Add(node);
            }
            catch (Exception) { }

        }

        private void btnCreateTreeData()
        {
            // созданем буффер для хранения строки
            System.Text.StringBuilder buffer = new System.Text.StringBuilder();
            // цикл каждого узла дерева
            foreach (TreeNode rootNode in treeView1.Nodes)
                BuildTreeString(rootNode, buffer);
            //запись
            System.IO.File.WriteAllText(@"..\..\food.txt", buffer.ToString()); 

        }
        private void BuildTreeString(TreeNode rootNode, System.Text.StringBuilder buffer)
        {
            buffer.Append(rootNode.Text);
            buffer.Append(Environment.NewLine);
            foreach (TreeNode childNode in rootNode.Nodes)
                BuildTreeString(childNode, buffer);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveCheckedNodes(treeView1.Nodes);

        }

        //удаление узлов
        List<TreeNode> checkedNodes = new List<TreeNode>();
        void RemoveCheckedNodes(TreeNodeCollection nodes)
        {
            foreach(TreeNode node in nodes)
            { 
                if (node.Checked)
                {
                    checkedNodes.Add(node);
                }
                else
                {
                    RemoveCheckedNodes(node.Nodes);
                }
            }
            foreach (TreeNode checkedNode in checkedNodes)
            {
                nodes.Remove(checkedNode);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            btnCreateTreeData();
           
        }
    }
}

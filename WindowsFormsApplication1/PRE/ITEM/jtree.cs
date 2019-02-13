using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.ITEM
{
    class jtree
    {
        List<String> parentNode = new List<string>() { "Private", "Public", "Locked" };
 //       List<String> childNodePrivate;
        ImageList imgTree = new ImageList();
        
        public void loadIMG()
        {
            imgTree.Images.Add(Image.FromFile("privateFile.png"));
            imgTree.Images.Add(Image.FromFile("publicFile.png"));
            imgTree.Images.Add(Image.FromFile("lockedFile.png"));
            imgTree.Images.Add(Image.FromFile("childrenFile.png"));
        }
        public void fillTree( TreeView tree)
        {
            imgTree.Images.Add(Image.FromFile("privateFile.png"));
            imgTree.Images.Add(Image.FromFile("publicFile.png"));
            imgTree.Images.Add(Image.FromFile("lockedFile.png"));
            imgTree.Images.Add(Image.FromFile("childrenFile.png"));
            tree.ImageList = imgTree;

            //create rootnode
            TreeNode privateNode = new TreeNode(parentNode[0]);
            privateNode.ImageIndex = 0;
            privateNode.SelectedImageIndex = 0;

            TreeNode publicNode = new TreeNode(parentNode[1]);
            publicNode.ImageIndex = 1;
            publicNode.SelectedImageIndex = 1;

            TreeNode lockNode = new TreeNode(parentNode[2]);
            lockNode.ImageIndex = 2;
            lockNode.SelectedImageIndex = 2;

            //add node
            tree.Nodes.Add(privateNode);
            tree.Nodes.Add(publicNode);
            tree.Nodes.Add(lockNode);
        }
    }
}

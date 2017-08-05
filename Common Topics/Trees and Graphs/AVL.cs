using System;

namespace Common_Topics
{
    public class AVL_Tree
    {
        private AVL_Node _root;

        public AVL_Tree(AVL_Node root)
        {
            _root = root;
        }

        public void Insert(AVL_Node node)
        {
            _root = _Insert(_root, node);
        }

        // Insert a node and balance a tree
        private AVL_Node _Insert(AVL_Node root, AVL_Node node)
        {
            if (root == null)
            {
                return node;
            }

            if (node.ID < root.ID)
            {
                root.Left = _Insert(root.Left, node);
            }
            else
            {
                root.Right = _Insert(root.Right, node);
            }

            root.Height = Math.Max(root.RightHeight, root.LeftHeight) + 1;

            int balance = root.LeftHeight - root.RightHeight;

            // Left Left Case
            if (balance > 1 && node.ID < root.Left.ID)
            {
                return _RotateRight(root);
            }

            // Left Right Case
            if (balance > 1 && node.ID > root.Left.ID)
            {
                root.Left = _RotateLeft(root.Left);
                return _RotateRight(root);
            }

            // Right Right Case
            if (balance < -1 && node.ID > root.Right.ID)
            {
                return _RotateLeft(root);
            }

            // Right Left Case
            if (balance < -1 && node.ID < root.Right.ID)
            {
                root.Right = _RotateRight(root.Right);
                return _RotateLeft(root);
            }

            return root;
        }

        private AVL_Node _RotateLeft(AVL_Node node)
        {
            AVL_Node root = node.Right;
            node.Right = root.Left;
            root.Left = node;

            node.Height = Math.Max(node.LeftHeight, node.RightHeight) + 1;
            root.Height = Math.Max(root.LeftHeight, root.RightHeight) + 1;

            return root;
        }

        private AVL_Node _RotateRight(AVL_Node node)
        {
            AVL_Node root = node.Left;
            node.Left = root.Right;
            root.Right = node;

            node.Height = Math.Max(node.LeftHeight, node.RightHeight) + 1;
            root.Height = Math.Max(root.LeftHeight, root.RightHeight) + 1;

            return root;
        }

        public AVL_Node Root
        {
            get
            {
                return _root;
            }
        }
    }

    public class AVL_Node
    {
        private int _id;
        private AVL_Node _left = null;
        private AVL_Node _right = null;
        private int _height = 1;

        public AVL_Node(int id)
        {
            _id = id;
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public AVL_Node Left
        {
            set
            {
                _left = value;
            }
            get
            {
                return _left;
            }
        }

        public AVL_Node Right
        {
            set
            {
                _right = value;
            }
            get
            {
                return _right;
            }
        }

        public int Height
        {
            set
            {
                _height = value;
            }
            get
            {
                return _height;
            }
        }

        public int LeftHeight
        {
            get
            {
                int height = 0;

                if (_left != null)
                {
                    height = _left.Height;
                }

                return height;
            }
        }

        public int RightHeight
        {
            get
            {
                int height = 0;

                if (_right != null)
                {
                    height = _right.Height;
                }

                return height;
            }
        }
    }
}
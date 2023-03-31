using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class TreeNode
    {
        public TreeNode(char data)
        {
            this.Data = data;
        }

        public char Data;

        public TreeNode Left;

        public TreeNode Right;

        private static uint Count = 1;
        private static uint Index = 0;

        public void Insert(char data)
        {
            if (data < Data)
            {
                if (Left == null)
                {
                    Left = new TreeNode(data);
                    Count++;
                }
                else
                    Left.Insert(data);
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode(data);
                    Count++;
                }
                else
                    Right.Insert(data);
            }
        }

        public char[] Transform(char[] elements = null)
        {
            if (elements == null)
            {
                elements = new char[Count];
                Index = 0;
            }
            if (Left != null)
                Left.Transform(elements);
            elements[Index++] = Data;

            if (Right != null)
                Right.Transform(elements);
            return elements;
        }
    }
}

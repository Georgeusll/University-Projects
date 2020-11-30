#ifndef TREENODE_H
#define TREENODE_H
#include <iostream>
using namespace std;

class BST;
class TreeNode {
    friend class BST;
public:
    TreeNode(); //default constructor
    TreeNode(int i, TreeNode* L = 0, TreeNode* R = 0);//explicit value constructor
    int getItem() const; //accessor function
    void setItem(int i); //mutator function
private:
    int item;
    TreeNode* Lchild;
    TreeNode* Rchild;
};


inline TreeNode::TreeNode()
{
    item = 0;
    Lchild = Rchild = NULL;
}

inline TreeNode::TreeNode(int i, TreeNode* L, TreeNode* R)
{
    item = i;
    Lchild = L;
    Rchild = R;
}

inline void TreeNode::setItem(int i)
{
    item = i;
}

inline int TreeNode::getItem() const
{
    return item;
}



#endif // TREENODE_H

#ifndef BST_H
#define BST_H
#include "TreeNode.h"
#include <iostream>
using namespace std;


class BST
{
public:
    BST(); //default constructor
    void insert(int i);// insert in the BST
    bool search(int i);// search in the BST
    bool remove(int i);// remove from the BST
    //traversals of BST
    void inorder();
    void preorder();
    void postorder();

private:
    TreeNode* root;
    void inorder(TreeNode*);
    void preorder(TreeNode*);
    void postorder(TreeNode*);
    bool remove(TreeNode* r, TreeNode* parent);
};

#endif // BST_H

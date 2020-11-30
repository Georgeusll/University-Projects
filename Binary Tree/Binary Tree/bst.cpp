#include "bst.h"
#include <iostream>
using namespace std;
BST::BST() //default constructor
{
    root = NULL;
}
void BST::insert(int i)
{
    TreeNode* r = new TreeNode(i);
    if (root == NULL)
        root = r;
    else
    {
        TreeNode* t = root;
        while (t != NULL)
        {
            if (i < t->item) //if inserted value will be less than current nodes
            {
                if (t->Lchild == NULL) //go left subtree
                {
                    t->Lchild = r;
                    return;
                }
                else
                    t = t->Lchild;
            }
            else
            {
                if (t->Rchild == NULL) //go right subtree
                {
                    t->Rchild = r;
                    return;
                }
                else
                    t = t->Rchild;
            }
        }
    }

}
bool BST::search(int i)
{

    TreeNode* j = root;
    while (j != NULL)
    {
        if (j->item == i)
            return true;
        if (i < j->item)
        {
            j = j->Lchild;
        }
        else
        {
            j = j->Rchild;
        }
    }
    return false;
}

bool BST::remove(TreeNode* r, TreeNode* parent)
{
    if (r->Lchild == NULL && r->Rchild == NULL) //delete leaf
    {
        if (parent != NULL)
        {
            if (parent->Lchild == r)
                parent->Lchild = NULL;
            else
                parent->Rchild = NULL;
        }
        else //delete root
            root = NULL;

        delete r;
    }
    else if (r->Lchild != NULL && r->Rchild == NULL) //delete one child parent
    {
        if (parent != NULL)
        {
            if (parent->Lchild == r)
            {
                parent->Lchild = r->Lchild;
            }
            else
            {
                parent->Rchild = r->Lchild;
            }
        }
        else
            root = r->Lchild;

        delete r;
    }

    else if (r->Rchild != NULL && r->Lchild == NULL)
    {
        if (parent != NULL)
        {
            if (parent->Lchild == r)
            {
                parent->Lchild = r->Rchild;
            }
            else
            {
                parent->Rchild = r->Rchild;
            }
        }
        else
            root = r->Rchild;

        delete r;
    }
    else
    {
        //find the rightmost node in left subtree
        TreeNode* a = r->Lchild, * aparent = r;
        while (a->Rchild != NULL)
        {
            aparent = a;
            a = a->Rchild;
        }
        r->item = a->item;
        return remove(a, aparent);
    }


    return true;
}
bool BST::remove(int i)
{

    TreeNode* k = root, * parent = NULL;
    while (k != NULL)
    {
        if (k->item == i)
            return remove(k, parent);

        parent = k;
        if (i < k->item)
        {
            k = k->Lchild;
        }
        else
        {
            k = k->Rchild;
        }
    }
    return false;
}
void BST::inorder(TreeNode* r)
{
    if (r == NULL)
        return;

    inorder(r->Lchild);
    cout << r->item << " ";
    inorder(r->Rchild);

}
void BST::inorder()
{
    inorder(root);
    cout << endl;
}


void BST::preorder(TreeNode* r)
{
    if (r == NULL)
        return;


    cout << r->item << " ";
    preorder(r->Lchild);
    preorder(r->Rchild);

}

void BST::preorder()
{
    preorder(root);
    cout << endl;
}


void BST::postorder(TreeNode* r)
{
    if (r == NULL)
        return;

    postorder(r->Lchild);
    postorder(r->Rchild);
    cout << r->item << " ";

}
void BST::postorder()
{
    postorder(root);
    cout << endl;
}

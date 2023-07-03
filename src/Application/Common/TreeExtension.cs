
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Gconnect.Domain.Entities;

namespace Gconnect.Application.Common;
public static class TreeExtension
{
    public static TreeSelectDto BuildTree(this List<TreeSelectDto> nodes)
    {
        if (nodes == null)
        {
            throw new ArgumentNullException("nodes");
        }
        return new TreeSelectDto().BuildTree(nodes);
    }
    private static TreeSelectDto BuildTree(this TreeSelectDto root, List<TreeSelectDto> nodes)
    {
        if (nodes.Count == 0) { return root; }

        var children = root.FetchChildren(nodes).ToList();
        root.Children.AddRange(children);
        root.RemoveChildren(nodes);

        for (int i = 0; i < children.Count; i++)
        {
            children[i] = children[i].BuildTree(nodes);
            if (nodes.Count == 0) { break; }
        }

        return root;
    }
    public static IEnumerable<TreeSelectDto> FetchChildren(this TreeSelectDto root, List<TreeSelectDto> nodes)
    {
        return nodes.Where(n => n.ParentId == root.Value);
    }
    public static void RemoveChildren(this TreeSelectDto root, List<TreeSelectDto> nodes)
    {
        foreach (var node in root.Children)
        {
            nodes.Remove(node);
        }
    }
}

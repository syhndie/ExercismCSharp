using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {


        var sortedRecords = records.OrderBy(tbr => tbr.RecordId);

        //make an empty list of trees
        var trees = new List<Tree>();

        //create a variable for prev record id, set to -1
        var previousRecordId = -1;

        //for each tree building record
        foreach (var record in sortedRecords)
        {   
            //create a new tree with and empty list of children
            var t = new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId };

            //add that tree to the list of trees
            trees.Add(t);

            //throw an exception if root doesn't have 0 parentid, if non root doesn't have parentid less than itself
            //throw an exception if non root doesn't have id one greater than prev record
            if ((t.Id == 0 && t.ParentId != 0) ||
                (t.Id != 0 && t.ParentId >= t.Id) ||
                (t.Id != 0 && t.Id != previousRecordId + 1))
            {
                throw new ArgumentException();
            }

            //increase prev record id
            ++previousRecordId;
        }
        
        //throw an exception if list of trees is empty
        if (trees.Count == 0)
        {
            throw new ArgumentException();
        }

        //start with first tree with id == 1
        //get that tree's parent
        //go to the parent's children list and add the tree
        //increment through all remaining trees 
        for (int i = 1; i < trees.Count; i++)
        {
            var t = trees.First(x => x.Id == i);
            var parent = trees.First(x => x.Id == t.ParentId);
            parent.Children.Add(t);
        }

        //return the first tree with id==0 - this the the root tree, and will have all the other trees inside its children lists
        var r = trees.First(t => t.Id == 0);
        return r;
    }
}
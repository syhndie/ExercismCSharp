﻿using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public Tree(int _id, int _parentID)
    {
        Id = _id;
        ParentId = _parentID;
        Children = new List<Tree>();
    }

    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        string invalidInputMessage = ValidateRecords(records);
        if (invalidInputMessage != null) throw new ArgumentException(invalidInputMessage);
       
        var sortedRecords = records.OrderBy(tbr => tbr.RecordId);

        //make an empty list of trees
        var trees = new List<Tree>();

        //for each tree building record
        foreach (var record in sortedRecords)
        {   
            //create a new tree with empty list of children
            var newTree = new Tree(record.RecordId, record.ParentId);

            //add that tree to the list of trees
            trees.Add(newTree);
        }

        //start with first tree with id == 1
        //get that tree's parent
        //go to the parent's children list and add the tree
        //increment through all remaining trees 
        for (int i = 1; i < trees.Count; i++)
        {
            var childTree = trees.Single(t => t.Id == i);
            var parentTree = trees.Single(t => t.Id == childTree.ParentId);
            parentTree.Children.Add(childTree);
        }

        //return the first tree with id==0 - this the the root tree, and will have all the other trees inside its children lists
       return trees.Single(t => t.Id == 0);
    }

    private static string ValidateRecords (IEnumerable<TreeBuildingRecord> records)
    {
        if (records.Count() < 1) return "Record set must include at least one record";

        if (!records.Any(t => t.RecordId == 0)) return "Record set must include a Root (Record ID == 0";

        if (records.Where(t => t.RecordId == 0).Any(tbr => tbr.ParentId != 0)) return "Parent ID of Root must be zero.";
        
        if (records.Where(t => t.RecordId != 0).Any(tbr => tbr.ParentId >= tbr.RecordId)) return "Parent ID of all Branches must be less than Record ID";
        
        if (records.Select(t => t.RecordId).Distinct().Count() != records.Count()) return "All Record IDs must be unique";

        int maxRecordID = records.Select(t => t.RecordId).OrderBy(i => i).Last();
        if (maxRecordID != records.Count() - 1) return "All Record IDs must be continuous.";
        
        return null;
    }
}
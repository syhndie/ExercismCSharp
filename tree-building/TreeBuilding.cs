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

        var trees = records.Select(tbr => new Tree(tbr.RecordId, tbr.ParentId)).ToList();

        for (int i = 1; i < trees.Count; i++)
        {
            var childTree = trees.Single(t => t.Id == i);
            var parentTree = trees.Single(t => t.Id == childTree.ParentId);
            parentTree.Children.Add(childTree);
        }

       return trees.Single(t => t.Id == 0);
    }

    private static string ValidateRecords (IEnumerable<TreeBuildingRecord> records)
    {
        if (records.Count() < 1) return "Record set must include at least one record";

        if (!records.Any(tbr => tbr.RecordId == 0)) return "Record set must include a Root (Record ID == 0";

        if (records.Where(tbr => tbr.RecordId == 0).Any(tbr => tbr.ParentId != 0)) return "Parent ID of Root must be zero.";
        
        if (records.Where(tbr => tbr.RecordId != 0).Any(tbr => tbr.ParentId >= tbr.RecordId)) return "Parent ID of all Branches must be less than Record ID";
        
        if (records.Select(tbr => tbr.RecordId).Distinct().Count() != records.Count()) return "All Record IDs must be unique";

        int maxRecordID = records.Select(tbr => tbr.RecordId).OrderBy(i => i).Last();
        if (maxRecordID != records.Count() - 1) return "All Record IDs must be continuous.";
        
        return null;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    public KindergartenGarden(string diagram)
    {
        string[] rows = diagram.Split("\n");
        RowOnePlants = rows[0].ToCharArray().Select(c => PlantLookup[c]).ToList();
        RowTwoPlants = rows[1].ToCharArray().Select(c => PlantLookup[c]).ToList();

        StudentPlantsList = new List<StudentPlants>();
        for (int i=0; i < Students.Count; i++)
        {
            if (i < (RowOnePlants.Count)/2)
            {
                StudentPlants studentPlants = new StudentPlants()
                {
                    Student = Students[i],
                    PlantList = new List<Plant>
                    {
                        RowOnePlants[i*2],
                        RowOnePlants[(i*2)+1],
                        RowTwoPlants[i*2],
                        RowTwoPlants[(i*2)+1]
                    }
                };
                StudentPlantsList.Add(studentPlants);
            }
        }        
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return this.StudentPlantsList.Single(sp => sp.Student == student).PlantList;
    }

    private List<Plant> RowOnePlants { get; set; }
    private List<Plant> RowTwoPlants { get; set; }
    private List<StudentPlants> StudentPlantsList { get; set; }

    private static Dictionary<char, Plant> PlantLookup { get; } =
    new Dictionary<char, Plant>
    {
            { 'V', Plant.Violets },
            { 'R', Plant.Radishes },
            { 'C', Plant.Clover },
            { 'G', Plant.Grass }
    };

    private static List<string> Students { get; } =
        new List<string>()
        {
            "Alice",
            "Bob",
            "Charlie",
            "David",
            "Eve",
            "Fred",
            "Ginny",
            "Harriet",
            "Ileana",
            "Joseph",
            "Kincaid",
            "Larry"
        };
}

public class StudentPlants
{
    public string Student { get; set; }
    public List<Plant> PlantList { get; set; }
}
using System;
using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class Boundary : IBoundary
  {
    public string Name { get; set; } //Name of Room
    public string Description { get; set; }
    public List<IItem> Items { get; set; }  //Initialize Inventory
    public Dictionary<string, IBoundary> NeighborBoundaries { get; set; }


    // string AltDescription { get; set; } //NOTE you might not use this but could be useful for extension ideas
    // bool IsLosable { get; set; } //NOTE you might not use this but could be useful for extension ideas

    public void AddNeighborBoundary(IBoundary neighbor, bool autoAdd = true)
    {
      NeighborBoundaries.Add(neighbor.Name, neighbor);
      if (autoAdd == true)
      {
        neighbor.AddNeighborBoundary(this, false);
      }
    }

    public Boundary(String name, String description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      NeighborBoundaries = new Dictionary<string, IBoundary>();

    }
  }

}
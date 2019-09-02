using System.Collections.Generic;

namespace TreasureHunter.Interfaces
{
  public interface IBoundary
  {
    string Name { get; set; } //Name of Room
    string Description { get; set; }
    List<IItem> Items { get; set; }  //Initialize Inventory
    Dictionary<string, IBoundary> NeighborBoundaries { get; set; }

    // string AltDescription { get; set; } //NOTE you might not use this but could be useful for extension ideas
    // bool IsLosable { get; set; } //NOTE you might not use this but could be useful for extension ideas

    void AddNeighborBoundary(IBoundary neighbor, bool autoAdd);
  }
}
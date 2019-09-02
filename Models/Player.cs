using System;
using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<IItem> Inventory { get; set; }
    public Player(String name, IItem item)
    {
      Name = name;

      Inventory = new List<IItem>();
      Inventory.Add(item);
      Inventory.Clear();
    }

  }
}
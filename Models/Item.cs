using System;
using System.Collections.Generic;
using TreasureHunter.Interfaces;

namespace TreasureHunter.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }



    public Item(String name, String description)
    {
      Name = name;
      Description = description;
    }
  }

}
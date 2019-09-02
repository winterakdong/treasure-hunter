namespace TreasureHunter.Interfaces
{
  public interface IApp
  {
    IPlayer Player { get; set; }
    IBoundary Location { get; set; }
    bool Playing { get; set; }

    void Greeting();

    void Setup(); ///initialize all of your data for the application

    void Run(); //control flow loop for the application while Playing

    void DisplayMenu(); //Display valid commands that your user might enter (eg., 'look', 'take <itemName>')
    void CaptureUserInput(); //NOTE String.Split(<char>), string command and option, and your switch statement
    void DisplayRoomDescription(); //NOTE the logic to run when the user enters 'look'
    void ChangeLocation(); //NOTE the logic to run when the user enters 'go <locationName>' or 'enter <locationName>' (whatever you decide you command word is)
    void TakeItem(); //NOTE the logic to run when the user enters 'take <itemName>'
                     //to take an item you must find the target item in the Location's Items and if it exists remove it from the Location's Items and add to the Player's Inventory. 
    void DisplayPlayerInventory(); //NOTE the logic to run when the user enters 'inventory'
    void DisplayHelpInfo(); //NOTE the logic to run when the user enters 'help'
    void ActivateShortcut();

    //NOTE [STRETCH GOALS] - Basic requirements first and then extend your application.
    //void UseItem(); //NOTE [STRETCH GOAL] - to use an item you must check that your player has the target item in their Inventory and then if so modify the value of a property on the Location. You may keep or remove the item from the player's inventory according to what makes the most sense with your story.
  }
}
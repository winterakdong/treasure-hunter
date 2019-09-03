using System;
using System.Threading;
using System.Collections.Generic;
using TreasureHunter.Interfaces;
using TreasureHunter.Models;

namespace TreasureHunter
{
  public class App : IApp
  {
    public IPlayer Player { get; set; }
    public IBoundary Location { get; set; }
    public bool Playing { get; set; }
    public Player player;
    private List<Item> ShoppingList = new List<Item>();

    int Parameter;
    bool ShoppingCart;

    // Level one
    Boundary one = new Boundary("Living Room", "You are in the Showroom area of the store. There appears to be some living room displays. You can ride back down the escalator, or your can follow the path to Wall Units & Media Storage.");
    Boundary two = new Boundary("Wall Units & Media Storage", "You are in the Showroom area of the store. There appears to be some TV room displays. You can either go back to Living Room, or you can follow the path to Bedroom.");
    Boundary three = new Boundary("Bedroom", "You are in the Showroom area of the store. There appears to be some bedroom displays. You can either go back to Wall Units & Media Storage, or you can follow the path to Children's IKEA.");
    Boundary four = new Boundary("Children's IKEA", "You are in the Showroom area of the store. There appears to be some kids bedroom and play area displays. You can either go back to Bedroom, or you can follow the path to Workspaces.");
    Boundary five = new Boundary("Workspaces", "You are in the Showroom area of the store. There appears to be some office displays. You can either go back to Children's IKEA, or you can follow the path to Dining.");
    Boundary six = new Boundary("Dining", "You are in the Showroom area of the store. There appears to be some dining room displays. You can either go back to Workspaces, or you can follow the path to Kitchen.");
    Boundary seven = new Boundary("Kitchen", "You are in the Showroom area of the store. There appears to be some kitchen displays. You can either go back to Dining, or you can follow the path to the IKEA Marketplace.");

    // Level two
    Boundary eight = new Boundary("Swedish Foodmarket", "You are in the IKEA Marketplace. There appears to an assortment of Swedish goods on display such as meatballs, jams and sauces, candy, etc. There also appears to be some shopping carts. You can either go back to the Kitchen Showroom, or you can follow the path to Cookshop & Tableware.");
    Boundary nine = new Boundary("Restaurant & Café", "You are in the IKEA Marketplace. It appears to be a cafeteria. Perhaps you would like to purchase sustenance for the long journey ahead. You can only go back to the Swedish Foodmarket.");
    Boundary ten = new Boundary("Cookshop & Tableware", "You are in the IKEA Marketplace. There appears to be an assortment of kitchen and tableware goods such as pots and pans, utensils, food storageware, etc. You can either go back to the Swedish Foodmarket, or you can follow the path to the IKEA Marketplace.");
    Boundary eleven = new Boundary("Lighting", "You are in the IKEA Marketplace. There appears to be an assortment of lamps and lighting options. You can either go back to the Cookshop & Tableware, or you can follow the path to the Home Organization.");
    Boundary twelve = new Boundary("Home Organization", "You are in the IKEA Marketplace. There appears to be an assortment of storage units and shelves. You can either go back to the Lighting, or you can follow the path to the Bathroom.");
    Boundary thirteen = new Boundary("Bathroom", "You are in the IKEA Marketplace. There appears to be an assortment of bathroom fixtures and accessories. You can either go back to the Home Organization, or you can follow the path to the Textiles.");
    Boundary fourteen = new Boundary("Textiles", "You are in the IKEA Marketplace. There appears to be an assortment of curtains, toweletries, and fabrics. You can either go back to the Bathroom, or you can follow the path to the Rugs.");
    Boundary fifteen = new Boundary("Rugs", "You are in the IKEA Marketplace. There appears to be an assortment of rugs and mats. You can either go back to the Textiles, or you can follow the path to the Wall Decoration & Mirrors.");
    Boundary sixteen = new Boundary("Wall Decoration & Mirrors", "You are in the IKEA Marketplace. There appears to be an assortment of posters, wall clocks, mirrors, etc. You can either go back to the Rugs, or you can follow the path to the Home Decoration.");
    Boundary seventeen = new Boundary("Home Decoration", "You are in the IKEA Marketplace. There appears to be an assortment of decorative pieces such as baskets, candles, frames, etc. You can either go back to Wall Decoration & Mirrors, or you can ride the escalator down to Self-serve Furniture.");

    // Level three
    Boundary eighteen = new Boundary("Self-serve Furniture", "You are in the Self-serve Furniture area. It appears to be where all of the furniture from the Showroom is kept. There is a computer kiosk where you can look up the items from Showroom by Article Number. To use it, type < useComputer >. Hopefully you remebered to take notes as you were shopping! You can either ride the escalator back up to the IKEA Marketplace, or, if you are done, checkout.");
    Boundary end = new Boundary("Checkout", "");

    Boundary start = new Boundary("Storefront", "You are in the storefront area. There appears to be some shopping carts and displays. There is also an escalator that leads up to the Showroom.");

    bool startEight = false;
    bool oneThree = false;
    bool twoSeven = false;
    bool threeSix = false;
    bool fiveTen = false;
    bool eightTwelve = false;
    bool elevenFourteen = false;
    bool thirteenFifteen = false;
    bool fifteenEighteen = false;

    Item gymkhana = new Item("GYMKHANA", "Shopping cart");

    public void Greeting()
    {
      Console.Write("Welcome to IKEA Simulator! The game for tormented souls and stay-at-home-moms! Let's get some shopping done for your new simulated Apartment!" +
      "\nWhat is your name?: ");
      String name = Console.ReadLine();
      Item item = new Item("a", "b");
      player = new Player(name, item);
      // Console.Write("\n\nWhat difficulty level would you like? <1-20>");

      Console.WriteLine("\n\nHi " + player.Name + "! Ready to decorate your new place? Press the any key to continue.");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine("You'll need to pick up the following items:");
      Thread.Sleep(2000);

      for (int i = 0; i < ShoppingList.Count; i++)
      {
        String itemDescription = ShoppingList[i].Description;
        String[] splitItemDescription = itemDescription.Split(',');
        Console.WriteLine(">\t" + splitItemDescription[0]);
        Thread.Sleep(1000);
      }

      Console.WriteLine("\n\nGot It? Press the any key to continue.");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine("Oh no... you conveniently misplaced your shopping list. Thankfully, you don't need it. Right?");
      Console.WriteLine("\n\nPress the any key to continue.");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine("You might be tempted to buy other things along your journey. Remember that the objective is to only buy what you need. Lastly, don't let your patience run out or else you will not be able to complete your journey.");
      Console.WriteLine("\n\nPress the any key to begin your journey.");
      Console.ReadKey();
      Console.Clear();
    }

    public void Setup()
    {
      start.AddNeighborBoundary(one);
      one.AddNeighborBoundary(two);
      two.AddNeighborBoundary(three);
      three.AddNeighborBoundary(four);
      four.AddNeighborBoundary(five);
      five.AddNeighborBoundary(six);
      six.AddNeighborBoundary(seven);
      seven.AddNeighborBoundary(eight);
      eight.AddNeighborBoundary(nine);
      eight.AddNeighborBoundary(ten);
      ten.AddNeighborBoundary(eleven);
      eleven.AddNeighborBoundary(twelve);
      twelve.AddNeighborBoundary(thirteen);
      thirteen.AddNeighborBoundary(fourteen);
      fourteen.AddNeighborBoundary(fifteen);
      fifteen.AddNeighborBoundary(sixteen);
      sixteen.AddNeighborBoundary(seventeen);
      seventeen.AddNeighborBoundary(eighteen);
      eighteen.AddNeighborBoundary(end);

      List<Item> allItems = new List<Item>();

      Item ektorp = new Item("EKTORP", "Sofa, Lofallet beige *891.292.07");
      Item jappling = new Item("JÄPPLING", "Armchair, Kimstad dark brown *103.707.41");
      Item reggisor = new Item("REGISSÖR", "Coffee table, brown, glass *203.420.74");
      one.Items.Add(ektorp);
      one.Items.Add(jappling);
      one.Items.Add(reggisor);
      foreach (Item item in one.Items)
      {
        eighteen.Items.Add(item);
        allItems.Add(item);
      }

      Item bestaburs = new Item("BESTÅ BURS", "TV bench, high gloss white *302.691.29");
      two.Items.Add(bestaburs);
      foreach (Item item in two.Items)
      {
        eighteen.Items.Add(item);
        allItems.Add(item);
      }

      Item isfjorden = new Item("ISFJORDEN", "Bedroom mirror stand, black-brown satin *302.174.99");
      Item kullen = new Item("KULLEN", "Six piece dresser, black-brown *403.221.26");
      Item hemnes = new Item("KNARREVIK", "Nightstand, black *303.811.83");
      Item brunkrissla = new Item("BRUNKRISSLA", "Duvet cover and pillowcases, lilac *504.402.47");
      Item kallkrasse = new Item("KÄLLKRASSE", "Comforter, warmer *904.208.22");
      three.Items.Add(isfjorden);
      three.Items.Add(kullen);
      three.Items.Add(hemnes);
      three.Items.Add(brunkrissla);
      three.Items.Add(kallkrasse);
      foreach (Item item in three.Items)
      {
        eighteen.Items.Add(item);
        allItems.Add(item);
      }

      Item spisig = new Item("SPISIG", "Children's play kitchen, white and pink *204.278.17");
      Item trofast = new Item("TROFAST", "Storage combination with boxes, black, pink *392.286.72");
      Item sniglar = new Item("SNIGLAR", "Crib, beech *502.485.41");
      four.Items.Add(spisig);
      four.Items.Add(trofast);
      four.Items.Add(sniglar);
      foreach (Item item in four.Items)
      {
        eighteen.Items.Add(item);
        allItems.Add(item);
      }

      Item millberget = new Item("MILLBERGET", "Swivel chair, Kimstad white *003.317.07");
      Item frede = new Item("FREDDE", "Computer desk, black *502.190.44");
      five.Items.Add(millberget);
      five.Items.Add(frede);

      foreach (Item item in five.Items)
      {
        eighteen.Items.Add(item);
        allItems.Add(item);
      }

      Item malsjo = new Item("MALSJÖ", "Glassware cabinet, black stained *003.277.72");
      Item hoghem = new Item("HOGHEM", "Bar shelf, black-brown *103.894.44");
      Item skogsta = new Item("SKOGSTA", "Dining table, acacia *704.192.64");
      Item leifarne = new Item("LEIFARNE", "Dining chair, dark yellow, Broringe black *093.041.96");
      six.Items.Add(malsjo);
      six.Items.Add(hoghem);
      six.Items.Add(skogsta);
      six.Items.Add(leifarne);
      foreach (Item item in six.Items)
      {
        eighteen.Items.Add(item);
        allItems.Add(item);
      }

      Item almaren = new Item("ÄLMAREN", "Kitchen faucet, stainless steel color *503.416.43");
      Item saljan = new Item("SÄLJAN", "Countertop, black marble effect, laminate *603.356.94");
      seven.Items.Add(almaren);
      seven.Items.Add(saljan);
      foreach (Item item in seven.Items)
      {
        eighteen.Items.Add(item);
        allItems.Add(item);
      }

      Item marmeladApelsinFlader = new Item("MARMELAD APELSIN & FLÄDER", "Orange and elderflower marmalade, organic");
      Item smakrik = new Item("SMAKRIK", "Canola oil, wild garlic organic");
      eight.Items.Add(marmeladApelsinFlader);
      eight.Items.Add(smakrik);
      foreach (Item item in eight.Items)
      {
        allItems.Add(item);
      }

      Item swedishMeatballs = new Item("Swedish Meatballs", "Nourishment");
      Item salmonMeatballs = new Item("Salmon Meatballs", "Nourishment");
      Item salad = new Item("Blackberry Summer Salad", "Nourishment");
      Item cake = new Item("Chockolate Conspiracy Cake", "Nourishment");
      nine.Items.Add(swedishMeatballs);
      nine.Items.Add(salmonMeatballs);
      nine.Items.Add(salad);
      nine.Items.Add(cake);

      Item fullandad = new Item("FULLÄNDAD", "5-piece kitchen utensil set, gray");
      Item idealisk = new Item("IDEALISK", "Grater, stainless steel");
      Item rort = new Item("RÖRT", "Cooking spoon and fork set, beech");
      Item elly = new Item("ELLY", "Dish towels, white, blue");
      Item rajtan = new Item("RAJTAN", "Spice jar, glass, aluminum");
      Item ikea365 = new Item("IKEA 365+", "Food container set, glass");
      Item oumbarlig = new Item("OUMBÄRLIG", "Frying pan");
      Item lockbete = new Item("LOCKBETE", "Muffin pan, black");
      ten.Items.Add(fullandad);
      ten.Items.Add(idealisk);
      ten.Items.Add(rort);
      ten.Items.Add(elly);
      ten.Items.Add(rajtan);
      ten.Items.Add(ikea365);
      ten.Items.Add(oumbarlig);
      ten.Items.Add(lockbete);
      foreach (Item item in ten.Items)
      {
        allItems.Add(item);
      }

      Item hektar = new Item("HEKTAR", "Work lamp with wireless charging, dark gray");
      Item sillbo = new Item("SILLBO", "LED bulb, E26 140 lumen, globe, mirrored top bronze colored");
      eleven.Items.Add(hektar);
      eleven.Items.Add(sillbo);
      foreach (Item item in eleven.Items)
      {
        allItems.Add(item);
      }

      Item lack = new Item("SKÅDIS", "Pegboard with containers hooks and elastic coards, white");
      Item flyt = new Item("FLYT", "Magazine file bin, white");
      Item drona = new Item("DRÖNA", "Linen storage box, dark blue");
      twelve.Items.Add(lack);
      twelve.Items.Add(flyt);
      twelve.Items.Add(drona);
      foreach (Item item in twelve.Items)
      {
        allItems.Add(item);
      }

      Item kalkgrund = new Item("KALKGRUND", "Soap dispenser, chrome plated");
      Item trensum = new Item("TRENSUM", "Vanity mirror, stainless steel");
      Item lilla = new Item("LILLA", "Children's potty seat, green");
      Item immeln = new Item("IMMELN", "Shower caddy, two tiers, zinc plated");
      Item svartsjon = new Item("SVARTSJÖN", "Toilet paper roll holder, black");
      thirteen.Items.Add(kalkgrund);
      thirteen.Items.Add(trensum);
      thirteen.Items.Add(lilla);
      thirteen.Items.Add(immeln);
      thirteen.Items.Add(svartsjon);
      foreach (Item item in thirteen.Items)
      {
        allItems.Add(item);
      }

      Item sigrunn = new Item("SIGRUNN", "Plaid fabric sheet, white, multicolor");
      Item irmelin = new Item("IRMELIN", "Flower pattern fabric, white, multicolor");
      Item vikfjard = new Item("VIKFJÄRD", "Towel set, blue");
      fourteen.Items.Add(sigrunn);
      fourteen.Items.Add(irmelin);
      fourteen.Items.Add(vikfjard);
      foreach (Item item in fourteen.Items)
      {
        allItems.Add(item);
      }

      Item koldby = new Item("KOLDBY", "Cowhide Rug, brown");
      Item stillebak = new Item("STILLEBÄK", "Rug, low pile, blue");
      fifteen.Items.Add(koldby);
      fifteen.Items.Add(stillebak);
      foreach (Item item in fifteen.Items)
      {
        allItems.Add(item);
      }

      Item stopla = new Item("STOPLA", "Wall clock");
      Item knoppang = new Item("KNOPPÄNG", "Posters with frames, set of 8, black");
      Item rotsund = new Item("ROTSUND", "Mirror, white");
      sixteen.Items.Add(stopla);
      sixteen.Items.Add(knoppang);
      sixteen.Items.Add(rotsund);
      foreach (Item item in sixteen.Items)
      {
        allItems.Add(item);
      }

      Item pepparkorn = new Item("PEPPARKORN", "Vase, blue");
      Item utvandig = new Item("UTVÄNDIG", "Decorative tray, natural");
      Item annanstans = new Item("ANNANSTANS", "Handmade decorative plate, black and brown");
      Item borrby = new Item("BORRBY", "Lantern for candle, black indoor/outdoor");
      seventeen.Items.Add(pepparkorn);
      seventeen.Items.Add(utvandig);
      seventeen.Items.Add(annanstans);
      seventeen.Items.Add(borrby);
      foreach (Item item in seventeen.Items)
      {
        allItems.Add(item);
      }

      List<int> generateShoppingList = new List<int>();
      Random random = new Random();
      int itemIndex;
      for (int i = 0; i < 10; i++)
      {
        do
        {
          itemIndex = random.Next(allItems.Count);
        } while (generateShoppingList.Contains(itemIndex));
        generateShoppingList.Add(itemIndex);
      }

      foreach (int i in generateShoppingList)
      {
        ShoppingList.Add(allItems[i]);
      }

      start.Items.Add(gymkhana);
      eight.Items.Add(gymkhana);
      ShoppingCart = false;

      Location = start;
      Playing = true;
    } //initialize all of your data for the application

    public void Run()
    {
      Playing = true;
      Greeting();

      do
      {
        DisplayMenu();
      } while (Playing);
    } //control flow loop for the application while Playing

    public void DisplayMenu()
    {
      if (player.HealthPoints < 0)
      {
        Console.WriteLine("Oh no! You lost all of your patience and have a mental breakdown in the store. You are no longer mentally or emotionally fit to continue your shopping journey.\n\nPress the any key to exit.");
        Console.ReadKey();
        Environment.Exit(0);
      }

      Console.WriteLine($"You are in {Location.Name}. From here, you can go to:");
      int i = 1;
      foreach (KeyValuePair<String, IBoundary> item in Location.NeighborBoundaries)
      {
        Console.WriteLine(i + " >\t{0}", item.Key);
        i++;
      }
      Console.WriteLine("\n\nWhat would you like to do? If you need help, type <help> or type <quit> to quit.");

      CaptureUserInput();
    } //Display valid commands that your user might enter (eg., 'look', 'take <itemName>')
    public void CaptureUserInput()
    {
      String rawInput = Console.ReadLine();
      String[] readInput = rawInput.Split(' ');

      String command = readInput[0];
      command = command.ToLower();
      String strParameter;

      if (readInput.Length > 1)
      {
        strParameter = readInput[1];
        try
        {
          Parameter = int.Parse(strParameter);
        }
        catch (Exception e)
        {
          Console.WriteLine("Please enter valid parameter. Type <help> to print a list of commands and options.\n\nPress the any key to continue.");
          Console.ReadKey();
          Console.Clear();
          return;
        }
      }

      switch (command)
      {
        case "go":
          ChangeLocation();
          player.HealthPoints -= 2;
          break;
        case "take":
          TakeItem();
          player.HealthPoints -= 1;
          break;
        case "drop":
          DropItem();
          player.HealthPoints -= 3;
          break;
        case "look":
          DisplayRoomDescription();
          player.HealthPoints -= 1;
          break;
        case "inventory":
          DisplayPlayerInventory();
          break;
        case "usecomputer":
          FindItem();
          break;
        case "stresslevel":
          DisplayHealth();
          break;
        case "help":
          DisplayHelpInfo();
          break;
        case "quit":
          Playing = false;
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("Please enter valid command. Type <help> to print a list of commands and options.");
          Console.Clear();
          break;
      }
    } //NOTE String.Split(<char>), string command and option, and your switch statement
    public void DisplayRoomDescription()
    {
      Console.Clear();
      int i = 1;

      if (Location == eighteen)
      {
        Console.WriteLine(Location.Description + "\n\nPress the any key to continue.");
        Console.ReadKey();
        Console.Clear();
        return;
      }

      Console.WriteLine(Location.Description + "\n\nPress the any key to continue.");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine(Location.Description);

      Console.WriteLine("\n\nUpon looking around, you find these items of interest:");
      Thread.Sleep(2000);
      foreach (Item item in Location.Items)
      {
        Console.WriteLine($"{i}>\t{item.Name}\n\t  {item.Description}");
        Thread.Sleep(1000);
        i++;
      }
      Console.WriteLine("\n\nPress the any key to continue.");
      Console.ReadKey();
      Console.Clear();

      Random random = new Random();
      int randomNumber = random.Next(100);
      if (randomNumber <= 35)
      {
        ActivateShortcut();
        Console.WriteLine("\n\nPress the any key to go back to the menu.");
        Console.ReadKey();
        Console.Clear();
      }
    } //NOTE the logic to run when the user enters 'look'

    public void ChangeLocation()
    {
      int i = 0;
      foreach (KeyValuePair<String, IBoundary> newLocation in Location.NeighborBoundaries)
      {
        if (Parameter < 1)
        {
          Console.WriteLine("Please enter valid parameter. Type < help > to print a list of commands and options.\n\nPress the any key to continue.");
          Console.ReadKey();
          Console.Clear();
          return;
        }
        else if (i == Parameter - 1)
        {
          Location = newLocation.Value;
          if (Location == end)
          {
            FinishGame();
            return;
          }
          Console.Clear();
        }

        i++;
      }

      Random random = new Random();
      int randomInt = random.Next(1, 35);

      switch (randomInt)
      {
        case 1:
          Console.WriteLine("As you are walking to the next area, a horde of slow walkers block your path. Your stress level goes up by 5 points.");
          player.HealthPoints -= 5;
          Console.WriteLine("\n\nPress the any key to continue.");
          Console.ReadKey();
          break;
        case 2:
          Console.WriteLine("You spot two kids screaming at the top of their lungs. One of the kids chucks a meatball at your face. Your stress level goes up by 20 points.");
          player.HealthPoints -= 20;
          Console.WriteLine("\n\nPress the any key to continue.");
          Console.ReadKey();
          break;
        case 3:
          Console.WriteLine("You can't help but stare at a couple arguing about the color of the curtains that they are about to buy. The husband glares at you and you both make awkward eye contact for a solid 20 seconds. Your stress level goes up by 15 points.");
          player.HealthPoints -= 15;
          Console.WriteLine("\n\nPress the any key to continue.");
          Console.ReadKey();
          break;
        default:
          break;
      }
      Console.Clear();
    } //NOTE the logic to run when the user enters 'go <locationName>' or 'enter <locationName>' (whatever you decide you command word is)

    public void TakeItem()
    {
      String[] typeOfRoom = Location.Description.Split(' ');

      if (Parameter < 1 || Parameter > Location.Items.Count)
      {
        Console.WriteLine("Please enter valid parameter. Type < help > to print a list of commands and options.");
      }
      else if (Location.Items[Parameter - 1].Description.Equals("Nourishment"))
      {
        Item foodItem = (Item)Location.Items[Parameter - 1];
        Random random = new Random();
        int healthPointsGained = random.Next(15, 45);

        player.HealthPoints += healthPointsGained;
        Location.Items.Remove(foodItem);
        System.Console.WriteLine($"You're stress level goes down by {healthPointsGained} points!");
      }
      else if (Location == eighteen)
      {
        Console.WriteLine("\n\nUnable to find item. Perhaps the computer kiosk may be able help you. To use it, type < useComputer >. Hopefully you remebered to take notes as you were shopping!");
      }
      else if (typeOfRoom[4] == "Showroom")
      {
        Console.WriteLine("\n\nCannot take an item from the Showcase area. To find this item, visit the Self-serve furniture area.");
      }
      else if (ShoppingCart && (Item)Location.Items[Parameter - 1] == gymkhana)
      {
        Console.WriteLine("\n\nCannot take another shopping cart!");
      }
      else if ((Item)Location.Items[Parameter - 1] == gymkhana)
      {
        Item item = (Item)Location.Items[Parameter - 1];
        player.Inventory.Add((IItem)item);
        Console.WriteLine($"\n\nSuccessfully took GYMKHANA.");
        ShoppingCart = true;
      }
      else if (player.Inventory.Contains(gymkhana) == false)
      {
        Console.WriteLine("\n\nYou need a shopping cart to take this item.");
      }
      else
      {
        Item item = (Item)Location.Items[Parameter - 1];
        player.Inventory.Add((IItem)item);
        Console.WriteLine($"\n\nSuccessfully added {item.Name} to inventory.");
      }
      Console.WriteLine("Press the any key to continue.");
      Console.ReadKey();
      Console.Clear();
    } //NOTE the logic to run when the user enters 'take <itemName>'
      //to take an item you must find the target item in the Location's Items and if it exists remove it from the Location's Items and add to the Player's Inventory. 
    public void DropItem()
    {
      if (Parameter < 1 || Parameter > player.Inventory.Count)
      {
        Console.WriteLine("Please enter valid parameter. Type < help > to print a list of commands and options.");
      }
      else
      {
        Console.WriteLine($"You dropped {player.Inventory[Parameter - 1].Name} from your inventory.");
        player.Inventory.RemoveAt(Parameter - 1);
      }

      Console.WriteLine("Press the any key to continue.");
      Console.ReadKey();
      Console.Clear();
    }
    public void DisplayPlayerInventory()
    {
      Console.Clear();

      if (player.Inventory.Count == 0)
      {
        Console.WriteLine("There is nothing in your inventory.");
      }
      else
      {
        Console.WriteLine("Here is what you have:");
        Thread.Sleep(2000);

        int i = 1;
        foreach (IItem item in player.Inventory)
        {
          Console.WriteLine($"{i}>\t{item.Name}\n\t  {item.Description}");
          Thread.Sleep(1000);
          i++;
        }
      }

      Console.WriteLine("\n\nPress the any key to continue.");
      Console.ReadKey();
      Console.Clear();
    } //NOTE the logic to run when the user enters 'inventory'

    public void FindItem()
    {
      Console.Clear();
      Console.WriteLine("Welcome to IKEA Self-service Kiosk. Enter the Article Number to the item that you are looking for, or type < back > to exit.");
      Console.Write("\nEnter Article Number <XXX.XXX.XX>: ");

      String userInput = Console.ReadLine();
      if (userInput == "back")
      {
        return;
      }

      foreach (Item item in eighteen.Items)
      {
        String[] modItemDescription = item.Description.Split('*');
        String articleNumber = modItemDescription[1];

        if (articleNumber.Equals(userInput))
        {
          player.Inventory.Add(item);
          Console.WriteLine($"{item.Name} was located and added to your inventory.");
          Console.WriteLine("\n\nPress the any key to continue.");
          Console.ReadKey();
          Console.Clear();
          return;
        }
      }
      Console.WriteLine("Item not found. Check to have that you have a valid Article Number. Then, try again.");
      Console.WriteLine("\n\nPress the any key to continue.");
      Console.ReadKey();
      Console.Clear();
    }

    public void FinishGame()
    {
      Console.Clear();
      Console.Write("Done with shopping? Press < Y > for yes and < N > for no. ");

      String userInput = Console.ReadLine().ToLower();
      switch (userInput)
      {
        case "y":
          DisplayGameResults();
          break;
        case "n":
          Parameter = 1;
          ChangeLocation();
          break;
        default:
          FinishGame();
          break;
      }
    }

    public void DisplayGameResults()
    {
      Console.Clear();
      int points = 0;
      player.Inventory.Remove(gymkhana);
      Console.WriteLine("Here is what you purchased from your shopping list:");
      Thread.Sleep(2000);
      if (player.Inventory.Count == 0)
      {
        Console.WriteLine("There is nothing in your inventory.");
      }
      else
      {
        foreach (IItem item in player.Inventory)
        {
          if (ShoppingList.Contains((Item)item))
          {
            Console.WriteLine($">\t{item.Name}\n\t  {item.Description}");
            points += 100;
          }
          Thread.Sleep(1000);
        }
      }

      Console.WriteLine("\n\nHere is what you are missing from your shopping list:");
      Thread.Sleep(2000);
      foreach (IItem item in ShoppingList)
      {
        if (!player.Inventory.Contains(item))
        {
          Console.WriteLine($">\t{item.Name}\n\t  {item.Description}");
          points -= 30;
        }
        Thread.Sleep(1000);
      }

      Console.WriteLine("\n\nHere is what you didn't need:");
      Thread.Sleep(2000);
      foreach (IItem item in player.Inventory)
      {
        if (ShoppingList.Contains((Item)item) == false)
        {
          Console.WriteLine($">\t{item.Name}\n\t  {item.Description}");
          points -= 10;
        }
        Thread.Sleep(1000);
      }

      points = points + (player.HealthPoints * 2);
      if (points < 0)
      {
        points = 0;
      }

      Console.Write("\n\nYou're total points for this game are: ");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write(points);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\n\nPress the any key to continue.");
      Console.ReadKey();
      Console.Clear();

      bool playerResponds = false;
      do
      {
        Console.WriteLine("Would you like to play another game? Press < Y > for yes and < N > for no. ");
        String userInput = Console.ReadLine().ToLower();
        switch (userInput)
        {
          case "y":
            Playing = false;
            playerResponds = true;
            break;
          case "n":
            Playing = false;
            playerResponds = true;
            Environment.Exit(0);
            break;
          default:
            Console.WriteLine("Please enter a valid option!");
            break;
        }
      } while (playerResponds == false);
    }

    public void DisplayHelpInfo()
    {
      Console.Clear();
      Console.WriteLine(
        "Instructions:" +
        "\nThe objective of the game is to pick up as many items from your shopping list by exploring the entire store." +
        "\n\n\tGo < Option >\n\t  Moves the player from room to room" +
        "\n\tTake < Option >\n\t  Places an item into the player inventory" +
        "\n\tDrop < Option >\n\t  Drops an item into the player inventory" +
        "\n\tLook\n\t  Prints the description of the room again" +
        "\n\tInventory\n\t  Prints the players inventory" +
        "\n\tStressLevel\n\t  Checks your stress level" +
        "\n\tQuit\n\t  Quits the Game" +
        "\nTo finish the game, go to Checkout and see how you did!" +

        "\n\nPress the any key to go back to the menu.");
      Console.ReadKey();
      Console.Clear();
    } //NOTE the logic to run when the user enters 'help'

    public void DisplayHealth()
    {
      Console.Clear();
      Console.WriteLine($"You have {player.HealthPoints} points left in your stress bank.\nConsider replenishing yourself with Meatballs or other foods at the Restuarant & Café along the way.\n\nPress the any key to go back to the menu.");
      Console.ReadKey();
      Console.Clear();
    }

    public void ActivateShortcut()
    {
      if ((Boundary)Location == start && startEight == false)
      {
        start.AddNeighborBoundary(eight);
        startEight = true;
        System.Console.WriteLine("You discovered a shortcut to the IKEA Marketplace!");
      }
      else if ((Boundary)Location == eight && startEight == false)
      {
        start.AddNeighborBoundary(eight);
        startEight = true;
        System.Console.WriteLine("You discovered a shortcut to the Showroom!");
      }
      else if (((Boundary)Location == one || (Boundary)Location == three) && oneThree == false)
      {
        one.AddNeighborBoundary(three);
        oneThree = true;
        System.Console.WriteLine("You discovered a new shortcut!");
      }
      else if (((Boundary)Location == two || (Boundary)Location == seven) && twoSeven == false)
      {
        two.AddNeighborBoundary(seven);
        twoSeven = true;
        System.Console.WriteLine("You discovered a new shortcut!");
      }
      else if (((Boundary)Location == three || (Boundary)Location == six) && threeSix == false)
      {
        three.AddNeighborBoundary(six);
        threeSix = true;
        System.Console.WriteLine("You discovered a new shortcut!");
      }
      else if ((Boundary)Location == five && fiveTen == false)
      {
        five.AddNeighborBoundary(ten);
        fiveTen = true;
        System.Console.WriteLine("You discovered a shortcut to the IKEA Marketplace!");
      }
      else if ((Boundary)Location == ten && fiveTen == false)
      {
        five.AddNeighborBoundary(ten);
        fiveTen = true;
        System.Console.WriteLine("You discovered a shortcut to the Showroom!");
      }
      else if (((Boundary)Location == eight || (Boundary)Location == twelve) && eightTwelve)
      {
        eight.AddNeighborBoundary(twelve);
        eightTwelve = true;
        System.Console.WriteLine("You discovered a new shortcut!");
      }
      else if (((Boundary)Location == eleven || (Boundary)Location == fourteen) && elevenFourteen == false)
      {
        eleven.AddNeighborBoundary(fourteen);
        elevenFourteen = true;
        System.Console.WriteLine("You discovered a new shortcut!");
      }
      else if (((Boundary)Location == thirteen || (Boundary)Location == fifteen) && thirteenFifteen == false)
      {
        thirteen.AddNeighborBoundary(fifteen);
        thirteenFifteen = true;
        System.Console.WriteLine("You discovered a new shortcut!");
      }
      else if ((Boundary)Location == fifteen && fifteenEighteen == false)
      {
        thirteen.AddNeighborBoundary(fifteen);
        fifteenEighteen = true;
        System.Console.WriteLine("You discovered an elevator down to Self-serve furniture!");
      }
      else if ((Boundary)Location == eighteen && fifteenEighteen == false)
      {
        thirteen.AddNeighborBoundary(fifteen);
        fifteenEighteen = true;
        System.Console.WriteLine("You discovered an elevator up to the IKEA Marketplace!");
      }
      else
      {
        System.Console.WriteLine("You've discovered all of the shortcuts in this area.");
      }
    }
    //NOTE [STRETCH GOALS] - Basic requirements first and then extend your application.
    //void UseItem(); //NOTE [STRETCH GOAL] - to use an item you must check that your player has the target item in their Inventory and then if so modify the value of a property on the Location. You may keep or remove the item from the player's inventory according to what makes the most sense with your story.
  }
}
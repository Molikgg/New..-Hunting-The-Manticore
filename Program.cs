int damage;
bool hitTarget = false; // to update the player score
int userRange = 0; // input from user 
int cityHealth = 15;
int manticoreHealth = 10;
Console.Write("Enter the desired range From 0 to 100: ");
int enemyRange = AskUserForNumber();
{
    enemyRange = CheckForCorrectRange(enemyRange);
}
Console.Clear();
Console.WriteLine("Player 2 its Your turn..");

for (int i = 1; manticoreHealth > 0 && cityHealth > 0; i++)
{
    int fire = i, electric = i;

    if (fire % 3 == 0 && electric % 5 == 0) damage = 10;
    else if (fire % 3 == 0 || electric % 5 == 0) damage = 3;
    else damage = 1;

    Repetation(i, cityHealth, manticoreHealth);
    userRange = AskUserForNumber(); // After asking for desired cannon range
    hitTarget = ShipAttackLogic(userRange, enemyRange); // If hit or no hit 
    if (hitTarget)
    {
        manticoreHealth -= damage;
        hitTarget = false;
    }
}

if (manticoreHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"""
             Consolas Won!
             """);
    NutralizeColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine($"""
             Uncoded Won!
             The range was: {enemyRange}
             """);
    NutralizeColor();
}

//Methods.........
int CheckForCorrectRange(int range)
{
    for (; ; )
    {
        if (range > 100 || range < 0)
        {
            Console.Write("Enter the desired range From 0 to 100 ONLY!");
            range = AskUserForNumber();
        }
        else
        {
            return range;
        }
    }
}

bool ShipAttackLogic(int userRange, int enemyRange) //4th line 
{
    cityHealth--;
    if (userRange != enemyRange)
    {
        for (int i = 0; i <= 15; i++) // Check if the Number lies in a range (+-)15 
        {
            if ((userRange + i) == enemyRange || (userRange - i) == enemyRange)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("That round FELL SHORT of the target");
                NutralizeColor();
                return false;
            }
        }
        Console.WriteLine("That round OVERSHOT the target");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Direct Hit");
        NutralizeColor();
        return true;
    }
    return false;
}

int AskUserForNumber()
{
    return int.Parse(Console.ReadLine());
}

void Repetation(int currentRound, int cityHealth, int manticoreHealth)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"""
               --------------------------------------------------
               STATUS: Round {currentRound} City: {cityHealth}/15 Maticore: {manticoreHealth}/10    
               """);
    NutralizeColor();
    Console.Write($"""
             Cannon is expected to hit {damage} damage
             Enter the Desired Cannon range: 
             """);
}
void NutralizeColor()
{
    Console.ForegroundColor = ConsoleColor.White;
}

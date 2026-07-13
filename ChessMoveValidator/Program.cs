abstract class Piece
{
    public string Colour { get; set; }
    public Position Position { get; set; }
    public abstract bool IsValid(Position destination);
}

class Pawn : Piece
{   
    public Pawn(Position position, string colour)
    {
        Position = position;
        Colour = colour;
    }
    public override bool IsValid(Position destination)
    {
        if (Position.X == destination.X && Position.Y+1 == destination.Y)
        {
            return true;
        }
        
        return false;
    }
}

class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Position start_position = GetStartPos();
            string colour = GetColour();   
            Position end_position = GetEndPos();    
            
            Pawn pawn = new Pawn(start_position, colour);

            while (!pawn.IsValid(end_position))
            {
                Console.WriteLine("Invalid move");
                end_position = GetEndPos();
            }
            Console.WriteLine("Valid move");
        }
    }
    
    
    public static string GetColour()
    {
        Console.WriteLine("Enter colour of moving piece: ");
        string colour = Console.ReadLine().Trim().ToLowerInvariant() ?? null;
        return colour;
    }
    public static Position GetEndPos()
    {
        Console.WriteLine("Enter destination position: ");
        string end_pos = Console.ReadLine().Trim().ToLowerInvariant() ?? null;
        Position end_position = ConvertToPosition(end_pos);
        return end_position;
    }
    public static Position GetStartPos()
    {
        Console.WriteLine("Enter position of moving piece: ");
        string start_pos = Console.ReadLine().Trim().ToLowerInvariant() ?? null;
        Position start_position = ConvertToPosition(start_pos);
        return start_position;
    }
    private static Position ConvertToPosition(string position)
    {
        char letter = position[0];
        char number = position[1];
        
        int x = letter - 'a';
        int y = number - '1';
        
        return new Position(x,y);
    }
    

}
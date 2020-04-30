// Randomize and print the amount of shots fired
var random = new Random();
int randomInteger = random.Next(10, 21);
int totalShots = random.Next(10, 21);
Console.WriteLine($"Total shots: {totalShots}");


// Randomize and print the amount of shots fired
var random = new Random();
int randomInteger = random.Next(10, 21);
int totalShots = random.Next(10, 21);
Console.WriteLine($"Total shots: {totalShots}");

// Randomize and print how many shots hit
int hits = random.Next(totalShots);
Console.WriteLine($"Hits: {hits}");

// Calculate and print the hit percentage
double acc = (double)hits / totalShots * 100;
Console.WriteLine($"Accuracy {acc}% ");


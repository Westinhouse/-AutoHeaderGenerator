
﻿var random = new Random();
int randomInteger = random.Next(0, 11);
int Throw = random.Next(0, 11);
int pinsLeft = (10 - (Throw));
int Throw2 = random.Next(0, (pinsLeft));
int frameScore = Throw + Throw2;
int finalPins = (10 - (frameScore));
Console.WriteLine($"First roll: {Throw}");
Console.WriteLine($"Second roll {Throw2}");
Console.WriteLine($"Number of pins left standing are {finalPins}");
Console.WriteLine($"Your score for the frame is {frameScore}");
// r_n+1 = (a*r_n+c) mod m (--> priemgetal)

//m - 2³¹ a = 214013 c=2531011

LCG lCG = new LCG();
Console.WriteLine(lCG.Next());
Console.WriteLine(lCG.Next(20));

Console.WriteLine(lCG.Next(10));


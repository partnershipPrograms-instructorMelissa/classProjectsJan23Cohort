// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
Random rand = new Random();
List<string> adj = new List<string>();
List<string> food = new List<string>();
string temp = "null";
bool playing = true;
Console.WriteLine("Welcome to our Mad Lib Game");
Console.WriteLine("Lets build our list of random words");
while(playing) {
    bool buildList = false;
    while(!buildList) {
        if(adj.Count < 4) {
            for(int i = 0; i < 4; i++) {
                Console.WriteLine("Please give us an adjective");
                temp = Console.ReadLine();
                adj.Add(temp);
                // Console.WriteLine(i);
                // Console.WriteLine(adj.Count);
            }
        }
        if(food.Count < 4) { // talking to the length/count not index index 0-3 count 1-4
            for(int i = 0; i < 4; i++) { // start at 0 end before 4 (index)
                Console.WriteLine("Please give us an food");
                temp = Console.ReadLine();
                food.Add(temp);
                // Console.WriteLine(i);
                // Console.WriteLine(food.Count);
            }
        }
        else {
            buildList = true;
        }
    }
    Console.WriteLine("We have our list of words");
    int randFood = rand.Next(0,4); // start at 0 end before 4
    int randAdj = rand.Next(0,4);
    // Console.WriteLine($"{randAdj} and {randFood}");
    // Console.WriteLine($"Our Random words are {adj[randAdj]} and {food[randFood]}");
    Console.WriteLine($"It was a {food[randFood]}, rainy day in April and I was super {adj[randAdj]} for lunch.");
    playing = false;
}
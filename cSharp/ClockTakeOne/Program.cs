// See https://aka.ms/new-console-template for more information

// Programming Languages
List<string> progLangs = new List<string>();
progLangs.Add("C#");
progLangs.Add("JS");
progLangs.Add("HTML");
progLangs.Add("CSS");
progLangs.Add("jQuery");
progLangs.Add("Less");

List<string> progSkills = new List<string>();
progSkills.Add("Google Fu");
progSkills.Add("Git");
progSkills.Add("Verbal Coding");
progSkills.Add("Pseudo-Coding");


List<string> progTools = new List<string>();
progTools.Add("MySQL");
progTools.Add("VS Code");
progTools.Add("Discord");
progTools.Add("Github");
progTools.Add("Zoom");

static void progLists(List<string> aList) {
    foreach(var item in aList) {
        Console.WriteLine(item);
    }
}
progLists(progLangs);
Console.WriteLine("------------------------------");
progLists(progSkills);
Console.WriteLine("------------------------------");
progLists(progTools);
void Main(string argument) 
{ 
    // get air info

    List<IMyTerminalBlock> airvents = new List<IMyTerminalBlock>();  
    GridTerminalSystem.SearchBlocksOfName("Air Vent Hangar 1", airvents);  
      
    double air = 0; 
 
    for (int i = 0; i < airvents.Count; i++) {  
        IMyAirVent vent = (IMyAirVent) airvents[i];  
        air = vent.GetOxygenLevel(); 
        break;  
    } 
 
    List<IMyTerminalBlock> panels = new List<IMyTerminalBlock>(); 
    GridTerminalSystem.SearchBlocksOfName("Bridge Panel", panels); 
     
    for (int i = 0; i < panels.Count; i++) { 
        IMyTextPanel panel = (IMyTextPanel) panels[i]; 
        panel.WritePublicText("Oxygen Level: " + Math.Round(air * 100, 4) + "%"); 
        panel.WritePublicText("\nX: " + panel.GetPosition().GetDim(0), true);
        panel.WritePublicText("\nY: " + panel.GetPosition().GetDim(1), true);
        panel.WritePublicText("\nZ: " + panel.GetPosition().GetDim(2), true);
        panel.ShowPublicTextOnScreen(); 
    } 
}
